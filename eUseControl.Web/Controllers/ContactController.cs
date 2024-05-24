using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View(new ContactFormModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var fromAddress = new MailAddress("mchiaburu.1337@gmail.com", "Your Name");
                var toAddress = new MailAddress("mchiaburu.1337@gmail.com", "Mihaela Chiaburu");
                const string fromPassword = "email-password";
                string subject = model.Subject;
                string body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                ViewBag.Message = "Your message has been sent successfully!";
                return View(new ContactFormModel());
            }

            return View(model);
        }
    }
}
