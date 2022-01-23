using Microsoft.AspNetCore.Mvc;
using Models;
using ESLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ES_CustomerController : ControllerBase
    {
        private BL_Interface clogic;
        public ES_CustomerController (BL_Interface cBL)
        {
            clogic = cBL;
        }

        // GET: api/<ES_CustomerController>
        [HttpGet]
        public async Task<List<Store>> GetAsync()
        {
            return await clogic.GetAllStores();
        }

        // GET api/<ES_CustomerController>/5
        [HttpGet("{id}")]
        public async Task<List<Inventory>> GetAsync(int id)
        {
            List<Inventory> storeInventory = await clogic.GetStoreInventory(id);

            return storeInventory;
        }

        // POST api/<ES_CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer cust)
        {
            clogic.SignUp(cust);
        }


    }
}
