namespace P0Model;
public class SmoothieModel
{


public int SmoID { get; set; }
public string Name { get; set; }

public int fcustomer { get; set; }

public int fstore { get; set; }

public int forder { get; set; }

private int _comboNumb;
public int ComboNumb
{
    get { return _comboNumb; }
    set { _comboNumb = value; }
}

private List<Product> _product;
public List<Product> Product
{
    get { return _product; }
    set { _product = value; }
}


public string CupSize { get; set; }



private List<Ingredients> _ingredients;
public List<Ingredients> Ingredients
{   
    get { return _ingredients; }
    set { _ingredients = value; }
}

private double _price;
public double Price
{
    get { return _price; }
    set { _price = value; }
}

private int _quantity;
public int Quantity
{
    get { return _quantity; }
    set { _quantity = value; }
}

public SmoothieModel()
{

}

public SmoothieModel(int ComboNumb)
{
    
    this._comboNumb = ComboNumb;

    _ingredients = new List<Ingredients>();
    Ingredients Coconut = new Ingredients("Coconut");
    Ingredients Banana = new Ingredients("Banana");
    Ingredients Spinach = new Ingredients("Spinach");
    Ingredients Pinapple = new Ingredients("Pinapple");
    Ingredients CoconutWater = new Ingredients("Coconut Water");
    Ingredients Strawberry = new Ingredients("Strawberry");
    Ingredients Blueberry = new Ingredients("Blueberry");
    Ingredients Raspberry = new Ingredients("Raspberry");
    Ingredients Almondmilk = new Ingredients("Almondmilk");
    Ingredients Mango = new Ingredients("Mango");
    Ingredients PassionFruit = new Ingredients("Passion Fruit");
    Ingredients ChocolatePowder = new Ingredients("Chocolate Powder");
    Ingredients ProtienPowder = new Ingredients("Protien Powder");
    
switch (ComboNumb)
{
    case 1 : 
    Name = "CoconutFusion";
    
    
     _ingredients.Add(Coconut);
     _ingredients.Add(Banana);
     _ingredients.Add(Spinach);
     _ingredients.Add(Pinapple);
     _ingredients.Add(CoconutWater);
    break;
    case 2 : 
    Name = "VeryBerry";
    
    
     _ingredients.Add(Strawberry);
     _ingredients.Add(Blueberry);
     _ingredients.Add(Spinach);
     _ingredients.Add(Raspberry);
     _ingredients.Add(Almondmilk);
    break;
    case 3 : 
    Name = "TropicalBreeze";
    
    
     _ingredients.Add(Mango);
     _ingredients.Add(PassionFruit);
     _ingredients.Add(Spinach);
     _ingredients.Add(Pinapple);
     _ingredients.Add(CoconutWater);
    break;
    case 4 : 
    Name = "ProtienShake";
    
    
     _ingredients.Add(ChocolatePowder);
     _ingredients.Add(Banana);
     _ingredients.Add(Spinach);
     _ingredients.Add(ProtienPowder);
     _ingredients.Add(Almondmilk);
    break;
    default:
    throw new Exception("Choose combo number from 1 - 4.");
    //break;
}

}

public SmoothieModel(int ComboNumb, string Cupsize, int Quantity)
{
    this._quantity = Quantity;
    this.CupSize = Cupsize;
    this.ComboNumb = ComboNumb;
    _ingredients = new List<Ingredients>();
Ingredients Coconut = new Ingredients("Coconut");
    Ingredients Banana = new Ingredients("Banana");
    Ingredients Spinach = new Ingredients("Spinach");
    Ingredients Pinapple = new Ingredients("Pinapple");
    Ingredients CoconutWater = new Ingredients("Coconut Water");
    Ingredients Strawberry = new Ingredients("Strawberry");
    Ingredients Blueberry = new Ingredients("Blueberry");
    Ingredients Raspberry = new Ingredients("Raspberry");
    Ingredients Almondmilk = new Ingredients("Almondmilk");
    Ingredients Mango = new Ingredients("Mango");
    Ingredients PassionFruit = new Ingredients("Passion Fruit");
    Ingredients ChocolatePowder = new Ingredients("Chocolate Powder");
    Ingredients ProtienPowder = new Ingredients("Protien Powder");
    
switch (ComboNumb)
{
    case 1 : 
    Name = "CoconutFusion";
    
    
     _ingredients.Add(Coconut);
     _ingredients.Add(Banana);
     _ingredients.Add(Spinach);
     _ingredients.Add(Pinapple);
     _ingredients.Add(CoconutWater);
    break;
    case 2 : 
    Name = "VeryBerry";
    
    
     _ingredients.Add(Strawberry);
     _ingredients.Add(Blueberry);
     _ingredients.Add(Spinach);
     _ingredients.Add(Raspberry);
     _ingredients.Add(Almondmilk);
    break;
    case 3 : 
    Name = "TropicalBreeze";
    
    
     _ingredients.Add(Mango);
     _ingredients.Add(PassionFruit);
     _ingredients.Add(Spinach);
     _ingredients.Add(Pinapple);
     _ingredients.Add(CoconutWater);
    break;
    case 4 : 
    Name = "ProtienShake";
    
    
     _ingredients.Add(ChocolatePowder);
     _ingredients.Add(Banana);
     _ingredients.Add(Spinach);
     _ingredients.Add(ProtienPowder);
     _ingredients.Add(Almondmilk);
    break;
    default:
    throw new Exception("Choose combo number from 1 - 4.");
    //break;
}

if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 5.00 * (double)_quantity;
} else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 6.50 * (double)Quantity;
} else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 7.00 * (double)Quantity;
}/* else 
{
    throw new Exception("Cupsize can be small, medium or large");
}*/
}

public SmoothieModel(string Cupsize)
{
    this.CupSize = CupSize;
    /*Product _pro = new Product(Cupsize);
    Price = _pro.Price;*/
    if(string.Equals(CupSize, "small", StringComparison.CurrentCultureIgnoreCase))
{
        Price = 5.00;
} else if (string.Equals(CupSize, "medium", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 6.50;
} else if (string.Equals(CupSize, "large", StringComparison.CurrentCultureIgnoreCase))
{
    Price = 7.00;
} else 
{
    throw new Exception("Cupsize can be small, medium or large");
}
}

public override string ToString()
{
    return $"Name : {Name}\nCup size : {CupSize}\nPrice : ${Price}";
}

}
