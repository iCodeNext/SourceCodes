using System.Diagnostics;

namespace EventToturial;
public class Stock
{
    public event EventHandler<MessageEventArgs> PriceChanged;

    protected virtual void OnPriceChanged(MessageEventArgs e)
    {
        PriceChanged?.Invoke(this, e);
    }
    
    public int Price { get; set; }

    public void Update(int price)
    {
        Price = price;
        OnPriceChanged(new MessageEventArgs($"new Price is : {price}"));
    }

}

public class MessageEventArgs(string text) : EventArgs
{
    public readonly string Text = text;
}