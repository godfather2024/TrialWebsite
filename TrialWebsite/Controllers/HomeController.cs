using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrialWebsite.Models;

namespace TrialWebsite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [ActionName("Index")]
        public async Task<ActionResult> Index(ContactForm cf)
        {
            if (ModelState.IsValid)
            {
                var body = "Email from : {0} , Their contact info email: {1}  Ph no : {2} and Message {3}";
                var message = new MailMessage();
                message.To.Add(new MailAddress("godfather2024@gmail.com"));
                message.Subject = "Inquires";
                message.Body = string.Format(body, cf.Name, cf.Email, cf.PhoneNumber, cf.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Message = "Get in Touch with us";
            return View(cf);

        }


        public async Task<ActionResult> Contact(ContactForm af)
        {
            if (ModelState.IsValid)
            {
                var body = "Email from : {0} , Their contact info email: {1}  Ph no : {2} and Message {3}";
                var message = new MailMessage();
                message.To.Add(new MailAddress("godfather2024@gmail.com"));
                message.Subject = "Inquires";
                message.Body = string.Format(body, af.Name, af.Email, af.PhoneNumber, af.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Message = "Get in Touch with us";
            return View(af);
        }

        [ActionName("Sent")]
        public ActionResult Sent()
        {
            return View();
        }
    }

}