//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NotaInfo.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lab
    {
        public Lab()
        {
            this.ProfessorPerLabs = new HashSet<ProfessorPerLab>();
            this.Grades = new HashSet<Grade>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> StudyYearId { get; set; }
    
        public virtual StudyYear StudyYear { get; set; }
        public virtual ICollection<ProfessorPerLab> ProfessorPerLabs { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}