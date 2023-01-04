using DairyBackEnd.Data;
using DiaryBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public DataContextClass dataContextClass { get; set; }
        public TodoController(DataContextClass todocontext)
        {
            this.dataContextClass = todocontext;
        }
        [HttpPost("Inserttodo")]
        public async Task<ActionResult> Instodo(Todo pr)
        {
            dataContextClass.tbltodo.Add(pr);
            await dataContextClass.SaveChangesAsync();
            return Ok(pr);
        }
        [HttpGet("viewtodo/{id}")]
        public IActionResult ViewTodo(int id)
        {
            //var pro = dataContextClass.tbltodo.FromSqlRaw("select * from tbltodo where uid={0}", id).FirstOrDefault();
            //return pro;
            // return dataContextClass.tblprofile.ToList();
            //return Ok(dataContextClass.tblprofile.);
            var view = dataContextClass.tbltodo.Where(u => u.uid == id).AsParallel();
            return Ok(view);
        }
        [HttpGet("Viewtododelete/{id}")]
        public IActionResult Viewdeleteid(int id)
        {
            return Ok(dataContextClass.tbltodo.Find(id));
        }
        
        [HttpDelete("deletetodoentry/{id}")]
        public async Task<ActionResult<Todo>> DeleteTodoentry(int id)
        {
            var entry = await dataContextClass.tbltodo.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            dataContextClass.tbltodo.Remove(entry);
            await dataContextClass.SaveChangesAsync();
            return entry;
        }

    }
}
