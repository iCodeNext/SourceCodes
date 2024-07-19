namespace EventToturial;
public class Stock
{
    public event Action<string> OnPriceChanged;

    public int Price { get; set; }

    public void Update(int price)
    {
        Price = price;
        OnPriceChanged?.Invoke($"new Price is : {price}");
    }
}
