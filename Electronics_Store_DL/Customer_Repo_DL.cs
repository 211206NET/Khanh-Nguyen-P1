using Models;
using Microsoft.Data.SqlClient;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace RepoDL;

public class Customer_Repo : DL_Interface
{
    public bool duplicate = false;
    public bool success = false;
    
    private string _connectionString;

    public Customer_Repo ()
    {
        _connectionString = File.ReadAllText ("Connection.txt");
    }

    public Customer_Repo(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<ActionResult<Customer>> SignIn (Customer cust)
    {
        string _email;
        string _password;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string querystatement = "SELECT CustomerID, Email, Pass FROM Customer WHERE Email = @email AND Pass = @pass";
            using(SqlCommand comd = new SqlCommand(querystatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@email", cust.email);
                comd.Parameters.Add(param);
                param = new SqlParameter("@pass", cust.password);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    if(await reader.ReadAsync())
                    {
                        _email = reader.GetString(1);
                        _password = reader.GetString(2);
                        if (cust.email == _email && cust.password == _password)
                        {
                            cust.customerId = reader.GetInt32(0);
                        }  
                    }
                }
            }
            conn.Close();
        }
        return cust;
    }

    public async Task<List<Store>> GetAllStores ()
    {
        
        List<Store> storeList = new List<Store> ();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Store";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while ( await reader.ReadAsync())
                    {
                        Store store = new Store ();
                        store.StoreId = reader.GetInt32(0);
                        store.storeName = reader.GetString(1);
                        storeList.Add(store);
                    }
                }
            }
            
        }
        return storeList;
    }

    public async Task<List<Inventory>> GetInventoryByStoreId (int stId)
    {
        List<Inventory> storeInventoryList = new List<Inventory> ();
        int _storeId = stId;
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT * FROM Inventory WHERE storeID = @storeId";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@storeId", _storeId);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (await reader.ReadAsync())
                    {
                        Inventory item = new Inventory ();
                        item.storeId = reader.GetInt32(0);
                        item.productId = reader.GetInt32(1);
                        item.productName = reader.GetString(2);
                        item.quantity = reader.GetInt32(3);
                        item.unitPrice = reader.GetDecimal(4);
                        storeInventoryList.Add(item);
                    }
                }
            }
            
        }
        return storeInventoryList;
    }

    public decimal GetProductPriceById (int pId, int sId)
    {
        Inventory item = new Inventory ();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            String queryString = "SELECT price FROM Inventory WHERE productId = @pId AND storeID = @sId";
            using (SqlCommand comd = new SqlCommand(queryString, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@pId", pId);
                comd.Parameters.Add(param);
                param = new SqlParameter("@sId", sId);
                comd.Parameters.Add(param);
                using (SqlDataReader reader = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item.unitPrice = reader.GetDecimal(0);
                    }
                }
            }
            
        }
        return item.unitPrice;
    }

    public Order CreateOrder (Customer customer, Store store)
    {
        Order order = new Order();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO Orders (storeId, customerId) VALUES (@sId, @cId)";
            string querystatement = "SELECT TOP 1 orderId FROM Orders ORDER BY orderId DESC";
            using(SqlCommand comd = new SqlCommand(insertstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter ("@sId", store.StoreId);
                comd.Parameters.Add(param);
                param = new SqlParameter ("@cId", customer.customerId);
                comd.Parameters.Add (param);
                comd.ExecuteNonQuery();
            }
            using (SqlCommand comd = new SqlCommand(querystatement, conn))
            {
                using (SqlDataReader reader  = comd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order.orderId = reader.GetInt32(0);
                    }
                }
            }
            conn.Close();
        }
        return order;
    }

    public void Checkout (Order od, List<OrderItem> itemList)
    {
        Order order = new Order ();
        List<OrderItem> itemInCart = new List<OrderItem> ();
        itemInCart = itemList;
        order = od;
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            foreach(OrderItem item in itemInCart)
            {
                string insertstatement = "INSERT INTO OrderItem (orderId, productId, customerId, storeId, unit_price, quantity) VALUES (@ordId, @pId, @cId, @sId, @price, @qty)";
                using(SqlCommand comd = new SqlCommand (insertstatement, conn))
                {
                    SqlParameter param;
                    param = new SqlParameter("@ordId", order.orderId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@pId", item.proId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@cId", item.customerId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@sId", item.storeId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@price", item.unitPrice);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@qty", item.quantity);
                    comd.Parameters.Add(param);
                    comd.ExecuteNonQuery();
                }
            }
            conn.Close();
            success = true;
        }
    }

    public void UpdateInventory (List<OrderItem> itemInCart)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            foreach(OrderItem item in itemInCart)
            {
                int cur_quantity = 0;
                int new_quantity = 0;
                string querystatement = "SELECT quantity FROM Inventory WHERE productId = @pId  AND storeId = @stId ";
                using(SqlCommand comd = new SqlCommand(querystatement, conn))
                {
                    SqlParameter param;
                    param = new SqlParameter("@pId", item.proId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@stId", item.storeId);
                    comd.Parameters.Add(param);
                    using(SqlDataReader reader = comd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            cur_quantity = reader.GetInt32(0);
                        }
                        new_quantity = cur_quantity - item.quantity;
                    }
                }
                string updatestatement = "UPDATE Inventory SET quantity = @qty WHERE productId = @pId AND storeId = @stId ";
                using(SqlCommand comd = new SqlCommand(updatestatement, conn))
                {
                    SqlParameter param;
                    param = new SqlParameter("@qty", new_quantity);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@pId", item.proId);
                    comd.Parameters.Add(param);
                    param = new SqlParameter("@stId", item.storeId);
                    comd.Parameters.Add(param);
                    comd.ExecuteNonQuery();
                }
            }
        }
    }

    public bool CheckExistCustomer(Customer cust)
    {
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string searchstatement = "SELECT * FROM Customer WHERE Email = @email";
            using(SqlCommand comd = new SqlCommand(searchstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@email", cust.email);
                comd.Parameters.Add(param);
                using(SqlDataReader reader = comd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        duplicate = true;
                    }
                }
            }
            conn.Close();
        }
        return true;
    }

    public void CreateCustomer (Customer cust)
    {
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string insertstatement = "INSERT INTO CUSTOMER (firstName, lastName, Street, Apt, City, State_Province, Zip, Email, Pass)  VALUES (@fname, @lname, @street, @apt, @city, @state, @zip, @email, @password)";
            using(SqlCommand comd = new SqlCommand(insertstatement, conn))
            {
                SqlParameter param;
                param = new SqlParameter("@fname", cust.firstName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@lname", cust.lastName);
                comd.Parameters.Add(param);
                param = new SqlParameter("@street", cust.streetNumber);
                comd.Parameters.Add(param);
                param = new SqlParameter("@apt", cust.apt);
                comd.Parameters.Add(param);
                param = new SqlParameter("@city", cust.city);
                comd.Parameters.Add(param);
                param = new SqlParameter("@state", cust.state);
                comd.Parameters.Add(param);
                param = new SqlParameter("@zip", cust.zip);
                comd.Parameters.Add(param);
                param = new SqlParameter("@email", cust.email);
                comd.Parameters.Add(param);
                param = new SqlParameter("@password", cust.password);
                comd.Parameters.Add(param);
                comd.ExecuteNonQuery();
            }
            conn.Close();
            success = true;
        }
    }

    //Staff functions non-implemented
    public async Task<ActionResult<Staff>> SignIn(Staff staff) {return staff; }
    public async Task<List<Inventory>> GetAllInventory() 
    {
        List<Inventory> inv = new List<Inventory>();
        return inv;
    }
    public void Replenishment(Inventory item) { }
    public bool CheckExistStaff(Staff emp) { return false; }
    public void NewEmployee(Staff emp) { }
}