using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpresaUTN.UAPI;
using EmpresaUTN.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace EmpresaUTN.WebMVC.Controllers
{
    public class PlatosController : Controller
    {

        //variable de tipo cadena de Platos
        private string Url = "https://localhost:7006/api/Platos";

        //constructor
        private Crud<Plato> Crud { get; set; }
        public PlatosController()
        {
            Crud = new Crud<Plato>();
        }



        // GET: PlatosController
        public ActionResult Index()
        {
            //devolver lista de platos
            var datos = Crud.Select(Url);
            return View(datos);
        }

        // GET: PlatosController/Details/5
        public ActionResult Details(int id)
        {
            //buscar plato por id
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // GET: PlatosController/Create
        public ActionResult Create()
        {

            //obtenemos la lista de restaurantes para ser utilizada en un combobox
            var listaRestaurantes = new Crud<Restaurante>()
                .Select(Url.Replace("Platos", "Restaurantes"))
                //transformamos del tipo restaurante a SelectListItem
                .Select(p => new SelectListItem
                {
                    Value = p.CodigoRestaurante.ToString(),//codigo del restaurante
                    Text = p.Nombre            //nombre del restaurante
                })
                .ToList();
            //pasamos la lsita de restaurantes a la vista
            ViewBag.ListaRestaurantes = listaRestaurantes;

            return View();
        }

        // POST: PlatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plato datos)
        {
            try
            {
                //insertar plato
                Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatosController/Edit/5
        public ActionResult Edit(int id)
        {
            //obtenemos la lista de restaurantes para ser utilizada en un combobox
            var listaRestaurantes = new Crud<Restaurante>()
                .Select(Url.Replace("Platos", "Restaurantes"))
                //transformamos del tipo restaurante a SelectListItem
                .Select(p => new SelectListItem
                {
                    Value = p.CodigoRestaurante.ToString(),//codigo del restaurante
                    Text = p.Nombre            //nombre del restaurante
                })
                .ToList();
            //pasamos la lsita de restaurantes a la vista
            ViewBag.ListaRestaurantes = listaRestaurantes;

            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: PlatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Plato datos)
        {
            try
            {
                //actualizar plato
                Crud.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: PlatosController/Delete/5
        public ActionResult Delete(int id)
        {
            //mostrar platos eliminados por id
            var datos = Crud.SelectById(Url, id.ToString());
            return View(datos);
        }

        // POST: PlatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Plato datos)
        {
            try
            {
                //eliminar plato
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
