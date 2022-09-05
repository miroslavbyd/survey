namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("typeQuestion")]
    public partial class TypeQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Type { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public TypeQuestion()
        {

        }
        public TypeQuestion(int id, string? type, string? description)
        {
            Id = id;
            Type = type;
            Description = description;
        }
    }
}
