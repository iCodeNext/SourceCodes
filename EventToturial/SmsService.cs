namespace EventToturial;
public class SmsService
{
    public void Send(object sender,MessageEventArgs message)
    {
        
        Console.WriteLine($"sms Send with {message.Text} text");
    }
}
