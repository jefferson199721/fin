using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaluacion_Final2.Data;
using Evaluacion_Final2.Models;
using Microsoft.AspNetCore.Identity;

namespace Evaluacion_Final2.Controllers
{
    public class DiscosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly DiscoModel _disco_model;

        public DiscosController(ApplicationDbContext context)
        {
            _context = context;
            _disco_model = new DiscoModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disco.ToListAsync());
        }


        public IdentityError Nuevo_Disco_Controller(string Nombre, string Capacidad, string Tipo)
        {
            return _disco_model.Nuevo_Disco_Model(Nombre, Capacidad, Tipo);

        }


        public Disco Un_Disco_Controller(int idDisco)
        {
            return _disco_model.Un_Disco_Model(idDisco);
        }
        public IdentityError Editar_Disco_Controller(int idDisco, string Nombre, string Capacidad, string Tipo)
        {
            return _disco_model.Editar_Disco_Model(idDisco, Nombre, Capacidad, Tipo);

        }
        public IdentityError Eliminar_Disco_Controller(int idDisco)
        {
            return _disco_model.Eliminar_Disco_Model(idDisco);
        }



        public List<object[]> Lista_Disco_Controller()
        {
            return _disco_model.Lista_Disco_Model();
        }
    }
}
