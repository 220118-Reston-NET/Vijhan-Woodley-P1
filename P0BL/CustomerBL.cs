using P0DL;
using P0Model;

namespace P0BL
{
    public class CustomerBL : ICustomerBL
    {
        private ICRepository _crepo;
        public CustomerBL(ICRepository p_crepo)
        {
            _crepo = p_crepo;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            List<Customer> CustomerList = _crepo.GetAllCustomers();
            foreach (Customer item in CustomerList)
            {
                if (item.Email != c_customer.Email)
                {
                    return _crepo.AddCustomer(c_customer);
                }
                else
                {
                    throw new Exception("The email entered already exists.");
                }
            }
            return _crepo.AddCustomer(c_customer);
        }

        public Orders AddOrder(Orders o_order)
        {
            return _crepo.AddOrder(o_order);
        }

        public void AlterOrderPrice(int _orderID, double _totalPrice)
        {
           _crepo.AlterOrderPrice(_orderID, _totalPrice);
        }

        public void DeleteOrder(int orderID)
        {
            _crepo.DeleteOrder(orderID);
        }

        public List<Customer> GetAllCustomers()
        {
            return _crepo.GetAllCustomers();
        }

        public List<Orders> GetAllOrders()
        {
           return _crepo.GetAllOrders();
        }

        public List<Orders> GetAllOrdersByCustomer(int c_cusID)
        {
            return _crepo.GetAllOrdersByCustomer(c_cusID);
        }

        public List<Orders> GetAllOrdersByCustomerbyPrice(int c_cusID)
        {
            return _crepo.GetAllOrdersByCustomerbyPrice(c_cusID);
        }

        public List<Orders> GetAllOrdersByStore(int s_storeID)
        {
            return _crepo.GetAllOrdersByStore(s_storeID);
        }

        public List<SmoothieModel> GetOrderByCustomer(int o_orderID)
        {
            return _crepo.GetOrderByCustomer(o_orderID);
        }

        public Orders GetOrderbyPrice()
        {
            return _crepo.GetOrderbyPrice();
        }

        public List<SmoothieModel> GetSmoothieByCustomer(int c_cusID)
        {
            return _crepo.GetSmoothieByCustomer(c_cusID);
        }

        public List<SmoothieModel> GetSmoothieByStore(int s_stoID)
        {
            return _crepo.GetSmoothieByStore(s_stoID);
        }

        public List<Customer> SearchCustomer(string c_name)
        {
            List<Customer> CustomerLists = _crepo.GetAllCustomers();
            List<Customer> CustomersFound = new List<Customer>();
           /* foreach (Customer item in CustomerLists)
            {
                Console.WriteLine(item.Name);
            }*/
            
            
            foreach (Customer item in CustomerLists)
            {
                string nam = item.Name;
                if (nam.Contains(c_name, StringComparison.CurrentCultureIgnoreCase))
                {
                    CustomersFound.Add(item);
                } 
            }
            if(CustomersFound.Count() == 0)
                {
                    throw new Exception("Customer with name " + c_name + " was not found.");
                }
            return CustomersFound;
        }

        public Customer SearchSpecificCustomer(string c_email)
        {
            List<Customer> CustomerLists = _crepo.GetAllCustomers();
            Customer _customer = new Customer();
            bool emailFound = false;
            foreach (Customer item in CustomerLists)
            {
                if (item.Email == c_email)
                {
                    _customer = item;
                    emailFound = true;
                    return _customer;
                }
                

            }
            if(!emailFound){
                throw new Exception("Customer email not found.");
            }
            return _customer;
        }
    }
}