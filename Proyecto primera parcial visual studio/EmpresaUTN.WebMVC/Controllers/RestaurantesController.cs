using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpresaUTN.UAPI;
using EmpresaUTN.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpresaUTN.WebMVC.Controllers
{
    public class RestaurantesController : Controller
    {

        //variable de tipo cadena de Restaurantes
        private string Url = "https://localhost:7006/api/Restaurantes";

        //constructor
        private Crud<Restaurante> Crud { get; set; }
        public RestaurantesController()
        {
            Crud = new Crud<Restaurante>();
        }




        // GET: RestaurantesController
        public ActionResult Index()
        {
            //devolver lista de restaurantes
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: RestaurantesController/Details/5
        public ActionResult Details(int id)
        {
            //devolver por id los restaurantes
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // GET: RestaurantesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurante datos)
        {
            try
            {
                //crear restaurante
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: RestaurantesController/Edit/5
        public ActionResult Edit(int id)
        {
            //editar restaurante por id
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: RestaurantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Restaurante datos)
        {
            try
            {
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: RestaurantesController/Delete/5
        public ActionResult Delete(int id)
        {
            //eliminar restaurante por id
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: RestaurantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Restaurante datos)
        {
            try
            {
                //eliminar restaurante por id
                Crud.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
