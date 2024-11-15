using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class VNPayService
{
    private readonly IConfiguration _configuration;

    public VNPayService(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    /// <summary>
    /// Generates a VNPay payment URL with the necessary parameters and secure hash.
    /// </summary>
    public string GenerateVnPayUrl(decimal amount, string orderInfo, string orderId)
    {
        // Construct the VNPay parameters
        var vnPayParams = new SortedList<string, string>
        {
            { "vnp_Version", _configuration["VNPay:Version"] ?? "2.1.0" },
            { "vnp_Command", _configuration["VNPay:Command"] ?? "pay" },
            { "vnp_TmnCode", _configuration["VNPay:TmnCode"] ?? "DEFAULT_TMNCODE" },
            { "vnp_Amount", ((long)(amount * 100)).ToString() }, // Convert amount to smallest currency unit (e.g., VND)
            { "vnp_CurrCode", _configuration["VNPay:CurrCode"] ?? "VND" },
            { "vnp_TxnRef", orderId ?? "DEFAULT_ORDERID" },
            { "vnp_OrderInfo", HttpUtility.UrlEncode(orderInfo ?? "Default Order Info") },
            { "vnp_Locale", _configuration["VNPay:Locale"] ?? "vn" },
            { "vnp_ReturnUrl", HttpUtility.UrlEncode(_configuration["VNPay:ReturnUrl"] ?? "https://localhost:7243/OrderConfirmation") },
            { "vnp_IpAddr", "127.0.0.1" }, // IP address, set as localhost for development
            { "vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss") }
        };

        // Generate the secure hash for data integrity
        string signData = BuildDataString(vnPayParams);
        string hashSecret = _configuration["VNPay:HashSecret"] ?? throw new InvalidOperationException("Hash secret is not configured.");
        string secureHash = ComputeHmacSHA512(hashSecret, signData);
        vnPayParams.Add("vnp_SecureHash", secureHash);

        // Build the final URL
        string queryString = BuildQueryString(vnPayParams);
        return $"{_configuration["VNPay:BaseUrl"] ?? "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"}?{queryString}";
    }

    /// <summary>
    /// Verifies VNPay response by comparing the secure hash.
    /// </summary>
    public bool VerifyVnpayResponse(Dictionary<string, string> vnpayData)
    {
        if (!vnpayData.TryGetValue("vnp_SecureHash", out string? receivedSecureHash) || string.IsNullOrEmpty(receivedSecureHash))
        {
            return false; // No secure hash found in response
        }

        // Remove the secure hash from the data to recalculate
        vnpayData.Remove("vnp_SecureHash");

        var sortedData = new SortedList<string, string>(vnpayData);
        string signData = BuildDataString(sortedData);
        string hashSecret = _configuration["VNPay:HashSecret"] ?? throw new InvalidOperationException("Hash secret is not configured.");
        string computedHash = ComputeHmacSHA512(hashSecret, signData);

        // Validate that the computed hash matches the received hash
        return computedHash.Equals(receivedSecureHash, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Builds a data string from a sorted list of key-value pairs for signing.
    /// </summary>
    private string BuildDataString(SortedList<string, string> data)
    {
        var builder = new StringBuilder();
        foreach (var kvp in data)
        {
            if (!string.IsNullOrEmpty(kvp.Value))
            {
                builder.Append($"{kvp.Key}={kvp.Value}&");
            }
        }
        return builder.ToString().TrimEnd('&'); // Ensure no trailing '&'
    }

    /// <summary>
    /// Builds a query string from a sorted list of key-value pairs.
    /// </summary>
    private string BuildQueryString(SortedList<string, string> data)
    {
        var queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach (var kvp in data)
        {
            queryString[kvp.Key] = kvp.Value;
        }
        return queryString.ToString();
    }

    /// <summary>
    /// Computes HMAC SHA-512 hash of the data using the provided key.
    /// </summary>
    private string ComputeHmacSHA512(string key, string data)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(data))
        {
            throw new ArgumentException("Key and data cannot be null or empty.");
        }

        using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
        {
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
