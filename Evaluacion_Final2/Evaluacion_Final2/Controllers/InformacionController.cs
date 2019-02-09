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
    public class InformacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly InformacionModel _informacion_model;

        public InformacionController(ApplicationDbContext context)
        {
            _context = context;
            _informacion_model = new InformacionModel(context);
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Informacion.ToListAsync());
        }


        public IdentityError Nuevo_Informacion_Controller(string Ubicacion, string Detalle, string Tamaño, string Nombre, DateTime Fecha)
        {
            return _informacion_model.Nuevo_Informacion_Model( Ubicacion,  Detalle,  Tamaño,  Nombre,  Fecha);

        }


        public Informacion Un_Informacion_Controller(int idInformacion)
        {
            return _informacion_model.Un_Informacion_Model(idInformacion);
        }
        public IdentityError Editar_Informacion_Controller(int idInformacion, string Ubicacion, string Detalle, string Tamaño, string Nombre, DateTime Fecha)
        {
            return _informacion_model.Editar_Informacion_Model(idInformacion, Ubicacion, Detalle, Tamaño, Nombre, Fecha);

        }
        public IdentityError Eliminar_Informacion_Controller(int idInformacion)
        {
            return _informacion_model.Eliminar_Informacion_Model(idInformacion);
        }



        public List<object[]> Lista_Informacion_Controller()
        {
            return _informacion_model.Lista_Informacion_Model();
        }
    }
}
