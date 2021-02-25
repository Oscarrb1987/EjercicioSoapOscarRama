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

        [WebMethod]
        public List<personasEjercicio> Persona()
        {

            var per = db.personasEjercicios.Select(x => x).Take(1);

            return per.ToList();
        }

        public List<personasEjercicio> createPersona(personasEjercicio persona)
        {
            var personas = db.personasEjercicios;

            personas.Add(persona);

            db.SaveChanges();

            return personas.ToList();
        }

        [WebMethod]
        public List<personasEjercicio> updatePersona(personasEjercicio persona)
        {

            var personas = db.personasEjercicios;

            var personaUpdate = personas.Where(p => p.Nif == persona.Nif).First();

            personaUpdate.Nombre = persona.Nombre;
            personaUpdate.Apellidos = persona.Apellidos;
            personaUpdate.Nif = persona.Nif;
            personaUpdate.Direccion = persona.Direccion;
            personaUpdate.Ciudad = persona.Ciudad;
            personaUpdate.Estado_Civil = persona.Estado_Civil;
            personaUpdate.Sexo = persona.Sexo;
            personaUpdate.Codigo_Postal= persona.Codigo_Postal;
            personaUpdate.Provincia = persona.Provincia;

            db.SaveChanges();

            return personas.ToList();
        }

        [WebMethod]
        public List<personasEjercicio> deletePersona(personasEjercicio persona)
        {
            var personas = db.personasEjercicios;

            var personaDelete = personas.Where(p => p.Nif == persona.Nif).First();

            personas.Remove(personaDelete);

            db.SaveChanges();

            return personas.ToList();
        }
    }
}
