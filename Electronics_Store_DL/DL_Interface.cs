using Microsoft.AspNetCore.Mvc;
using Models;
namespace RepoDL;

public interface DL_Interface
{
    //Customer functions
     Task<ActionResult<Customer>> SignIn (Customer cust);
     decimal GetProductPriceById (int pId, int sId);
     Order CreateOrder (Customer cus, Store st);
     void Checkout (Order od, List<OrderItem> listItems);
     void UpdateInventory (List<OrderItem> listItems);
     bool CheckExistCustomer(Customer cust);
     void CreateCustomer (Customer cust);

    //Staff functions
     Task<ActionResult<Staff>> SignIn (Staff staff);
     Task<List<Inventory>> GetAllInventory ();
     void Replenishment (Inventory item);
     bool CheckExistStaff(Staff emp);
     void NewEmployee (Staff emp);

    //Common functions
    Task<List<Store>> GetAllStores ();
    Task<List<Inventory>> GetInventoryByStoreId (int stId);

}