using Evaluacion_Final2.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_Final2.Models
{
    public class InformacionModel
    {
        public ApplicationDbContext _contexto;

        public InformacionModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Informacion_Model(
            string Ubicacion,
            string Detalle,
            string Tamaño,
            string Nombre,
            DateTime Fecha)
        {
            IdentityError resultado = new IdentityError();
            Informacion informacion = new Informacion()
            {
                Ubicacion = Ubicacion,
                Detalle = Detalle,
                Tamaño = Tamaño,
                Nombre = Nombre,
                Fecha = Fecha

            };
            try
            {

                _contexto.Informacion.Add(informacion);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Guardo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }

        public Informacion Un_Informacion_Model(int idInformacion)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Informacion informacion = (from inf in _contexto.Informacion
                           where inf.idInformacion == idInformacion
                                       select inf).FirstOrDefault();
            return informacion;
        }

        public IdentityError Editar_Informacion_Model(
            int idInformacion,
            string Ubicacion,
            string Detalle,
            string Tamaño,
            string Nombre,
            DateTime Fecha)
        {
            IdentityError resultado = new IdentityError();
            Informacion informacion = new Informacion()
            {
                Ubicacion = Ubicacion,
                Detalle = Detalle,
                Tamaño = Tamaño,
                Nombre = Nombre,
                Fecha = Fecha,
                idInformacion = idInformacion
            };
            try
            {
                _contexto.Informacion.Update(informacion);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Actualizo con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }
        public IdentityError Eliminar_Informacion_Model(
           int idInformacion)
        {
            IdentityError resultado = new IdentityError();
            Informacion informacion = new Informacion()
            {
                idInformacion = idInformacion
            };
            try
            {
                _contexto.Informacion.Remove(informacion);
                _contexto.SaveChanges();
                resultado = new IdentityError()
                {
                    Code = "ok",
                    Description = "Se Elimino con Exito"
                };

            }
            catch (Exception ex)
            {
                resultado = new IdentityError()
                {
                    Code = "error",
                    Description = ex.Message.ToString()
                };

            }
            return resultado;
        }



        public List<object[]> Lista_Informacion_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var informacion = _contexto.Informacion.ToList();

            foreach (var item in informacion)
            {
                dato += "<tr>" +
                    "<td>" + item.Ubicacion + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Tamaño + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Fecha + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Informacion' " +
                    "onclick ='Un_Informacion(" + item.idInformacion + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_Informacion(" + item.idInformacion + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
