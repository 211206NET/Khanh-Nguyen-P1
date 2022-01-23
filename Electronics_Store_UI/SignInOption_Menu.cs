using ESLogic;
namespace Menus;

public class SignInOption : IMenu
{
    private string _input = "";
    private Customer_BL clogic;
    private Staff_BL slogic;
    private Main_Menu mMenu;
    private Customer_Menu cMenu;
    private Staff_Menu sMenu;
   
    public SignInOption ()
    {

    }
    public void DisplayMenu() 
    {
        Console.WriteLine ("1 - Customer Sign In" );
        Console.WriteLine ("2 - Staff Sign In");
        Console.WriteLine ("3 - Back");


        _input = Console.ReadLine ();

        switch (_input)
        {
            case "1":
            {
                clogic.CustomerSignIn ();
                if (clogic.isSignedIn == true)
                {
                    cMenu.DisplayMenu ();
                }
                else
                    clogic.CustomerSignIn ();
            }
            break;
            case "2":
            {
                slogic.StaffSignIn ();
                if(slogic.isSignedIn == true)
                {
                    sMenu.DisplayMenu ();
                }
                else
                    slogic.StaffSignIn ();
            }
            break;
            case "3":
            {
                mMenu.DisplayMenu ();
            }
            break;
            default:
            break;
        }
    }
}