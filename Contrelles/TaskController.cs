using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.model;

namespace WebApplication1.Contrelles
{
    public class TaskController : Controller
    {
        public async Task<IActionResult>Index()
        {
            using (MyProjectContext context=new MyProjectContext())
            {
                return View(await context.Fronts.ToListAsync());
                
            }
           
        }
    }
}
