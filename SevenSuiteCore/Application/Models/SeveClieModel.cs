using Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class SeveClieModel
    {
        public int id_clie { get; set; }   
        public string cedula { get; set; } 
        public string nombre { get; set; } 
        public string genero { get; set; }
        public DateTime fecha_nac { get; set; }
        public int id_estado_civil { get; set; }
        //public virtual EstadoCivil EstadoCivil { get; set; }
    }
}
