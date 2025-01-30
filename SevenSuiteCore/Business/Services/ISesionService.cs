using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    
    public interface ISesionService
    {
        public bool SetSesion(int Id, string UserName);

        public string[] GetSesion();
    }
}
