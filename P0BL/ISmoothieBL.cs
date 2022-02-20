using P0Model;

namespace P0BL;
public interface ISmoothieBL
{
/// <summary>
/// Will add smoothie data to the database
/// </summary>
/// <param name="_smoothie"></param>
/// <returns></returns>
void AddSmoothie(SmoothieModel _smoothie, int productID, int _howmuchsmoothies);

List<SmoothieModel> SearchSmoothie(string s_name);

void ViewInventory(int _proID);

void AddInventory(int _proID);

void SubtractInventory(int _proID);
}
