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
using Google.Protobuf.WellKnownTypes;

namespace CSharpDemo.Controllers
{
    public class trandatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        trandata trandata = new trandata();
        Aes aes = new Aes();

        private string encryptedTrandata;

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
        public ViewResult sendRequest([Bind("issuerAgencyId", "billingAccountId", "billingCycle", "dueAmount", "paidAmount", "billReferenceInfo", "agencyCode")] BillDetails billDetails) {
            trandata.id = "IPAYhhcM5l5WVY5";
            trandata.password = "dJu71!0WgUL$3$b";
            trandata.action = "1";
            trandata.amt = billDetails.paidAmount;
            trandata.errorURL = "";
            trandata.responseURL = "";
            trandata.currencycode = "682";
            trandata.payorIDNumber = "1234567891";
            trandata.payorIDType = "NAT";
            trandata.trackid= GenerateID();
            trandata.billDetails = "["+billDetails+"]";
            encryptedTrandata = aes.EncryptString(trandata.ToString());
            Console.WriteLine(encryptedTrandata);
            Console.WriteLine(aes.Decrypt(aes.EncryptString(trandata.ToString())));

            ViewBag.trandata = encryptedTrandata;

            //Response.Redirect("MerchantResponse?tranportalId=" + trandata.id +"&responseURL" + trandata.responseURL + "&errorURL" + trandata.errorURL + "&trandata" + encryptedTrandata);
            
            return View("MerchantResponse");

        }

        // GET: trandatas/movingToPaymentPage
        public async Task<IActionResult> PaymentPage()
        {
            return View();
        }


        // POST: trandatas/movingToPaymentPage
        public async Task<IActionResult> movingToPaymentPage(string id)
        {
            return View("PaymentPage", id);
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
