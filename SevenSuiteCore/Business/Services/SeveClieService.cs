using Application.Models;
using Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Business.Services
{
    public class SeveClieService : ISeveClieService
    {
        private readonly AppDbContext appDbContext;

        public SeveClieService(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Traer todos los registros, para listar
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SeveClieModel> GetAll() 
        { 
            var listado = appDbContext.SeveClie.Select(c => new SeveClieModel
            { 
                id_clie = c.id_clie,
                cedula = c.cedula,
                nombre = c.nombre,
                genero = c.genero
            });
            return listado;
        }

        /// <summary>
        /// Traer solo un registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SeveClie GetById(int id)
        {      
            SeveClie entities = appDbContext.SeveClie.FirstOrDefault(c=>c.id_clie==id);
            return entities;
        }

        /// <summary>
        /// Agregar registro a la BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(SeveClieModel model)
        {
            try
            {
                // Mapeado                
                SeveClie entity = new SeveClie
                {
                    id_clie = model.id_clie,
                    cedula = model.cedula,
                    nombre = model.nombre,
                    genero = model.genero,
                    fecha_nac = model.fecha_nac,
                    id_estado_civil = model.id_estado_civil
                };

                appDbContext.SeveClie.Add(entity);
                appDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Actualizar registro de la BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(SeveClieModel model)
        {
            try
            {
                // Mapeado                
                SeveClie entity = new SeveClie
                {
                    id_clie = model.id_clie,
                    cedula = model.cedula,
                    nombre = model.nombre,
                    genero = model.genero,
                    fecha_nac = model.fecha_nac,
                    id_estado_civil = model.id_estado_civil
                };

                appDbContext.SeveClie.Update(entity);
                appDbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Eliminar registro de la BDD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(int id)
        {
            try
            {
                var entity = appDbContext.SeveClie.FirstOrDefault(c => c.id_clie.Equals(id));

                appDbContext.SeveClie.Remove(entity);
                appDbContext.SaveChanges();

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
