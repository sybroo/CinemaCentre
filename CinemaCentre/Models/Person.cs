using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaCentre.Models
{
    public class Person
    {
        [Display(Name="Voornaam")]
        [Required(ErrorMessage ="Vul je voornaam alstublieft in!")]
        public string FirstName { get; set; }

        [Display(Name = "achternaam")]
        [Required(ErrorMessage ="Vul je achternaam alstublieft in!")]
        public string LastName { get; set; }

        [Display(Name = "emailadres")]
        [Required(ErrorMessage = "Vul je emailadres alstublieft in!")]
        public string Email { get; set; }

        [Display(Name = "telefoonnummer")]
        public string Phone { get; set; }

        [Display(Name = "opmerking")]
        [Required(ErrorMessage = "Vul je opmerking alstublieft in!")]
        public string Message { get; set; }

    }
}
