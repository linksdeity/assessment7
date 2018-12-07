using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment7.Models;

namespace Assessment7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }




        public ActionResult Dish()
        {
            return View();
        }

        public ActionResult NewDish(Dish newDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();

            ORM.Dishes.Add(newDish);
            ORM.SaveChanges();


            return RedirectToAction("Index");
        }




        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UpdateGuests(Guest newGuest)
        {

            PartyDBEntities ORM = new PartyDBEntities();

            ORM.Guests.Add(newGuest);
            ORM.SaveChanges();


            return RedirectToAction("Index");
        }



        public ActionResult DishIndex()
        {

            PartyDBEntities ORM = new PartyDBEntities();

            List<Dish> dishList = ORM.Dishes.ToList();

            ViewBag.DishList = dishList;

            return View();
        }



        public ActionResult DeleteDish(int ID)
        {
            PartyDBEntities ORM = new PartyDBEntities();

            Dish found = ORM.Dishes.Find(ID);

            ORM.Dishes.Remove(found);
            ORM.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult EditDish(int ID)
        {
            PartyDBEntities ORM = new PartyDBEntities();

            Dish found = ORM.Dishes.Find(ID);

            return View(found);

        }

        public ActionResult ConfirmDishEdit(Dish updatedDish)
        {
            PartyDBEntities ORM = new PartyDBEntities();

            Dish oldDish = ORM.Dishes.Find(updatedDish.DishID);

            oldDish.DishName = updatedDish.DishName;
            oldDish.DishDescription = updatedDish.DishDescription;
            oldDish.FoodOption = updatedDish.FoodOption;
            oldDish.PersonName = updatedDish.PersonName;
            oldDish.PhoneNumber = updatedDish.PhoneNumber;

            ORM.Entry(oldDish).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();

            return RedirectToAction("DishIndex");
        }


    }
}