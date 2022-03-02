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
    public class ManagerController : ControllerBase
    {
        private Customer _customer = new Customer();
        private ICustomerBL _cusBL;
        private ISmoothieBL _smoBL;

        public ManagerController(ICustomerBL c_cusBL, ISmoothieBL s_smoBL)
        {
            _cusBL = c_cusBL;
            _smoBL = s_smoBL;
        }
        /// <summary>
        /// Method allows manager to search for a customer with customer name as a parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpGet("SearchCustomerByName{name}/{Manager_password}")]
        public IActionResult SearchCustomer(string name, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                try
            {
                Log.Information("Manager searching for customer \n" + name);
                return Ok(_cusBL.SearchCustomer(name));
            }
            catch (System.Exception)
            {
                Log.Warning("Manager unsuccessful in finding customer.");
                return NotFound();
            }
            }else
            {
                Log.Warning("Manager password incorrect for searching customer.");
                return NotFound("Manager password incorrect");
            }
            

            
        }

        /// <summary>
        /// This method allows manager to view inventory of specific store with storeID as parameter
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpGet("ViewInventory{storeID}/{Manager_password}")]
        public IActionResult ViewInventory(int storeID, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                Log.Information("Manager viewing inventory for store with ID " + storeID);
                 List<Product> pro = _smoBL.GetAllProduct();

            try
            {
                return Ok(pro[storeID-1]);
            }
            catch (System.Exception)
            {
                Log.Warning("Error occured when trying to view inventory.");
                return Conflict();
            }
            }else
            {
                Log.Warning("Manager password incorrect for viewing inventory.");
                return NotFound("Manager password incorrect");
            }
            
        }
        /// <summary>
        /// Meathod allows manager to retrieve orders by specific store with storeID as a parameter
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpGet("Get Order by Store{storeID}/{Manager_password}")]
        public IActionResult GetAllOrdersByStore(int storeID, string Manager_password)
        {
            
            if(Manager_password=="admin")
            {
                try
            {
                Log.Information("Manager viewing orders for store with ID " + storeID);
                return Ok(_cusBL.GetAllOrdersByStore(storeID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            } else
            {
                Log.Warning("Manager password incorrect for getting order by store.");
                return NotFound("Manager password incorrect");
            }
            
        }

        /// <summary>
        /// Method allows manager to retrieve orders sorted by date by specific customer with customer email as a parameter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpGet("Get Order by Customer sorted by date{email}/{Manager_password}")]
        public IActionResult GetAllOrdersByCustomerOrderByDate(string email, string Manager_password)
        {
            
            if(Manager_password=="admin")
            {
                try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
                Log.Information("Manager viewing orders by customer with email " + email);
                return Ok(_cusBL.GetAllOrdersByCustomer(_customer.cusID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            } else
            {
                Log.Warning("Manager password incorrect for getting order by customer.");
                return NotFound("Manager password incorrect");
            }
            
        }
        /// <summary>
        /// Method allows manager to retrieve orders sorted by price by specific customer with customer email as a parameter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpGet("Get Order by Customer sorted by price{email}/{Manager_password}")]
        public IActionResult GetAllOrdersByCustomerOrderByPrice(string email, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
                Log.Information("Manager viewing orders by customer with email " + email);
                return Ok(_cusBL.GetAllOrdersByCustomerbyPrice(_customer.cusID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            } else
            {
                Log.Warning("Manager password incorrect for getting order by customer.");
                return NotFound("Manager password incorrect");
            }

            
        }

        /// <summary>
        /// Methods takes in quantity and storeID to add inventory to specified store.
        /// </summary>
        /// <param name="storeID"></param>
        /// <param name="number"></param>
        /// <param name="Manager_password"></param>
        /// <returns></returns>
        [HttpPost("AddInventory{storeID}/{number}/{Manager_password}")]
        public IActionResult AddInventory(int storeID, int number, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                Log.Information("Manager adding " + number + " inventory to store with store ID " + storeID);
                 _smoBL.AddInventory(storeID, number);
            List<Product> pro = _smoBL.GetAllProduct();
            try
            {
                return Ok(pro[storeID-1]);
            }
            catch (System.Exception)
            {
                
                return Conflict();
            }
            }else
            {
                Log.Warning("Manager password incorrect for adding inventory.");
                return NotFound("Manager password incorrect");
            }
                
        }

       
    }
}
