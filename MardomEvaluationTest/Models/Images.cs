//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MardomEvaluationTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Images
    {
        public Images()
        {
            this.Snoops = new HashSet<Snoops>();
        }
    
        public System.Guid ImageGuid { get; set; }
        public byte[] ImageBin { get; set; }
    
        public virtual ICollection<Snoops> Snoops { get; set; }
    }
}
