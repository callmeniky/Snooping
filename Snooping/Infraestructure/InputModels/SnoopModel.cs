using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snooping.Infraestructure.InputModels
{
    public class SnoopInputModel
    {
       public String Snoop { get; set; }
       public bool Private { get; set; }
       public Byte[] Image { get; set; }
       public int UserID { get; set; }

    }

  
}