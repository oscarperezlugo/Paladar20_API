//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Paladar20_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MA_CIERRES_POS_PARCIAL
    {
        public string cs_ORGANIZACION { get; set; }
        public string cs_LOCALIDAD { get; set; }
        public string cs_DOCUMENTO { get; set; }
        public string cs_TIPO_MOVIMIENTO { get; set; }
        public System.DateTime ds_FECHA { get; set; }
        public string cs_CAJA { get; set; }
        public decimal cs_TURNO { get; set; }
        public string cs_CAJERO { get; set; }
        public string cs_USUARIO { get; set; }
        public string cs_NOMBRE_CAJERO { get; set; }
        public string cs_MONEDA_CIERRE { get; set; }
        public double cs_FACTOR_MONEDA { get; set; }
        public double nu_MONTO_PARCIAL { get; set; }
        public string tu_OBSERVACION { get; set; }
    }
}
