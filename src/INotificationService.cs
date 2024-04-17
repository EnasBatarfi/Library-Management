public interface INotificationService
{
    void SendNotificationOnSuccess(string successMsg);
    void SendNotificationOnFailure(string failureMsg);


}