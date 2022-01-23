using Microsoft.AspNetCore.Mvc;
using Models;
using ESLogic;

namespace ES_API.Controllers
{
    [Route("api/Authenticate/[controller]")]
    [ApiController]
    public class ES_StaffSignInController : ControllerBase
    {
        private BL_Interface slogic;
        public ES_StaffSignInController(BL_Interface sBL)
        {
            slogic = sBL;
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> Post([FromBody] Staff staff)
        {
            await slogic.StaffSignIn(staff);
            return staff;
        }
    }  
}
