using P0Model;

namespace P0DL
{
    public interface ICRepository
    {
        Customer AddCustomer(Customer c_customer);

         Orders AddOrder(Orders o_order);

        List<Orders> GetAllOrders();

        Orders GetOrderbyPrice();

        void AlterOrderPrice(int _orderID, double _totalPrice);

        void DeleteOrder();

        List<SmoothieModel> GetSmoothieByCustomer(int c_cusID);

        List<SmoothieModel> GetOrderByCustomer(int o_orderID);

        List<Orders> GetAllOrdersByCustomer(int c_cusID);

        List<Orders> GetAllOrdersByStore(int s_storeID);

        List<SmoothieModel> GetSmoothieByStore(int s_stoID);

        List<Customer> GetAllCustomers();


    }
}