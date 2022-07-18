using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using la_mia_pizzeria_model.Database;
using la_mia_pizzeria_model.Models;
using Microsoft.IdentityModel.Tokens;

namespace la_mia_pizzeria_model.Controllers
{
    public class PizzaController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            Utility(new Pizza(model.NomePizza, model.Descrizione, model.PathImage,model.Prezzo));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        private void Utility(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {


            using (PizzaContext db = new PizzaContext())
            {
                //create
                //Pizza nuovaPizza = new Pizza();
                //nuovaPizza.NomePizza = "Margherita";
                //nuovaPizza.Descrizione ="La margherita più buona della città";
                //nuovaPizza.PathImage = "Margherita";
                //nuovaPizza.Prezzo = 5.45f;

                //Pizza nuovaPizza = new Pizza("Margherita", "La margherita più buona della città", "pathimage", 5.45f);
                //Pizza nuovaPizza1 = new Pizza("Capricciosa", "Super pizza Capricciosa", "pathimage", 6.5f);
                // Pizza nuovaPizza2 = new Pizza("Tonno e Cipolla", "Rossi", "pathimage", 6.5f);

                //db.Add(nuovaPizza);
                //db.Add(nuovaPizza1);
                //db.Add(nuovaPizza2);

                // db.SaveChanges();

                //Console.WriteLine("recupero lista pizze");
                List<Pizza> listPizza = db.Pizzas.OrderBy(pizza => pizza.Id).ToList<Pizza>();
                if (listPizza == null)
                {
                    return NotFound("Pizze non presenti");
                }
                return View(listPizza);
            }
        }


        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound("Pizza non trovata");
                }
                else
                {
                    //db.Entry(pizza).Collection("IngredienteList").Load();
                    return View("Details", pizza);
                }
            }
        }
        // GET: HomeController1/Create
      

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
