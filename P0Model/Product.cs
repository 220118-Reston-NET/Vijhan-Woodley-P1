namespace P0Model
{
    public class Product
    {
       // public string Name { get; set; }
        public int proID { get; set; }
        public double Price { get; set; }
        public string CupSize { get; set; }

        public string storeName { get; set; }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public Product(){
            
        }
        
        public Product(string CupSize)
        {
            
            this.CupSize = CupSize;
            if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
            {
                Price = 5.00;
            }   else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
            {
                Price = 6.50;
            }   else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
            {
                Price = 7.00;
            }   else 
            {
                throw new Exception("Cupsize can be small, medium or large");
            }
            
        }

    }
}