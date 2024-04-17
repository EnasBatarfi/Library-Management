public class SMSNotificationService : INotificationService
{


    public void SendNotificationOnSuccess(string successMsg)
    {
        Console.WriteLine($"SMS: The following action was completed successfully: {successMsg}. Thank you and Have a nice day!");
    }

    public void SendNotificationOnFailure(string failureMsg)
    {
        Console.WriteLine($"SMS: We encountered an issue while processing the following action: {failureMsg}. Please reach out to support@library.com for assistance.");
    }
}


