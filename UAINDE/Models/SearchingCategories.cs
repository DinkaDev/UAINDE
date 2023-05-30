using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UAINDE.Models
{
    public class SearchingCategories
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Сфера")]
        public string WorkingSphere { get; set; }
        [Required]
        [Display(Name = "Спеціальність")]
        public string Speciality { get; set; }
        [Required]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "Прізвище")]
        public string? LastName { get; set; }
        //
        [Required]
        [Display(Name = "Місто")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Досвід роботи")]
        public int WorkExperience { get; set; }
        [Display(Name = "Соціальні мережі")]
        public string? SocialNetworkLink { get; set; }
        [Display(Name = "Додаткова інформація")]
        public string? AdditionalInformation { get; set; }
        [Display(Name = "Номер телефону")]
        public long? PhoneNumber { get; set; }
        [Display(Name = "Фото")]
        public string? PhotoLink { get; set; }
    }
}
