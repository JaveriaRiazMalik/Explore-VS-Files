using ExploreTandT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExploreTandT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel collection)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("Summenzahid@gmail.com")); 
            message.From = new MailAddress(collection.Email);  
            message.Subject ="Explore Contact";
            message.Body = string.Format(collection.Body, "model.FromName", "model.FromEmail", "model.Message");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "Summenzahid@gmail.com",  
                    Password = "Password Goes Here"  
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return Redirect("Index");
            }
        }
    }
}