using System.Data.SqlClient;
using System.Text.Json;
using P0Model;

namespace P0DL {


    public class Repository : IRepository
    {
        private readonly string _connectionStrings;
        private string _filepath = "../P0DL/Database/";
        private string _jsonString;

         public Repository(string c_connectionStrings)
        {
            _connectionStrings = c_connectionStrings;
        }

        public void AddInventory(int _proID, int quantity)
        {
           string SQLQuery = @"update Product set Quantity = Quantity + @quantity where proID = @proID";

           using(SqlConnection con = new SqlConnection(_connectionStrings))
           {
               con.Open();

               SqlCommand command = new SqlCommand(SQLQuery, con);
               command.Parameters.AddWithValue("@proID", _proID);
               command.Parameters.AddWithValue("@quantity", quantity);

               command.ExecuteNonQuery();
           }  
        }

        public SmoothieModel AddSmoothie(SmoothieModel _smoothie)
        {
            string SQLQuery = @"insert into SmoothieModel values(@Name, @ComboNumb, @CupSize, @Price, @fcustomer, @fstore, @forder, @Quantity)";

            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);
                command.Parameters.AddWithValue("@Name", _smoothie.Name);
                command.Parameters.AddWithValue("@ComboNumb", _smoothie.ComboNumb);
                command.Parameters.AddWithValue("@CupSize", _smoothie.CupSize);
                command.Parameters.AddWithValue("@Price", _smoothie.Price);
                command.Parameters.AddWithValue("@fcustomer", _smoothie.fcustomer);
                command.Parameters.AddWithValue("@fstore", _smoothie.fstore);
                command.Parameters.AddWithValue("@forder", _smoothie.forder);
                command.Parameters.AddWithValue("@Quantity", _smoothie.Quantity);

                command.ExecuteNonQuery();
            }
            /*string path = _filepath + "Smoothie.json";
            List<SmoothieModel> listOfSmoothies = GetAllSmoothie();
            listOfSmoothies.Add(_smoothie);
            _jsonString = JsonSerializer.Serialize(listOfSmoothies, new JsonSerializerOptions {WriteIndented = true});

            File.WriteAllText(path , _jsonString);*/

            return _smoothie;
        }

        public List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();

            string SQLQuery = @"select * from Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productList.Add(new Product(){
                        proID = reader.GetInt32(0),
                        Price = reader.GetDouble(1),
                        CupSize = reader.GetString(2),
                        storeName = reader.GetString(3),
                        Quantity = reader.GetInt32(4)
                    });
                }
            }
            return productList;
        }

        public List<SmoothieModel> GetAllSmoothie()
        {

            List<SmoothieModel> listOfSmoothies = new List<SmoothieModel>();

            string SQLQuery = @"select * from SmoothieModel";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfSmoothies.Add(new SmoothieModel(){
                        SmoID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ComboNumb = reader.GetInt32(2),
                        CupSize = reader.GetString(3),
                        Price = reader.GetDouble(4),
                        fcustomer = reader.GetInt32(5),
                        fstore = reader.GetInt32(6),
                        forder = reader.GetInt32(7),
                        Quantity = reader.GetInt32(8)
                    });
                }
            }
                return listOfSmoothies;

           /* _jsonString = File.ReadAllText(_filepath + "Smoothie.json");

            return JsonSerializer.Deserialize<List<SmoothieModel>>(_jsonString);*/
        }

        public void SubtractInventory(int _proID, int quantity)
        {
            string SQLQuery = @"update Product set Quantity = Quantity - @quantity where proID = @proID";

           using(SqlConnection con = new SqlConnection(_connectionStrings))
           {
               con.Open();

               SqlCommand command = new SqlCommand(SQLQuery, con);
               command.Parameters.AddWithValue("@proID", _proID);
               command.Parameters.AddWithValue("@quantity", quantity);

               command.ExecuteNonQuery();
           } 
        }
    }
}