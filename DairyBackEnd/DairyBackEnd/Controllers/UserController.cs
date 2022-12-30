using DairyBackEnd.Data;
using DairyBackEnd.Models;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DiaryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public DataContextClass objdatacontextclass { get; set; }
        public UserController(DataContextClass objdatacontextclass)
        {
            this.objdatacontextclass = objdatacontextclass;
        }
        [HttpPost("registration")]
        public async Task<ActionResult> InsCourse(Registration cu)
        {
            objdatacontextclass.tblregistration.Add(cu);
            await objdatacontextclass.SaveChangesAsync();
            return Ok(cu);
        }
        
        [HttpPost("login")]

        public IActionResult Login(Registration us)
        {
            var userAvailable = objdatacontextclass.tblregistration.Where(u => u.email == us.email && u.password == us.password).FirstOrDefault();
            if (userAvailable != null)
            {
                return Ok(userAvailable);
            }
            return Ok("Failed");

        }
        [HttpGet("viewuserdairy/{id}")]
        public IActionResult ViewUserDiary(int id)
        {
            // return dataContextClass.tblprofile.ToList();
            var view=objdatacontextclass.tblentry.Where(u=>u.uid == id).AsParallel();
            return Ok(view);
        }
        [HttpGet("viewdiary/{id}")]
        public IActionResult ViewDiary(int id)
        {
            // return dataContextClass.tblprofile.ToList();
            //var view = objdatacontextclass.tblentry.Where(u => u.uid == id).AsParallel();
            //return Ok(view);
            return Ok(objdatacontextclass.tblentry.Find(id));
        }

        [HttpGet("diaryopen/{id}")]
        public IActionResult Diaryopen(int id)
        {
            // return dataContextClass.tblprofile.ToList();
            //var view = objdatacontextclass.tblentry.Where(u => u.uid == id).AsParallel();
            //return Ok(view);
            return Ok(objdatacontextclass.tblentry.Find(id));
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Entryupdate(Entry cu)
        {
            objdatacontextclass.tblentry.Update(cu);
            await objdatacontextclass.SaveChangesAsync();
            return Ok(cu);
        }

    }
}
