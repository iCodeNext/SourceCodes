namespace EventToturial;
internal class EmailService
{
    public void Send(object sender, MessageEventArgs message)
    {
        Console.WriteLine($"Email with {message.Text} text");
    }
}
