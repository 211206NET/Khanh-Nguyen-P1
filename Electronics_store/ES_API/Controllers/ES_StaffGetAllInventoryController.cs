using Microsoft.AspNetCore.Mvc;
using Models;
using ESLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ES_StaffGetAllInventoryController : ControllerBase
    {
        private BL_Interface slogic;
        public ES_StaffGetAllInventoryController (BL_Interface sBL)
        {
            slogic = sBL;
        }

        // GET api/<ES_StaffGetAllInventoryController>
        [HttpGet]
        public async Task<List<Inventory>> GetAsync()
        {
            return await slogic.GetAllStoreInventory();
        }
    }
}
