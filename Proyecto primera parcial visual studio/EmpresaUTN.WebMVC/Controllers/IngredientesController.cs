using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpresaUTN.UAPI;
using EmpresaUTN.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmpresaUTN.WebMVC.Controllers
{
    public class IngredientesController : Controller
    {
        //variable de tipo cadena
        private string Url= "https://localhost:7006/api/Ingredientes";

        private Crud<Ingrediente> Crud { get; set;}
        //contructor
        public IngredientesController()
        {
            Crud = new Crud<Ingrediente>();
        }



        // GET: IngredientesController
        public ActionResult Index()
        {
            //devolver lista de ingredientes
            var datos = Crud.Select(Url);
            return View(datos);
        }



        // GET: IngredientesController/Details/5
        public ActionResult Details(int id)
        {
            //buscar ingrediente por id
            var datos = Crud.SelectById(Url,id.ToString());
            return View(datos);
        }



        // GET: IngredientesController/Create
        public ActionResult Create()
        {
            //obtenemos la lista de platos para ser utilizada en un combobox
            var listaPlatos= new Crud<Plato>()
                .Select(Url .Replace("Ingredientes", "Platos"))
                //transformamos del tipo plato a SelectListItem
                .Select(p => new SelectListItem 
                {
                    
                    Value = p.Id.ToString(),//codigo del plato
                    Text = p.Nombre            //nombre del plato
                })
                .ToList();
            //pasamos la lsita de provincias a la vista
            ViewBag.ListaPlatos = listaPlatos;
    

            return View();
        }



        // POST: IngredientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingrediente datos)
        {
            try
            {
                //insertar ingrediente
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }



        // GET: IngredientesController/Edit/5
        public ActionResult Edit(int id)
        {
         
            //obtenemos la lista de platos para ser utilizada en un combobox
            var listaPlatos = new Crud<Plato>()
                .Select(Url.Replace("Ingredientes", "Platos"))
                //transformamos del tipo plato a SelectListItem
                .Select(p => new SelectListItem
                {

                    Value = p.Id.ToString(),//codigo del plato
                    Text = p.Nombre            //nombre del plato
                })
                .ToList();
            //pasamos la lsita de provincias a la vista
            ViewBag.ListaPlatos = listaPlatos;
            
            var datos= Crud.SelectById(Url, id.ToString());
            return View(datos);
        }



        // POST: IngredientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ingrediente datos)
        {
            try
            {

                //actualizar los ingredientes
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }



        // GET: IngredientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }



        // POST: IngredientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ingrediente datos)
        {
            try
            {
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
