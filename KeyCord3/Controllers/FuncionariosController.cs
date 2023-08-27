using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KeyCord3.Data;
using KeyCord3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KeyCord3.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public FuncionariosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }




        
        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.IdFunc == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Funcionarios'  is null.");
            }


            Funcionario funcionario =  _context.Funcionarios.Find(id);
            Utilizador  ut =  _context.Utilizadors.Find(id);
            var user = await _userManager.FindByIdAsync(ut.IdAspNet);
            if (funcionario != null)
            {
                _context.Utilizadors.Remove(ut);
                _context.Funcionarios.Remove(funcionario);
               
                var rolesForUser = await _userManager.GetRolesAsync(user);
                foreach (var item in rolesForUser.ToList())
                {
                    // item should be the name of the role
                   await _userManager.RemoveFromRoleAsync(user, item);
                }
                await _userManager.DeleteAsync(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ListFuncionarios","Manutencao");

        }

        private bool FuncionarioExists(int id)
        {
          return _context.Funcionarios.Any(e => e.IdFunc == id);
        }
    }
}
