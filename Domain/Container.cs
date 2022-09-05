namespace ankiety.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("container")]
    public partial class Container
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Description { get; set; }
        public int SurveyId { get; set; }
        public Container()
        {

        }
        public Container(int id, string description, int surveyId)
        {
            Id = id;
            Description = description;
            SurveyId = surveyId;
        }
    }
}
