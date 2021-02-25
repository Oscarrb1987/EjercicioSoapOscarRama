using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace EjercicioSoapOscarRama
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        
        private PersonaSoapEntities1 db = new PersonaSoapEntities1();
        /*
         * DATE: 25/02/21
         */
        [WebMethod]
        public List<personasEjercicio> Persona()
        {

            var per = db.personasEjercicios.Select(x => x).Take(1);

            return per.ToList();
        }
        /*
         * CREATE
         */
        [WebMethod]
        public List<personasEjercicio> createPersona(personasEjercicio persona)
        {
            var per = db.personasEjercicios;

            per.Add(persona);

            db.SaveChanges();

            return per.ToList();
        }
        /*
         * UPDATE
         */
        [WebMethod]
        public List<personasEjercicio> updatePersona(personasEjercicio persona)
        {

            var per = db.personasEjercicios;

            var perUpdate = per.Where(p => p.Nif == persona.Nif).First();

            perUpdate.Nombre = persona.Nombre;
            perUpdate.Apellidos = persona.Apellidos;
            perUpdate.Nif = persona.Nif;
            perUpdate.Direccion = persona.Direccion;
            perUpdate.Ciudad = persona.Ciudad;
            perUpdate.Estado_Civil = persona.Estado_Civil;
            perUpdate.Sexo = persona.Sexo;
            perUpdate.Codigo_Postal= persona.Codigo_Postal;
            perUpdate.Provincia = persona.Provincia;

            db.SaveChanges();

            return per.ToList();
        }
        /*
         * DELETE
         */
        [WebMethod]
        public List<personasEjercicio> deletePersona(personasEjercicio persona)
        {
            var per = db.personasEjercicios;

            var personaDelete = per.Where(p => p.Nif == persona.Nif).First();

            per.Remove(personaDelete);

            db.SaveChanges();

            return per.ToList();
        }
    }
}
