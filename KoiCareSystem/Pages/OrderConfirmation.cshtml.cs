using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Collections.Generic;

public class OrderConfirmationModel : PageModel
{
    public string PaymentStatus { get; set; }
    public string TransactionId { get; set; }

    public void OnGet()
    {
        var vnp_ResponseCode = HttpContext.Request.Query["vnp_ResponseCode"];
        TransactionId = HttpContext.Request.Query["vnp_TransactionNo"];

        // Check the response code from VNPay
        if (vnp_ResponseCode == "00")
        {
            PaymentStatus = "Payment successful!";
        }
        else
        {
            PaymentStatus = "Payment failed or was canceled.";
        }
    }
}
