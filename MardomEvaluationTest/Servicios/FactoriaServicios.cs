using Snooping.Servicios.Interfaces;
using Snooping.Servicios.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MardomEvaluationTest.Servicios
{
    public class FactoriaServicios : IDisposable
    {
        public static ISnoop GetSnoopInstance()
        {
            return new Snoop();
        }

        public static IFollow GetFollowInstance()
        {
            return new Follow();
        }

        public static IPerfiles GetPerfilesInstance()
        {
            return new Perfiles();
        }

        public void Dispose()
        {
           
        }
    }
}