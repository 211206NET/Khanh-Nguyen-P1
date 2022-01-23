using Models;
using ESLogic;
namespace Menus;

public class Customer_Menu : IMenu
{
    Main_Menu mMenu = new Main_Menu ();
    private Customer_BL clogic;
    private string _input = "   ";

    public Customer_Menu()
    {
    }

    public void DisplayMenu ()
    {
        Console.WriteLine ("Please select a Menu to continue");
        Console.WriteLine ("1 - Show Store List" );
        Console.WriteLine ("2 - Choose your Store" );
        Console.WriteLine ("3 - View Store Inventory");
        Console.WriteLine ("4 - Add to Cart" );
        Console.WriteLine ("5 - View Cart" );
        Console.WriteLine ("6 - Checkout" );
        Console.WriteLine ("0 - Sign Out");

        _input = Console.ReadLine ();


        switch(_input)
        {
            case "1":
            {
                clogic.GetAllStores ();
                DisplayMenu();
            }
            break;
            case "2":
            {
                clogic.SetStore ();
                DisplayMenu ();
            }
            break;
            case "3":
            {
                if(Current_User.store_Id == 0)
                {
                    clogic.SetStore();
                }
                clogic.GetStoreInventory (Current_User.store_Id);
                DisplayMenu ();
            }
            break;
            case "4":
            {
                if(Current_User.store_Id == 0)
                {
                    clogic.SetStore();
                }
                clogic.GetStoreInventory (Current_User.store_Id);
                clogic.AddToCart ();
                DisplayMenu ();
            }
            break;
            case "5":
            {
                Console.WriteLine("Your Cart");
                foreach(OrderItem item in Current_User.shoppingList)
                {
                    Console.WriteLine(item.proId.ToString() + "  " + item.quantity.ToString() + "  " + item.unitPrice.ToString());
                }
                DisplayMenu ();
            }
            break;
            case "6":
            {
                clogic.Checkout ();
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