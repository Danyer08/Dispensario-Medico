//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DispensarioMedicoUnapec
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registro_Visitas
    {
        public int IdVisita { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public System.DateTime FechaVisita { get; set; }
        public System.TimeSpan HoraVisita { get; set; }
        public string Sintomas { get; set; }
        public int IdMedicamento { get; set; }
        public string Recomendaciones { get; set; }
        public bool Estado { get; set; }
    
        public virtual Medicamentos Medicamentos { get; set; }
        public virtual Medicos Medicos { get; set; }
        public virtual Pacientes Pacientes { get; set; }
    }
}
