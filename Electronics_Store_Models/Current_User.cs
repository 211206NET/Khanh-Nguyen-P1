namespace Models;

public static class Current_User
{
    public static int User_Id = 0;
    public static int store_Id = 0;
    public static int order_Id = 0;
    public static List<OrderItem> shoppingList = new List<OrderItem> ();
}