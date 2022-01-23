namespace Models;
public class Store 
{
    private int _storeId;
    public int StoreId
     { 
         get => _storeId; 
         set => _storeId = value; 
     }

    private String _storeName;
    public String storeName
    { 
        get => _storeName; 
        set => _storeName = value;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}