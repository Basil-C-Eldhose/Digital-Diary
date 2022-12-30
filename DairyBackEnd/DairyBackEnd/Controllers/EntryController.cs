using DairyBackEnd.Data;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiaryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        public DataContextClass dataContextClass { get; set; }
        public EntryController(DataContextClass profilecontext)
        {
            this.dataContextClass = profilecontext;
        }
        [HttpPost("insEntry")]
        public async Task<ActionResult> insEntry(Entry cu)
        {

            dataContextClass.tblentry.Add(cu);
            await dataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
    }
}
