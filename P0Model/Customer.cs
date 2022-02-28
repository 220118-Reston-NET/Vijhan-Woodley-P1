namespace P0Model{

    public class Customer
    {
        public int cusID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string passwordd { get; set; }

        private List<SmoothieModel> _smoothies;
        public List<SmoothieModel> Smoothies
        {
            get { return _smoothies; }
            set { _smoothies = value; }
        }
        

        private int _age;
        public int Age
        {
            get { return _age; }
            set { 
                if(value > 0)
                {_age = value;}
                else 
                {
                    throw new Exception("Age cannot be less than 1.");
                } }
        }
        

        public Customer()
        {

        }
        public Customer(string Name, string email, int Age)
        {
            this.Name = Name;
            Email = email + "@gmail.com";
            this.Age = Age;
            _smoothies = new List<SmoothieModel>()
            {
                new SmoothieModel()
            };

        }

         public void AddSmoothie(SmoothieModel _smoothie)
        {
        
            _smoothies.Add(_smoothie);
            
        }

        public override string ToString()
        {
            return $"Name : {Name}\nEmail : {Email}\nAge : {Age} years old.";
        }
    }
}