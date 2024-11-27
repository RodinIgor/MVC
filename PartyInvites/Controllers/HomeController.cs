
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;


namespace PartyInvites.Controllers
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{

			int hour = DateTime.Now.Hour;
			ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
			return View("MyView");
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			ViewBag.text = "Запрос по GET";
			return View("RsvpForm");
		}
		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{

				ViewBag.Text = "Запрос по POST";
				Repository.AddResponse(guestResponse);
				return View("Thanks", guestResponse);//Вызов метода View () внутри метода действия RsvpForm () сообщает MVC о том, что нужно визуализировать представление по имени Thanks и передать ему объект GuestResponse.
			}
			else
			{
				// Обнаружена ошибка проверки достоверности, 
				
				return View();
			}
			}

		public ViewResult ListResponses()
		{
			return View(Repository.Responses.Where(r => r.WillAttend == true));
		}
	}
}
