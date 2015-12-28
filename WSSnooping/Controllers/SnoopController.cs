using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSSnooping.Infraestructure.ViewModels;
using WSSnooping.Infraestructure.InputModels;
using WSSnooping.Models.Repositorios;
using WSSnooping.Models.Repositorios.Servicios;

namespace WSSnooping.Controllers
{
    public class SnoopController : ApiController
    {
        private Snoop servSnoop;

        public SnoopController()
        {
            this.servSnoop = new Snoop();
        }

        public List<SnoopViewModel> GetEntradasUsuariosSeguidos(int usuarioId)
        {
            List<SnoopViewModel> lstSnoopVw = new List<SnoopViewModel>();

            lstSnoopVw = servSnoop.ListarSnoops(usuarioId);

            return lstSnoopVw;
        }

        public bool PutSnoop(SnoopInputModel snoopInput)
        {
            bool result = false;

            return result;
        }
    }
}
