using P0Model;

namespace P0BL
{
    public interface ICustomerBL
    {
        /// <summary>
        /// will add customer to database.
        /// </summary>
        /// <param name="c_customer"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer c_customer);

        Orders AddOrder(Orders o_order);

        List<Orders> GetAllOrders();

        Orders GetOrderbyPrice();

        List<SmoothieModel> GetOrderByCustomer(int o_orderID);

        List<Orders> GetAllOrdersByCustomer(int c_cusID);

        List<Orders> GetAllOrdersByCustomerbyPrice(int c_cusID);

        List<Orders> GetAllOrdersByStore(int s_storeID);

        void DeleteOrder(int orderID);

        void AlterOrderPrice(int _orderID, double _totalPrice);

        List<Customer> GetAllCustomers();

        List<SmoothieModel> GetSmoothieByCustomer(int c_cusID);

        List<SmoothieModel> GetSmoothieByStore(int s_stoID);

        List<Customer> SearchCustomer(string c_name);

        Customer SearchSpecificCustomer(string c_email);




    }
}