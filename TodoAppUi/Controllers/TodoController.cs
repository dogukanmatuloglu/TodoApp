﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json.Serialization;
using TodoAppUi.Models.Context;
using TodoAppUi.Models.Entities.Concrete;
using TodoAppUi.ViewModels;

namespace TodoAppUi.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int _userId;

        public TodoController(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userId = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue(claimType: ClaimTypes.NameIdentifier));
        }
        //a
        public IActionResult TodayTask()
        {
            var data= _context.TodoLists.ToList();
            return View(data );
        }

        [HttpPost]
        public IActionResult Add(IFormCollection todoListViewModel)
        {
            
            TodoList todoList = new TodoList();
            var task=todoListViewModel["Task"];
            var date = todoListViewModel["Date"];

            todoList.PriorityId = 1;
            todoList.UserId = _userId;
            todoList.Task = task;
            todoList.ModifiedBy = _userId;
            todoList.CreatedBy = _userId;
            todoList.CreatedDate=DateTime.Now;
            todoList.ModifiedDate=DateTime.Now;
            _context.TodoLists.Add(todoList);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult OnComingTask()
        {
            return View();
        }
       
        public IActionResult MarkAsComplete(int Id)
        {
            var entity = _context.TodoLists.FirstOrDefault(x => x.Id == Id);

            if (entity.IsCompleted)
            {
                entity.IsCompleted = false;
            }
            else
            {
                entity.IsCompleted = true;
            }

            _context.SaveChanges();
            return null;

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
