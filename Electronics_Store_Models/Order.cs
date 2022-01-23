namespace Models;
public class Order
{
    private int _orderId;
    public int orderId
    {
        get => _orderId;
        set => _orderId = value;
    }
    private int _customerId;
    public int customerId
    {
        get => _customerId;
        set => _customerId = value;
    }
    private int _storeId;
    public int storeId
    {
        get => _storeId;
        set => _storeId = value;
    }
}