using System;
using System.ComponentModel.DataAnnotations;

namespace CinemaCentre.Models
{
    public class Person
    {
        [Required(ErrorMessage ="Vul je voornaam alstublieft in!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage ="Vul je achternaam alstublieft in!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vul je emailadres alstublieft in!")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required(ErrorMessage = "Vul je opmerking alstublieft in!")]
        public string Message { get; set; }

    }
}
