namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("survey")]
    public partial class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Survey()
        {

        }
        public Survey(int id, string name, DateTime dateCreation, DateTime dateFrom, DateTime dateTo)
        {
            Id = id;
            Name = name;
            DateCreation = dateCreation;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }
    }
}
