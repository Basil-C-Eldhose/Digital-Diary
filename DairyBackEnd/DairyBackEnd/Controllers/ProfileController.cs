using DairyBackEnd.Data;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("profile")]
        public async Task<ActionResult> Insprofile(Profile pr)
        {
            dataContextClass.tblprofile.Add(pr);
            await dataContextClass.SaveChangesAsync();
            return Ok(pr);
        }
        [HttpGet("Viewprofile/{id}")]
          public Profile ViewProfile(int id)
        {
            var pro = dataContextClass.tblprofile.FromSqlRaw("select * from tblprofile where uid={0}", id).FirstOrDefault();
            return pro;
           // return dataContextClass.tblprofile.ToList();
            //return Ok(dataContextClass.tblprofile.);

        }
        [HttpPost("updateprofile")]
        public async Task<ActionResult> profileupdate(Profile cu)
        {
            dataContextClass.tblprofile.Update(cu);
            await dataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
    }
}
