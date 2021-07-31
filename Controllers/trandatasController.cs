using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSharpDemo.Data;
using CSharpDemo.Models;
using System.Net;
using System.IO;
using System.Net.Http;

namespace CSharpDemo.Controllers
{
    public class trandatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        BillDetails bill1 = new BillDetails("041000000000000000", "191215003212", "", "0.00", "16.00", "", "MOF");
        BillDetails bill2 = new BillDetails("041000000000000000", "191208003137", "", "0.00", "16.00", "", "MOF");
        string Bills;
        Aes aes = new Aes();

        public string endPoint;

        public string httpMethod;

        public trandatasController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: trandatas/sendRequest
        public IActionResult sendRequest()
        {
            return View();
        }

        // POST: trandatas/sendRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async void sendRequest([Bind("id,password,amt,currencycode,action,responseURL,errorURL,udf1,udf2,udf3,udf4,udf5,udf6,udf7,udf8,udf9,udf10,langid,payorIDType,payorIDNumber")] trandata trandata) {
            Bills = "[" + bill1 + "," + bill2 + "]";
            Console.WriteLine(Bills);
            //trandata.trackid= "rdftcgvbhfgygbjghfyghgfx234567";
            trandata.billDetails = Bills;
            Console.WriteLine(aes.EncryptString(trandata.ToString()));
            Console.WriteLine(aes.Decrypt(aes.EncryptString(trandata.ToString())));

            HttpClient httpClient = new HttpClient();
            MultipartFormDataContent form = new MultipartFormDataContent();

            form.Add(new StringContent(aes.EncryptString(trandata.ToString())), "trandata");
            form.Add(new StringContent(trandata.id), "tranportalId");
            form.Add(new StringContent(trandata.responseURL), "responseURL");
            form.Add(new StringContent(trandata.errorURL), "errorURL");
            HttpResponseMessage response = await httpClient.PostAsync("https://securepayments.alrajhibank.com.sa/pg/servlet/PaymentInitHTTPServlet", form);

            response.EnsureSuccessStatusCode();
            httpClient.Dispose();
            string sd = response.Content.ReadAsStringAsync().Result;

            Console.WriteLine(sd);


            //return aes.EncryptString(trandata.ToString());
        }


        protected string GenerateID()
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers;
                characters += alphabets + small_alphabets + numbers;
            string id = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (id.IndexOf(character) != -1);
                id += character;
            }
            return id;
        }


    }
}
