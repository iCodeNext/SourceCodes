namespace EventToturial;
public class SmsService
{

    public SmsService()
    {
        Stock.OnPriceChanged += Send;
    }
    public void Send(object sender,MessageEventArg @event)
    {
        // throw new NotImplementedException();
        Console.WriteLine($"send sms to all users: new message: {@event.Message}");
    }
}
