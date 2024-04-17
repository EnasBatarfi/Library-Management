public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string successMsg)
    {
        Console.WriteLine($"Email Message: Dear Library Team,\n\nWe are delighted to inform you that the following action was completed successfully: {successMsg}.\n\nThank you for your contribution! Should you have any questions, feedback, or need further assistance, please don't hesitate to contact us at support@library.com.\n\nSincerely,\nThe Library Support Team\n\n");
    }

    public void SendNotificationOnFailure(string failureMsg)
    {
        Console.WriteLine($"Email Message: Dear Library Team,\n\nWe regret to inform you that we encountered an issue while processing the following action: {failureMsg}.\n\nPlease review the input data and try again. If the problem persists, our team is here to help! Contact us directly at support@library.com.\n\nSincerely,\nThe Library Support Team\n\n");

    }


}
