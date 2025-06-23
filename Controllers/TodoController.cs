using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TodoMVC.Models;

namespace TodoMVC.Controllers
{
	public class TodoController : Controller
	{
		// In-memory storage
		private static List<Todo> todos = new List<Todo>();
		private static int nextId = 1;

		// GET: Todo
		public ActionResult Index()
		{
			return View(todos);
		}

		// GET: Todo/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Todo/Create
		[HttpPost]
		public ActionResult Create(Todo todo)
		{
			if (ModelState.IsValid)
			{
				todo.Id = nextId++;
				todos.Add(todo);
				return RedirectToAction("Index");
			}
			return View(todo);
		}

		// GET: Todo/Edit/5
		public ActionResult Edit(int id)
		{
			var todo = todos.FirstOrDefault(t => t.Id == id);
			if (todo == null)
				return HttpNotFound();
			return View(todo);
		}

		// POST: Todo/Edit/5
		[HttpPost]
		public ActionResult Edit(Todo updatedTodo)
		{
			var todo = todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
			if (todo == null)
				return HttpNotFound();

			todo.Title = updatedTodo.Title;
			todo.IsDone = updatedTodo.IsDone;

			return RedirectToAction("Index");
		}

		// GET: Todo/Delete/5
		public ActionResult Delete(int id)
		{
			var todo = todos.FirstOrDefault(t => t.Id == id);
			if (todo == null)
				return HttpNotFound();
			return View(todo);
		}

		// POST: Todo/Delete/5
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			var todo = todos.FirstOrDefault(t => t.Id == id);
			if (todo != null)
				todos.Remove(todo);
			return RedirectToAction("Index");
		}
	}
}