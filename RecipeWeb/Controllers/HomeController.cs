using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DIYFE.EF;
using RecipeWeb.Models;

namespace RecipeWeb.Controllers
{
    public class HomeController : ApplicationController
    {
        public ActionResult Index()
        {
            PageModel.Title = "Contact About Boostrap Project";
            PageModel.Description = "Bootstrap Template Project";
            PageModel.Author = "Bootstrap";
            PageModel.Keywords = "Boostrap project, starter project, soe keywords, keywords";
            PageModel.ActiveTopNavLink = "MainNavContact";

            WeeklyMenu Model = new WeeklyMenu();
            using (var db = new DIYFE.EF.DIYFEEntities())
            {
                Model.ShoppingList = db.IngredientShoppings.ToList();
                Model.DailyRecipes = db.DailyRecipes.ToList();
                Model.SeasonalRecipes = db.SeasonalRecipes.ToList();
            }

            return View(Model);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WeeklyMenu()
        {
            PageModel.Title = "Contact About Boostrap Project";
            PageModel.Description = "Bootstrap Template Project";
            PageModel.Author = "Bootstrap";
            PageModel.Keywords = "Boostrap project, starter project, soe keywords, keywords";
            PageModel.ActiveTopNavLink = "MainNavContact";

            WeeklyMenu Model = new WeeklyMenu();
            using (var db = new DIYFE.EF.DIYFEEntities())
            {
                Model.ShoppingList = db.IngredientShoppings.ToList();
                Model.DailyRecipes = db.DailyRecipes.ToList();
                Model.SeasonalRecipes = db.SeasonalRecipes.ToList();
            }

            return View(Model);
        }

        public ActionResult DailyRecipeRemove(int recipeDayId)
        {

            var data = new object();

            try
            {
                using (var db = new DIYFE.EF.DIYFEEntities())
                {
                    RecipeDay deltedRecipe = db.RecipeDays.Where(rd => rd.RecipeDayId == recipeDayId).FirstOrDefault();
                    if (deltedRecipe != null)
                    {
                        db.Entry(deltedRecipe).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
                    };
                }

                data = new { success = true };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    data = new { success = false, message = ex.InnerException.Message };
                }
                else
                {
                    data = new { success = false, message = ex.Message + " Another reason why EF sucks" };
                }
                return Json(data);

            }

            return Json(data);
        }

        public ActionResult AddToDay(int dayId, int recipeId)
        {

            var data = new object();

            RecipeDay rd = new RecipeDay
            {
                DayId = dayId,
                RecipeId = recipeId,
                Active = true
            };

            try
            {
                using (var db = new DIYFE.EF.DIYFEEntities())
                {

                    db.Entry(rd).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }

                data = new { success = true };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    data = new { success = false, message = ex.InnerException.Message };
                }
                else
                {
                    data = new { success = false, message = ex.Message + " Another reason why EF sucks" };
                }
                return Json(data);

            }

            return Json(data);
        }

        public ActionResult AddShoppingItem(int ingredientId)
        {

            var data = new object();

            IngredientShopping rd = new IngredientShopping
            {
                IngredientId = ingredientId
            };

            try
            {
                using (var db = new DIYFE.EF.DIYFEEntities())
                {

                    db.Entry(rd).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }

                data = new { success = true };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    data = new { success = false, message = ex.InnerException.Message };
                }
                else
                {
                    data = new { success = false, message = ex.Message + " Another reason why EF sucks" };
                }
                return Json(data);

            }

            return Json(data);
        }

        public ActionResult RemoveShoppingItem(int ingredientId)
        {

            var data = new object();

            try
            {
                using (var db = new DIYFE.EF.DIYFEEntities())
                {

                    IngredientShopping deltedItem = db.IngredientShoppings.Where(i => i.IngredientId == ingredientId).FirstOrDefault();
                    if (deltedItem != null)
                    {
                        db.Entry(deltedItem).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
                    };
                }

                data = new { success = true };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    data = new { success = false, message = ex.InnerException.Message };
                }
                else
                {
                    data = new { success = false, message = ex.Message + " Another reason why EF sucks" };
                }
                return Json(data);

            }

            return Json(data);
        }

        public ActionResult ClearWeek()
        {

            var data = new object();

            try
            {
                using (var db = new DIYFE.EF.DIYFEEntities())
                {
                    db.ClearWeek();
                    db.SaveChanges();
                }

                data = new { success = true };
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message != null)
                {
                    data = new { success = false, message = ex.InnerException.Message };
                }
                else
                {
                    data = new { success = false, message = ex.Message + " Another reason why EF sucks" };
                }
                return Json(data);

            }

            return Json(data);
        }
    }
}
