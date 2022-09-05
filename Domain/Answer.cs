namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("answer")]
    public partial class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Signature { get; set; }

        public int? ValueINT { get; set; }

        public DateTime? ValueDATETIME { get; set; }

        [StringLength(100)]
        public string? ValueTEXT { get; set; }

        public bool? ValueBIT { get; set; }

        public int? QuestionId { get; set; }
        public Answer()
        {

        }
        public Answer(int id, string? signature, int? valueINT, DateTime? valueDATETIME, string? valueTEXT, bool? valueBIT, int? questionId)
        {
            Id = id;
            Signature = signature;
            ValueINT = valueINT;
            ValueDATETIME = valueDATETIME;
            ValueTEXT = valueTEXT;
            ValueBIT = valueBIT;
            QuestionId = questionId;
        }
    }
}
