using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardomEvaluationTest.Infraestructure.ViewModels;

namespace MardomEvaluationTest.Repositorios.Interfaces
{
    public interface IPerfiles
    {
        List<ProfileViewModel> ObtenerPerfilesPorNombre(string criterio, int currentUserId);
        List<SnoopViewModel> ObtenerPerfil(string username, int current, 
            out int followers, out int followed, ref bool esSeguidor);
        ProfileViewModel ObtenerInfoPorID(int usuarioId);
    }
}
