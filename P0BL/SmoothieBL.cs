using P0DL;
using P0Model;

namespace P0BL {

public class SmoothieBL : ISmoothieBL
{
private IRepository _repo;
public SmoothieBL(IRepository p_repo)
{
    _repo = p_repo;
}

        public void AddInventory(int _proID)
        {
            _repo.AddInventory(_proID);
        }

        public void AddSmoothie(SmoothieModel _smoothie, int productID, int _howmuchsmoothies)
        {
            List<Product> ProductList = _repo.GetAllProduct();
           
            int quantity = ProductList[productID - 1].Quantity;
            
           // List<SmoothieModel> listOfSmoothies = _repo.GetAllSmoothie();
           for (int i = 0; i < _howmuchsmoothies; i++)
           {
               if (quantity < 1)
            {
                throw new Exception("No more inventory. Cannot order smoothie.");
            } else
            {
                 _repo.AddSmoothie(_smoothie);
            }
           }
            
            
        }

        public List<SmoothieModel> SearchSmoothie(string s_name)
        {
            List<SmoothieModel> listOfSmoothieSearch = _repo.GetAllSmoothie();
            List<SmoothieModel> SmoothieFound = new List<SmoothieModel>();
            foreach (SmoothieModel item in listOfSmoothieSearch)
            {
                if(item.Name.Contains(s_name, StringComparison.CurrentCultureIgnoreCase))
                {
                    
                    SmoothieFound.Add(item);
                    return SmoothieFound;
                } else
                {
                    throw new Exception("Object " + s_name + " was not found.");
                }
            }
            return SmoothieFound;
        }

        public void SubtractInventory(int _proID)
        {
            _repo.SubtractInventory(_proID);
        }

        public void ViewInventory(int _proID)
        {
            List<Product> ProductList = _repo.GetAllProduct();

            int quantity = ProductList[_proID - 1].Quantity;

            Console.WriteLine("The inventory for this store is " + quantity);
        }
    }
}