namespace P0Model
{
    public class Ingredients
    {
        public int inID { get; set; }

        public string Name { get; set; }

        public Ingredients(string Name)
        {
            this.Name = Name;
        }
    }
}