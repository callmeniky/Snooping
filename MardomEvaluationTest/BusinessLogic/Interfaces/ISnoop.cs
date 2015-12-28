using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MardomEvaluationTest.Infraestructure.ViewModels;
using MardomEvaluationTest.Infraestructure.InputModels;
using MardomEvaluationTest.Models;
using MardomEvaluationTest.Utilities;

namespace MardomEvaluationTest.BusinessLogic.Interfaces
{
    public interface ISnoop
    {
       List<SnoopViewModel> ObtenerSnoopPerfil(string username, ref int followed, ref int followers);
       bool AgregarSnoop(SnoopInputModel snoopInputModel);
       List<SnoopViewModel> ListarSnoopsSiguiendo(int userId);
    }
}
