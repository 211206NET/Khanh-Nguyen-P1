using Microsoft.AspNetCore.Mvc;
using Models;
namespace ESLogic;

public interface BL_Interface
{
    //Customer functions
    Task<ActionResult<Customer>> CustomerSignIn (Customer cust);
    void Checkout(Customer cus, Store st, List<OrderItem> il);
    void SignUp (Customer cust);

    //Staff functions
    Task<ActionResult<Staff>> StaffSignIn (Staff staff);
    Task<List<Inventory>> GetAllStoreInventory ();
    void FillInventory(Inventory item);
    void NewEmployee(Staff staff);

    //Common Functions
    Task<List<Store>> GetAllStores();
    Task<List<Inventory>> GetStoreInventory (int stId);
}