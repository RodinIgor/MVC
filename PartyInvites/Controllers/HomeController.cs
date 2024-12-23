
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
			ViewBag.text = "������ �� GET";
			return View("RsvpForm");
		}
		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{

				ViewBag.Text = "������ �� POST";
				Repository.AddResponse(guestResponse);
				return View("Thanks", guestResponse);//����� ������ View () ������ ������ �������� RsvpForm () �������� MVC � ���, ��� ����� ��������������� ������������� �� ����� Thanks � �������� ��� ������ GuestResponse.
			}
			else
			{
				// ���������� ������ �������� �������������, 
				return View();
			}
			}

		public ViewResult ListResponses()
		{
			return View(Repository.Responses.Where(r => r.WillAttend == true));
		}
	}
}
