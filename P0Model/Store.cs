namespace P0Model
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        private List<SmoothieModel> _listOfSmoothie;
        public List<SmoothieModel> ListOfSmoothie
        {
            get { return _listOfSmoothie; }
            set { _listOfSmoothie = value; }
        }
        
        private List<Orders> _listOfOrders;
        public List<Orders> ListOfOrders
        {
            get { return _listOfOrders; }
            set { _listOfOrders = value; }
        }
        
        public Store()
        {

        }

        public Store(string Name)
        {
            this.Name = Name;
        
             _listOfSmoothie = new List<SmoothieModel>()
            {
                new SmoothieModel()
            };
            _listOfOrders = new List<Orders>()
            {
                new Orders()
            };
        }

        public void AddSmoothie(SmoothieModel _smoothie)
        {
            
            _listOfSmoothie.Add(_smoothie);
            
        }

         public void AddOrder(Orders _orders)
        {
            _listOfOrders.Add(_orders);
            
        }
    }

}