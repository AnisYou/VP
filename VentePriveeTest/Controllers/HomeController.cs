using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using VentePriveeTest.Helpers;
using VentePriveeTest.Models;

namespace VentePriveeTest.Controllers
{
    public class HomeController : Controller
    {
        public const string WEBAPIAUTHENTICATEURI = "http://localhost:57770/api/authenticate/";
        public const string WEBAPICONFIDENTIALSURI = "http://localhost:57775/api/confidentials";

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WebAPIAuthenticate()
        {
            return View();
        }
        public IActionResult WebAPIConfidentials()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel user)
        {
            HttpClient client = new HttpClient();

            string stringData = JsonConvert.SerializeObject(user);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(WEBAPIAUTHENTICATEURI, contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.LoginResponse = "Utilisateur authentifé !";
            }
            else
            {
                ViewBag.LoginResponse = "Email ou Mot de passe incorrecte, veuillez vérifiez svp vos identifiants.";
            }

            return View("WebAPIAuthenticate");
        }
        [HttpPost]
        public IActionResult Confidentials(UserViewModel user)
        {
            HttpClient client = new HttpClient();

            string stringData = JsonConvert.SerializeObject(user);
            var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
            string dataToEncrypt = string.Format("{0}\n{1}\n{2}", "POST", "application/json", string.Format("{0:MM/dd/yyyy}", DateTime.Now));
            string authorizationHeader = EncryptionHelper.Encrypt(dataToEncrypt);
            client.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(authorizationHeader);
            HttpResponseMessage response = client.PostAsync(WEBAPICONFIDENTIALSURI, contentData).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.ConfidentialsResponse = "Utilisateur autorisé !";
            }
            else
            {
                ViewBag.ConfidentialsResponse = "Utilisateur non autorisé !";
            }
            return View("WebAPIConfidentials");

        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
