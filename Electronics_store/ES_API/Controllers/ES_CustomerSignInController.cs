using Microsoft.AspNetCore.Mvc;
using Models;
using ESLogic;

namespace ES_API.Controllers
{
    [Route("api/Authenticate/[controller]")]
    [ApiController]
    public class ES_CustomerSignInController : ControllerBase
    {
        private BL_Interface clogic;
        public ES_CustomerSignInController(BL_Interface cBL)
        {
            clogic = cBL;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer cust)
        {
           return await clogic.CustomerSignIn(cust);
        }
    }
}
