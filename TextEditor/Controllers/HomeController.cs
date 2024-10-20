using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TextEditor.Models;
using System.Web;

namespace TextEditor.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _env;
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    /*
    public MyController(IWebHostEnvironment env)
    {
        _env = env;
    }

    */
    [HttpPost]
    public ActionResult SaveText(string textContent)
    {
        //------------Error en esta linea----------//
        //string path = Hosting.HostingEnvironment.MapPath("~/App_Data/textfile.txt");
        string path = Path.Combine(_env.ContentRootPath, "App_Data", "textfile.txt");

        // Guardar el contenido en el archivo
        System.IO.File.WriteAllText(path, textContent);

        // Devolver una respuesta o redirigir a otra vista
        return RedirectToAction("Index");
        //return Content(path);
    }
}
