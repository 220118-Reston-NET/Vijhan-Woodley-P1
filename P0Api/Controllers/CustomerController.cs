using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P0BL;
using P0Model;
using Serilog;

namespace P0Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static List<SmoothieModel> tempSmoList = new List<SmoothieModel>();
        private static Customer _customer = new Customer();
        Store _storeBronx = new Store("SmoothieShackBronx");
        Store _storeMan = new Store("SmoothieShackMan");
        private static SmoothieModel _newSmoothie;
        Orders _order = new Orders();

        private ICustomerBL _cusBL;
        private ISmoothieBL _smoBL;

        public CustomerController(ICustomerBL c_cusBL, ISmoothieBL s_smoBL)
        {
            _cusBL = c_cusBL;
            _smoBL = s_smoBL;
        }
        // GET: api/P0
        /// <summary>
        /// Gets all customers from the sqldatatbase
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCustomer")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                
                return Ok(_cusBL.GetAllCustomers());
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            //return Ok(_cusBL.GetAllCustomers());
        }

      /*  [HttpGet("GetAllCustomer")]
        public IActionResult GetSmoothieMenu()
        {
            try
            {
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }*/



        /// <summary>
        /// Method allows customer to add sign up information.
        /// </summary>
        /// <param name="c_customer"></param>
        /// <returns></returns>
        [HttpPost("Add_Customer")]
        public IActionResult Post([FromBody] Customer c_customer)
        {
            try
            {
                Log.Information("Adding customer \n" + c_customer);
                return Ok(_cusBL.AddCustomer(c_customer));
            }
            catch (System.Exception)
            {
                Log.Warning("Unable to add customer");
                return Conflict();
            }
        }
        /// <summary>
        /// Method allows customer to add smoothie to cart.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="combonumber"></param>
        /// <param name="quantity"></param>
        /// <param name="Cupsize"></param>
        /// <returns></returns>
        [HttpPost("AddSmoothieToCart{email}/{password}/{combonumber}/{quantity}/{Cupsize}")]
        public IActionResult AddSmoothieToCart(string email, string password, int combonumber, int quantity, string Cupsize)
        {
            try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
            }
            catch (System.Exception)
            {
                Log.Warning("Unable to add smoothie to cart.");
                return NotFound("Customer not found.");
            }

            if(password == _customer.passwordd)
            {
                _newSmoothie = new SmoothieModel(combonumber, Cupsize, quantity);
                tempSmoList.Add(_newSmoothie);
                Log.Information("Smoothie added to cart \n" + _newSmoothie);

                return Ok(tempSmoList);
            }else
           {
               Log.Warning("Customer password incorrect.");
               return NotFound("Password incorrect");
           }
        }

        /// <summary>
        /// Allows customer to view cart
        /// </summary>
        /// <returns></returns>
        [HttpGet("ViewCart")]
        public IActionResult ViewCart()
        {
            Log.Information("Customer viewing cart.");
            return Ok(tempSmoList);
        }

        /// <summary>
        /// Allows customer to save smoothies in cart to an order.
        /// </summary>
        /// <param name="StoreId"></param>
        /// <returns></returns>
        [HttpPost("SaveOrder{StoreId}")]
        public IActionResult SaveOrder(int StoreId)
        {
            switch (StoreId)
            {
                case 1:
                _storeBronx.Address = "Bronx, NY";

                _storeBronx.StoreID = 1;
                _storeBronx.Name = "SmoothieShackBronx";

                _order.fcustomer = _customer.cusID;
                _order.fstore = 1;
                _order.totalPrice = 0;
                _order.datet = DateTime.Now;
                _cusBL.AddOrder(_order);
                _order = _cusBL.GetOrderbyPrice();

                foreach (SmoothieModel item in tempSmoList)
                {
                item.fcustomer = _customer.cusID;
                item.fstore = _storeBronx.StoreID;
                item.forder = _order.OrderID;
                 _customer.AddSmoothie(item);
                _storeBronx.AddSmoothie(item);
                _order.AddSmoothie(item);

                try
                {
                    Log.Information("Saving smoothie to order \n" + item);
                     _smoBL.AddSmoothie(item, 1);
                }
                catch (System.Exception exe)
                {
                    Log.Warning("Unable to save smoothie to order.");
                    _cusBL.DeleteOrder(_order.OrderID);
                    return Conflict(exe.Message);
                }

                _smoBL.SubtractInventory(1, item.Quantity); 
                
                
                }
                _storeBronx.AddOrder(_order);
                foreach (SmoothieModel item in _order.ListOfSmoothies)
                        {
                            if (item.Price > 0)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine("-------------------");
                            }
                            _order.totalPrice += item.Price;
                        }
                _cusBL.AlterOrderPrice(_order.OrderID, _order.totalPrice);
                tempSmoList.Clear();
                return Ok(_order);

                case 2:
                _storeBronx.Address = "Manhatten, NY";

                _storeBronx.StoreID = 2;
                _storeBronx.Name = "SmoothieShackMan";

                _order.fcustomer = _customer.cusID;
                _order.fstore = 2;
                _order.totalPrice = 0;
                _order.datet = DateTime.Now;
                _cusBL.AddOrder(_order);
                _order = _cusBL.GetOrderbyPrice();

                foreach (SmoothieModel item in tempSmoList)
                {
                item.fcustomer = _customer.cusID;
                item.fstore = _storeBronx.StoreID;
                item.forder = _order.OrderID;
                 _customer.AddSmoothie(item);
                _storeBronx.AddSmoothie(item);
                _order.AddSmoothie(item);
                
                
                try
                {
                    Log.Information("Saving smoothie to order \n" + item);
                     _smoBL.AddSmoothie(item, 2);
                }
                catch (System.Exception exe)
                {
                    Log.Warning("Unable to save smoothie to order.");
                    _cusBL.DeleteOrder(_order.OrderID);
                    return Conflict(exe.Message);
                }

                _smoBL.SubtractInventory(2, item.Quantity); 
                
                
                }
                _storeBronx.AddOrder(_order);
                foreach (SmoothieModel item in _order.ListOfSmoothies)
                        {
                            if (item.Price > 0)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine("-------------------");
                            }
                            _order.totalPrice += item.Price;
                        }
                _cusBL.AlterOrderPrice(_order.OrderID, _order.totalPrice);

                tempSmoList.Clear();
                return Ok(_order);

                default:
                return Conflict();
                
            }
        }

        /*[HttpPost("Order Smoothie{email}/{password}/{combonumber}/{quantity}/{Cupsize}/{StoreId}")]
        public IActionResult AddSmoothie(string email, string password, int combonumber, int quantity, string Cupsize, int StoreId)
        {
            try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
            }
            catch (System.Exception)
            {
                
                return NotFound("Customer not found.");
            }
           
           if(password == _customer.passwordd)
           {
               switch (StoreId)
               {
                   case 1:
                _storeBronx.Address = "Bronx, NY";

                _storeBronx.StoreID = 1;
                _storeBronx.Name = "SmoothieShackBronx";

                _order.fcustomer = _customer.cusID;
                _order.fstore = 1;
                _order.totalPrice = 0;
                _order.datet = DateTime.Now;
                _cusBL.AddOrder(_order);
                _order = _cusBL.GetOrderbyPrice();

                _newSmoothie = new SmoothieModel(combonumber, Cupsize, quantity);
                _newSmoothie.fcustomer = _customer.cusID;
                _newSmoothie.fstore = _storeBronx.StoreID;
                _newSmoothie.forder = _order.OrderID; 
                _customer.AddSmoothie(_newSmoothie);
                _storeBronx.AddSmoothie(_newSmoothie);
                _order.AddSmoothie(_newSmoothie);
                _storeBronx.AddOrder(_order); 
                try
                {
                    
                     _smoBL.AddSmoothie(_newSmoothie, 1);
                }
                catch (System.Exception exe)
                {
                    _cusBL.DeleteOrder(_order.OrderID);
                    return Conflict(exe.Message);
                }
               
                _smoBL.SubtractInventory(1, _newSmoothie.Quantity); 
                foreach (SmoothieModel item in _order.ListOfSmoothies)
                        {
                            if (item.Price > 0)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine("-------------------");
                            }
                            _order.totalPrice += item.Price;
                        }
                _cusBL.AlterOrderPrice(_order.OrderID, _order.totalPrice);
                return Ok(_order);

                case 2:
                 _storeBronx.Address = "Manhatten, NY";

                _storeBronx.StoreID = 2;
                _storeBronx.Name = "SmoothieShackMan";

                _order.fcustomer = _customer.cusID;
                _order.fstore = 2;
                _order.totalPrice = 0;
                _order.datet = DateTime.Now;
                _cusBL.AddOrder(_order);
                _order = _cusBL.GetOrderbyPrice();
                _newSmoothie = new SmoothieModel(combonumber, Cupsize, quantity);
                _newSmoothie.fcustomer = _customer.cusID;
                _newSmoothie.fstore = _storeBronx.StoreID;
                _newSmoothie.forder = _order.OrderID; 
                _customer.AddSmoothie(_newSmoothie);
                _storeBronx.AddSmoothie(_newSmoothie);
                _order.AddSmoothie(_newSmoothie);
                _storeBronx.AddOrder(_order); 
                try
                {
                     _smoBL.AddSmoothie(_newSmoothie, 2);
                }
                catch (System.Exception exe)
                {
                    _cusBL.DeleteOrder(_order.OrderID);
                    return Conflict(exe.Message);
                }
               
                _smoBL.SubtractInventory(2, _newSmoothie.Quantity); 
                foreach (SmoothieModel item in _order.ListOfSmoothies)
                        {
                            if (item.Price > 0)
                            {
                                Console.WriteLine(item);
                                Console.WriteLine("-------------------");
                            }
                            _order.totalPrice += item.Price;
                        }
                _cusBL.AlterOrderPrice(_order.OrderID, _order.totalPrice);
                return Ok(_order);

                   default:
                   return Conflict();
               }

               
           }else
           {
               return NotFound("Password incorrect");
           }
        }

        [HttpGet("Get Order by Customer{email}")]
        public IActionResult GetAllOrdersByCustomer(string email)
        {
            

            try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
                return Ok(_cusBL.GetAllOrdersByCustomer(_customer.cusID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
        }

        // PUT: api/P0/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/P0/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
