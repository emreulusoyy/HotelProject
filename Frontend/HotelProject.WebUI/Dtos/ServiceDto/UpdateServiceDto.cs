using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet icon linki giriniz.")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet Başlığı giriniz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet Açıklaması giriniz.")]
        public string Description { get; set; }
    }
}
