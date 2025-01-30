using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	/// <summary>
	/// Entidad donde se guardan los datos principales
	/// </summary>
    public class SeveClie
    {		
		public int id_clie { get; set; }   // PK 

		public string cedula { get; set; }   //[nvarchar] (15) NULL,
		public string nombre { get; set; }   //	[nvarchar] (100) NULL,
		public string genero { get; set; }   // [nchar] (1) NULL,
		public DateTime fecha_nac { get; set; }
		public int id_estado_civil { get; set; }

    }
}
