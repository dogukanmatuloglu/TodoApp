using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoAppUi.Models.Context;
using TodoAppUi.Models.Entities.Concrete;
using TodoAppUi.ViewModels;

namespace TodoAppUi.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public TodoController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            var data= _context.TodoLists.ToList();
            return View(data );
        }

        [HttpPost]
        public IActionResult Add(IFormCollection todoListViewModel)
        {
            
            TodoList todoList = new TodoList();
            var x=todoListViewModel["Task"];

            todoList.PriorityId = 1;
            todoList.UserId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(claimType: ClaimTypes.NameIdentifier));
            todoList.Task = x;
            todoList.ModifiedBy = 1;
            todoList.CreatedBy = 1;
            todoList.CreatedDate=DateTime.Now;
            todoList.ModifiedDate=DateTime.Now;
            _context.TodoLists.Add(todoList);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        


        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return View();
        }


    }
}
