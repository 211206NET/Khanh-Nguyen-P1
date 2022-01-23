namespace Models;

public class Inventory
{
    private int _storeId;
    public int storeId
    {
        get => _storeId;
        set => _storeId = value;
    }
    private int _productId;
    public int productId
    {
        get => _productId;
        set => _productId = value;
    }
    private string _productName;
    public String productName
    {
        get => _productName;
        set => _productName = value;
    }
    private int _quantity;
    public int quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    private decimal _unitPrice;
    public decimal unitPrice
    {
        get => _unitPrice;
        set => _unitPrice = value;
    }
}