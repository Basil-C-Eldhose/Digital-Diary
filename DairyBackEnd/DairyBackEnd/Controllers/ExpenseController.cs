using DairyBackEnd.Data;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public DataContextClass objdataContextClass { get; set; }
        public ExpenseController(DataContextClass objdataContextClass)
        {
            this.objdataContextClass = objdataContextClass;
        }
        [HttpPost("expenseentry")]
        public async Task<ActionResult> InsExpense(Expense cu)
        {
            objdataContextClass.tblexpense.Add(cu);
            await objdataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
        [HttpPost("categoryentry")]
        public async Task<ActionResult> InsCategory(Category cu)
        {
            objdataContextClass.tblcategory.Add(cu);
            await objdataContextClass.SaveChangesAsync();
            return Ok(cu);
        }
        [HttpGet("categoryview/{id}")]
        public IActionResult ViewCategory(int id)
        {
            var op = objdataContextClass.tblcategory.FromSqlRaw($"SELECT * FROM tblcategory where uid={id}").ToList();
            return Ok(op);

        }
        [HttpGet("datesearch")]

        public IActionResult SearchView(DateTime datestart, DateTime dateend,int uid)
        {

            var result = from x in objdataContextClass.tblexpense
                         where x.date.Date >= datestart.Date && x.date.Date <= dateend.Date && x.uid == uid
                         select x;

            return Ok(result);
        }

        [HttpGet("ExpenseView")]
        public IActionResult ViewExpense(int uid)
        {
            var op = objdataContextClass.tblexpense.FromSqlRaw($"SELECT * FROM tblexpense where uid={uid}").ToList();
            return Ok(op);

        }
        [HttpDelete("deleteexpenseentry/{id}")]
        public async Task<ActionResult<Expense>> Deleteexpenentry(int id)
        {
            var entry = await objdataContextClass.tblexpense.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            objdataContextClass.tblexpense.Remove(entry);
            await objdataContextClass.SaveChangesAsync();
            return entry;
        }
    }
}
