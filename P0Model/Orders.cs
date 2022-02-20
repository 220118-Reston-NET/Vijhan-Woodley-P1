namespace P0Model
{
    public class Orders
    {
        public int OrderID { get; set; }

        public int fcustomer { get; set; }

        public int fstore { get; set; }
        private List<SmoothieModel> _listOfSmoothies;
        public List<SmoothieModel> ListOfSmoothies
        {
            get { return _listOfSmoothies; }
            set { _listOfSmoothies = value; }
        }
        

        public double totalPrice { get; set; }
        

        public Orders()
        {
            
           _listOfSmoothies = new List<SmoothieModel>()
            {
                new SmoothieModel()
            }; 
        }

         public void AddSmoothie(SmoothieModel _smoothie, int howmanysmoothies)
        {
            for (int i = 0; i < howmanysmoothies; i++)
            {
                _listOfSmoothies.Add(_smoothie);
            }
            
            
        }
    }
}