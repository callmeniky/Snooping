using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snooping.Infraestructure.ViewModels;
using Snooping.Infraestructure.InputModels;
using Snooping.Models;
using Snooping.Utilities;

namespace Snooping.Servicios.Interfaces
{
    public interface ISnoop : IDisposable
    {
       List<SnoopViewModel> ObtenerSnoopPerfil(string username, ref int followed, ref int followers);
       bool AgregarSnoop(SnoopInputModel snoopInputModel);
       List<SnoopViewModel> ListarSnoopsSiguiendo(int userId);
    }
}
