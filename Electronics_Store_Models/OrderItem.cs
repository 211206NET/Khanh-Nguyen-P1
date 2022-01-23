namespace Models;
public class OrderItem 
{
    // Use this constructor to make itemInCart list
    public OrderItem()
    {
    }

    // Use this constructor to group orderitem base on order number
    public OrderItem( int oId, int cId, int sId, int pId, decimal uprice, int qty)
    {
        this._orderNumber = oId;
        this._customerId = cId;
        this._storeId = sId;
        this._prodId = pId;
        this._unitPrice = uprice;
        this._quanity = qty;
    }
    private int _orderNumber;
    public int orderNumber
    { 
        get => _orderNumber;
        set => _orderNumber = value;
    }

    private int _prodId;
    public int proId
    { 
        get => _prodId;
        set => _prodId = value;
    }

    private int _quanity;
    public int quantity
    { 
        get => _quanity;
        set => _quanity = value;
    }

    private decimal _unitPrice;
    public decimal unitPrice
    { 
        get => _unitPrice;
        set => _unitPrice = value;
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