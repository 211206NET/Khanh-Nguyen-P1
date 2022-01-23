using Microsoft.AspNetCore.Mvc;
using Models;
using RepoDL;
namespace ESLogic;

public class Customer_BL : BL_Interface
{
    public bool isSignedIn = false;
    private DL_Interface cRepo;

    public Customer_BL (DL_Interface crepo)
    {
        cRepo = crepo;
    }
    
    public async Task<ActionResult<Customer>> CustomerSignIn (Customer cus)
    {
        return await cRepo.SignIn(cus);
    }

    public async Task<List<Store>> GetAllStores ()
    {
        return await cRepo.GetAllStores();
    }

    public async Task<List<Inventory>> GetStoreInventory (int stId)
    {
        return await cRepo.GetInventoryByStoreId(stId);
    }

    public void Checkout(Customer cus, Store st, List<OrderItem> cartItems)
    {   //Order order = new Order();
        Customer customer = new Customer ();
        Store store = new Store ();
        List<OrderItem> itemInCart = new List<OrderItem> ();
        customer = cus;
        store = st;
        itemInCart = cartItems;
        cRepo.Checkout(cRepo.CreateOrder(customer,  store), itemInCart);
        cRepo.UpdateInventory(itemInCart);
    }

    public void SignUp (Customer cus)
    {
        if(cRepo.CheckExistCustomer(cus) != true)
        {
            cRepo.CreateCustomer(cus);
        }

    }

    //Staff functions non-impolememted
    public async Task<ActionResult<Staff>> StaffSignIn(Staff staff) {return staff; }
    public async Task<List<Inventory>> GetAllStoreInventory() 
    {
        List<Inventory> invList = new List<Inventory> ();
        return invList;
    }
    public void FillInventory(Inventory item) { }
    public void NewEmployee(Staff staff) { }
}