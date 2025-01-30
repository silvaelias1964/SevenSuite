using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business.Services
{
    /// <summary>
    /// Interfaz de EstadoCivil
    /// </summary>
    public interface IEstadoCivilService
    {
        /// <summary>
        /// Extraer todos los estados civiles
        /// </summary>
        /// <returns></returns>
        IEnumerable<EstadoCivilModel> GetAll();

        /// <summary>
        /// Lista EstadoCivil
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> EstadoCivilList();
    }
}
