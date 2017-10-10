using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeepModel;

namespace JeepGosh.Controllers
{
    public class HomeController : Controller
    {
        public static List<Person> Persons = new List<Person>(){
            new Person{User="潘星宇",UserId=1,Number="14077",PhoneNumber="18862482729",Department="财务管理开发组"},
            new Person{User="欧阳",UserId=2,Number="17705",PhoneNumber="1555222557",Department="财务管理开发组"},
            new Person{User="XXX",UserId=3,Number="35852",PhoneNumber="855447411",Department="财务管理开发组"},
            new Person{User="大黄",UserId=4,Number="95585",PhoneNumber="258741225",Department="财务管理开发组"},
        };
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { Users = Persons }
            };
        }

        public ActionResult DoSomething(Person person)
        {
            var result = Persons.SingleOrDefault(u => u.UserId == person.UserId);
            if (result == null)
            {
                return new JsonResult { Data = new { Success = false, Message = "没有该用户" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                return new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { Success = true, Data = result }
                };
            }
        }
    }
}