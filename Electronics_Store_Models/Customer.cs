namespace Models;
public class Customer
{
    private int _customerId;
    public int customerId
    {
        get => _customerId;
        set => _customerId = value;
    }
    
    private String _lastName; 
    public String lastName
    { 
        get => _lastName; 
        set => _lastName = value; 
    }

    private String _firstName;
    public String firstName
    { 
        get => _firstName; 
        set => _firstName = value; 
    }

    private String _streetNumber;
    public String streetNumber
    { 
        get => _streetNumber; 
        set => _streetNumber = value; 
    }

    private String ? _apt;
    public String apt 
    {
        get => _apt;
        set => _apt = value;
    }

    private String _city;
    public String city
    { 
        get => _city; 
        set => _city = value; 
    }
    private String _state;
    public String state
    { 
        get => _state; 
        set => _state = value; 
    }

    private String _zip;
    public String zip
    { 
        get => _zip; 
        set => _zip = value; 
    }

    private String _email;
    public String email
    {
        get => _email;
        set => _email = value;
    }

    private String _password;
    public String password
    {
        get => _password;
        set => _password = value;
    }
    
}