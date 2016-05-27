using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooping.Servicios.Interfaces
{
    public interface IFollow
    {
        bool Seguir(string uFollower, string uFollowed);
        bool DejarDeSeguir(int uFollower, string uFollowed);
        bool VerificarEsSeguidor(string followed, int currentUser);
        
    }
}
