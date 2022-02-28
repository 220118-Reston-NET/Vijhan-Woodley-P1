using P0Model;

namespace P0BL;
public interface ISmoothieBL
{
/// <summary>
/// Will add smoothie data to the database
/// </summary>
/// <param name="_smoothie"></param>
/// <returns></returns>
SmoothieModel AddSmoothie(SmoothieModel _smoothie, int productID);

List<SmoothieModel> SearchSmoothie(string s_name);

void ViewInventory(int _proID);

List<Product> GetAllProduct();

void AddInventory(int _proID, int quantity);

void SubtractInventory(int _proID, int quantity);
}
