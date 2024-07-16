namespace EventToturial;
public class Stock
{
    //private readonly SmsService _smsService;
    //private readonly EmailService _emailService;
    //public delegate void PriceChangeDelegate(string message);
    public static event EventHandler<MessageEventArg> OnPriceChanged;
    public Stock()
    {
        //_smsService = new SmsService();
        //_emailService = new EmailService();
    }
    public int Price { get; set; }

    public void Update(int price)
    {
        Price = price;

        OnPriceChanged?.Invoke(this, new MessageEventArg { Message = $"new Price is : {price}" });
        //foreach (var handler in OnPriceChanged.GetInvocationList())
        //{
        //    try
        //    {
        //        handler.DynamicInvoke(EventArgs.Empty);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error");
        //    }
        //}
        //_smsService.Send($"new Price is : {price}");
        //_emailService.Send($"new Price is : {price}");
    }
}

public class MessageEventArg : EventArgs
{
    public string Message { get; set; }
}