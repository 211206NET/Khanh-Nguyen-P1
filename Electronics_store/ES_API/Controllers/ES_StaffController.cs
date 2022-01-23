using Microsoft.AspNetCore.Mvc;
using Models;
using ESLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ES_StaffController : ControllerBase
    {
        private BL_Interface slogic;
        public ES_StaffController(BL_Interface sBL)
        {
            slogic = sBL;
        }

        // GET: api/<ES_StaffController>
        [HttpGet]
        public async Task<List<Store>> GetAsync()
        {
            List<Store> sList = new List<Store>();
            sList = await slogic.GetAllStores();
            return sList;
        }


        // GET api/<ES_StaffController>
        [HttpGet("{id}")]
        public async Task<List<Inventory>> Get(int id)
        {
            List<Inventory> inv = new List<Inventory>();
            await slogic.GetStoreInventory(id);
            return inv;
        }

        // PUT api/<ES_StaffController>/5
        [HttpPut]
        public void Put([FromBody] Inventory invt)
        {
            slogic.FillInventory(invt);
        }

        [HttpPost]
        public void Post([FromBody] Staff staff)
        {
            slogic.NewEmployee(staff);
        }
    }
    
}
