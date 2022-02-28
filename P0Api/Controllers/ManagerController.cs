using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P0BL;
using P0Model;

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

        [HttpGet("SearchCustomerByName{name}/{Manager_password}")]
        public IActionResult SearchCustomer(string name, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                try
            {
                return Ok(_cusBL.SearchCustomer(name));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            }else
            {
                return NotFound("Manager password incorrect");
            }
            

            
        }

        // GET: api/Manager
        [HttpGet("ViewInventory{storeID}/{Manager_password}")]
        public IActionResult ViewInventory(int storeID, string Manager_password)
        {
            if(Manager_password=="admin")
            {
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
                return NotFound("Manager password incorrect");
            }
            
        }

        [HttpGet("Get Order by Store{storeID}/{Manager_password}")]
        public IActionResult GetAllOrdersByStore(int storeID, string Manager_password)
        {
            
            if(Manager_password=="admin")
            {
                try
            {
                
                return Ok(_cusBL.GetAllOrdersByStore(storeID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            } else
            {
                return NotFound("Manager password incorrect");
            }
            
        }

        // GET: api/Manager/5
        [HttpGet("Get Order by Customer sorted by date{email}/{Manager_password}")]
        public IActionResult GetAllOrdersByCustomerOrderByDate(string email, string Manager_password)
        {
            
            if(Manager_password=="admin")
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
            } else
            {
                return NotFound("Manager password incorrect");
            }
            
        }

        [HttpGet("Get Order by Customer sorted by price{email}/{Manager_password}")]
        public IActionResult GetAllOrdersByCustomerOrderByPrice(string email, string Manager_password)
        {
            if(Manager_password=="admin")
            {
                try
            {
                _customer = _cusBL.SearchSpecificCustomer(email);
                return Ok(_cusBL.GetAllOrdersByCustomerbyPrice(_customer.cusID));
            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
            } else
            {
                return NotFound("Manager password incorrect");
            }

            
        }

        // POST: api/Manager
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Manager/5
        [HttpPost("AddInventory{storeID}/{number}/{Manager_password}")]
        public IActionResult AddInventory(int storeID, int number, string Manager_password)
        {
            if(Manager_password=="admin")
            {
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
                return NotFound("Manager password incorrect");
            }
                
        }

        // DELETE: api/Manager/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
