﻿namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("question")]
    public partial class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int ContainerId { get; set; }
        public int TypeQuestionId { get; set; }
        public Question()
        {

        }
        public Question(int id, string description, int containerId, int typeQuestionId)
        {
            Id = id;
            Description = description;
            ContainerId = containerId;
            TypeQuestionId = typeQuestionId;
        }
    }
}
