using System.ComponentModel.DataAnnotations;

namespace Linkedin.Models.Entites
{
    public enum Level
    {
        Native,
        Fluent,
        [Display(Name = "Very Good")]
        veryGood,
        Good,
        Fair

    }
}