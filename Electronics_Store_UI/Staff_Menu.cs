using Models;
using ESLogic;
namespace Menus;

public class Staff_Menu : IMenu
{
    private Main_Menu mMenu;
    private Staff_BL slogic;

    private string _input = "";

    public void DisplayMenu ()
    {
        Console.WriteLine ("Please select a Menu to continue");
        Console.WriteLine ("1 - Show Store List" );
        Console.WriteLine ("2 - Set Store" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - View All Inventories" );
        Console.WriteLine ("5 - Replenishment" );
        Console.WriteLine ("6 - Add New Employee" );
        Console.WriteLine ("0 - Sign Out");

        _input = Console.ReadLine ();


        switch(_input)
        {
            case "1":
            {
                slogic.GetAllStores ();
                DisplayMenu ();
            }
            break;
            case "2":
            {
                slogic.SetStore ();
                DisplayMenu ();
            }
            break;
            case "3":
            {
                if(Current_User.store_Id == 0)
                {
                    slogic.SetStore();
                }
                slogic.GetStoreInventory (Current_User.store_Id);
                DisplayMenu ();
            }
            break;
            case "4":
            {
                slogic.GetAllStoreInventory ();
                DisplayMenu ();
            }
            break;
            case "5":
            {
                if(Current_User.store_Id == 0)
                {
                    slogic.SetStore();
                }
                slogic.FillInventory ();
                DisplayMenu ();
            }
            break;
            case "6":
            {
                slogic.NewEmployee ();
                DisplayMenu ();
            }
            break;
            case "0":
            {
                Current_User.order_Id = 0;
                Current_User.store_Id = 0;
                Current_User.User_Id = 0;
                Current_User.shoppingList.Clear ();
                mMenu.DisplayMenu ();
            }
            break;
            default:
                DisplayMenu ();
            break;
        }
    }
}