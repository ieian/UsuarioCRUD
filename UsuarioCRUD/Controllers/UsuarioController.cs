using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UsuarioCRUD.Data;
using UsuarioCRUD.Models;

namespace UsuarioCRUD.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly ApplicationDbContext _db;

        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Crear(int? id)
        {
            Usuario usuario = new Usuario();
            if(id == null)
            {
                return View(usuario);
            }
            else
            {
                usuario = await _db.Usuario.FindAsync(id);
                return View(usuario);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Usuario usuario)
        {
            if (ModelState.IsValid)
            {   
                if(usuario.Id == 0)
                {
                    await _db.Usuario.AddAsync(usuario);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear));
                }
                else
                {
                    _db.Usuario.Update(usuario);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear), new { id=0});
                }
            }
            return View(usuario);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _db.Usuario.ToListAsync();
            return Json(new { data = todos });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuarioDb = await _db.Usuario.FindAsync(id);
            if(usuarioDb == null)
            {
                return Json(new { success = false, message = "Error al borrar" });
            }
            _db.Usuario.Remove(usuarioDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Cliente eliminado exitosamente!" });
        }
    }
}
