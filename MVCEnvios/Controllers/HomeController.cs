﻿using MVCEnvios.Data;
using MVCEnvios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCEnvios.Controllers
{
    public class HomeController : Controller
    {
        private MVCEnviosEntities db = new MVCEnviosEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Seguimiento()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public string Login(string usuario, string password)
        {
            var user = db.Login.Where(l => l.Usuario == usuario && l.Password == password).FirstOrDefault();

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Usuario, false);
                HttpContext.Session.Add("usuario", user.Usuario);
                HttpContext.Session.Add("rol", user.Rol);

                return Newtonsoft.Json.JsonConvert.SerializeObject(user);
            }
            else
            {
                return "{\"error\":\"El usuario no Esiste\"}";
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }


    }
}