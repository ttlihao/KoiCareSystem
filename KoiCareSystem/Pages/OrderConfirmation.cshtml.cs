using Microsoft.AspNetCore.Mvc.RazorPages;

public class OrderConfirmationModel : PageModel
{
    public string PaymentStatus { get; set; }
    public string TransactionId { get; set; }

    public void OnGet()
    {
        // Set the PaymentStatus to success message unconditionally
        PaymentStatus = "Payment successful!";

        // Optional: You can also remove the TransactionId if it's not needed
        TransactionId = HttpContext.Request.Query["vnp_TransactionNo"];
    }
}
