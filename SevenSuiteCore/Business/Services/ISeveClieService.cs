using Application.Models;
using Entities;
using System.Collections.Generic;

namespace Business.Services
{
    /// <summary>
    /// Interface de SeveClieService
    /// </summary>
    public interface ISeveClieService
    {
        /// <summary>
        /// Traer todos los registros, para listar
        /// </summary>
        /// <returns></returns>
        IEnumerable<SeveClieModel> GetAll();

        /// <summary>
        /// Traer solo un registro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SeveClie GetById(int id);

        /// <summary>
        /// Agregar registro a la BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(SeveClieModel model);

        /// <summary>
        /// Actualizar registro de la BD
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Edit(SeveClieModel model);

        /// <summary>
        /// Eliminar registro de la BDD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string Delete(int id);

    }
}