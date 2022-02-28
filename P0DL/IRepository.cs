using P0Model;

namespace P0DL;
public interface IRepository
{
    /// <summary>
    /// Adds a smoothie to the database
    /// </summary>
    /// <param name="_smoothie"></param>
    /// <returns></returns>
SmoothieModel AddSmoothie(SmoothieModel _smoothie);

List<SmoothieModel> GetAllSmoothie();

List<Product> GetAllProduct();

void AddInventory(int _proID, int quantity);

void SubtractInventory(int _proID, int quantity);
}
