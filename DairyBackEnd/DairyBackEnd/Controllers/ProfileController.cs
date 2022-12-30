using DairyBackEnd.Data;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiaryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public DataContextClass dataContextClass { get; set; }
        public ProfileController(DataContextClass profilecontext)
        {
            this.dataContextClass = profilecontext;
        }
        [HttpPost("Profile")]
        public async Task<ActionResult> Insprofile(Profile pr)
        {
            dataContextClass.tblprofile.Add(pr);
            await dataContextClass.SaveChangesAsync();
            return Ok(pr);
        }
        [HttpGet("Viewprofile/{id}")]
          public IActionResult ViewProfile(int id)
        {
           // return dataContextClass.tblprofile.ToList();
            return Ok(dataContextClass.tblprofile.Find(id));
        }
        [HttpPost("updateprofile")]
        public async Task<ActionResult> Updprofile(Profile cu)
        {
            dataContextClass.tblprofile.Update(cu);
            await dataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
    }
}
