namespace AdamS.OnlineStore.BusinessInterfaces
{
    public interface INotificationProvider
    {
        bool Send(string destination, string subject, string message);
    }
}