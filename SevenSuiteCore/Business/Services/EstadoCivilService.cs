using Application.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace Business.Services
{

    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly AppDbContext appDbContext;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="appDbContext"></param>
        public EstadoCivilService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Extraer todos los estados civiles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EstadoCivilModel> GetAll()
        {
            var listado = appDbContext.EstadoCivil.Select(c => new EstadoCivilModel
            {
                id_estado_civil=c.id_estado_civil,
                descripcion = c.descripcion
            });
            return listado;
        }

        /// <summary>
        /// Lista EstadoCivil
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> EstadoCivilList()
        {
            List<SelectListItem> listado = new List<SelectListItem>();
            var lista = GetAll();
            foreach (var item in lista)
            {
                listado.Add(new SelectListItem() { Text = item.descripcion, Value = item.id_estado_civil.ToString() });
            }

            return listado;
        }


    }
}
