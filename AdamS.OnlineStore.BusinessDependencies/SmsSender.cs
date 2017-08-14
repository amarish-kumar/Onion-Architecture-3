using AdamS.OnlineStore.BusinessInterfaces;

namespace AdamS.OnlineStore.BusinessDependencies
{
    public class SmsSender : INotificationProvider
    {
        public bool Send(string destination, string subject, string body)
        {
            //send sms message
            return true;
        }
    }

}