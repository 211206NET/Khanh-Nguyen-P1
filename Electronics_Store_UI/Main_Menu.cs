using ESLogic;
namespace Menus;

public class Main_Menu : IMenu
{
    private string _input = "";
    private Customer_BL clogic;
    public void DisplayMenu ()
    {
        Console.WriteLine ("Welcome to Electronics Store");
        Console.WriteLine ("Please select a Menu to start");
        Console.WriteLine ("1 - Sign In" );
        Console.WriteLine ("2 - Sign Up" );
        Console.WriteLine ("0 - Exit");

        _input = Console.ReadLine ();
        
            switch(_input)
            {
                case "1":
                {
                    SignInOption oMenu = new SignInOption ();
                    oMenu.DisplayMenu();
                }
                break;
                case "2":
                {
                    clogic.SignUp();
                    DisplayMenu ();
                }
                break;
                case "0":
                {
                    Console.WriteLine ("Good Bye !!!");
                }
                break;
                default:
                break;
            }
    }

}