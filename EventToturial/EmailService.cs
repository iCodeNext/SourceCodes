namespace EventToturial;
internal class EmailService
{
    public EmailService()
    {
        //Stock.OnPriceChanged += Send;
    }
    public void Send(string message)
    {
        Console.WriteLine($"send email to all users: new message: {message}");
    }
}
