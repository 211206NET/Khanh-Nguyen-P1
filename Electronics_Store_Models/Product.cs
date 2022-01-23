namespace Models;
public class Product
{
    private int _productId;
    public int productId
    { 
        get => _productId; 
        set => _productId = value; 
    }

    private String _productName; 
    public String productName
    { 
        get => _productName; 
        set => _productName = value; 
    } 

    private String _productDescription; 
    public String productDescription
    { 
        get => _productDescription; 
        set => _productDescription = value; 
    } 

    private decimal _productPrice; 
    public decimal productPrice
    { 
        get => _productPrice; 
        set => _productPrice = value; 
    }  
}