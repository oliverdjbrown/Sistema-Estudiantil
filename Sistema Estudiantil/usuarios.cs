//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_Estudiantil
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        public int codigoUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string privilegio { get; set; }
        public Nullable<System.DateTime> fechaCreacion { get; set; }
        public Nullable<System.DateTime> fechaModificacion { get; set; }
        public Nullable<int> estatus { get; set; }
    }
}