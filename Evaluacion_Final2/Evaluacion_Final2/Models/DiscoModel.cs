using Evaluacion_Final2.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluacion_Final2.Models
{
    public class DiscoModel
    {
        public ApplicationDbContext _contexto;

        public DiscoModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IdentityError Nuevo_Disco_Model(
            string Nombre,
            string Capacidad,
            string Tipo)
        {
            IdentityError resultado = new IdentityError();
            Disco disco = new Disco()
            {
                Nombre = Nombre,
                Capacidad = Capacidad,
                Tipo = Tipo

            };
            try
            {

                _contexto.Disco.Add(disco);
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

        public Disco Un_Disco_Model(int idDisco)
        {
            // return _contexto.Cliente.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            Disco disco = (from d in _contexto.Disco
                                             where d.idDisco == idDisco
                           select d).FirstOrDefault();
            return disco;
        }

        public IdentityError Editar_Disco_Model(
            int idDisco,
            string Nombre,
            string Capacidad,
            string Tipo)
        {
            IdentityError resultado = new IdentityError();
            Disco disco = new Disco()
            {
                Nombre  = Nombre,
                Capacidad = Capacidad,
                Tipo = Tipo,
                idDisco = idDisco
            };
            try
            {
                _contexto.Disco.Update(disco);
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
        public IdentityError Eliminar_Disco_Model(
           int idDisco)
        {
            IdentityError resultado = new IdentityError();
            Disco disco = new Disco()
            {
                idDisco = idDisco
            };
            try
            {
                _contexto.Disco.Remove(disco);
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



        public List<object[]> Lista_Disco_Model()
        {
            List<object[]> listaRegresa = new List<object[]>();
            string dato = "";

            var disco = _contexto.Disco.ToList();

            foreach (var item in disco)
            {
                dato += "<tr>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" + item.Capacidad + "</td>" +
                    "<td>" + item.Tipo + "</td>" +
                    "<td>  <a data-toggle='modal' data-target='#Ingreso_Disco' " +
                    "onclick ='Un_Disco(" + item.idDisco + ")' " +
                    "class='btn btn-primary'>Editar</a> |" +
                    "<a onclick='eliminar_disco(" + item.idDisco + ")'" +
                    "class='btn btn-danger'>Delete</a></td>" +
                    "</tr>";
            }
            object[] objeto = { dato };
            listaRegresa.Add(objeto);
            return listaRegresa;


        }
    }
}
