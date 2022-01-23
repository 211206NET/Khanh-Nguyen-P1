using Microsoft.AspNetCore.Mvc;
using Models;
using RepoDL;
namespace ESLogic;

public class Staff_BL : BL_Interface
{
    public bool isSignedIn = false;
    private DL_Interface sRepo;

    public Staff_BL (DL_Interface srepo)
    {
        sRepo = srepo;
    }
    
    public async Task<ActionResult<Staff>> StaffSignIn (Staff staff)
    {
        return await sRepo.SignIn(staff);
    }

    public async Task<List<Store>> GetAllStores ()
    {
        List<Store> sList = new List<Store> ();
        sList = await sRepo.GetAllStores();
        return sList;
    }

    public async Task<List<Inventory>> GetStoreInventory (int stId)
    {
        List<Inventory> invList = new List<Inventory> ();
        invList =  await sRepo.GetInventoryByStoreId(stId);
        return invList;
    }

    public async Task<List<Inventory>> GetAllStoreInventory ()
    {
        List<Inventory> invList = new List<Inventory> ();
        invList = await sRepo.GetAllInventory();
        return invList;
    }

    public void FillInventory(Inventory item)
    {
        sRepo.Replenishment(item);
    }

    public void NewEmployee(Staff staff)
    {
        sRepo.CheckExistStaff(staff);
    }

    //CUstomer functions non-implemented
    public async Task<ActionResult<Customer>> CustomerSignIn(Customer cust) { return cust; }
    public void Checkout(int cId, int sId) { }
    public void SignUp(Customer cust) { }
}
