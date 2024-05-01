using System.ComponentModel.DataAnnotations;

namespace TempMotoWeb.Models
{
    public class Medicao
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Altitude { get; set; }
        public float Temperatura { get; set; }
        public float Umidade { get; set; }
        [Display(Name = "Número de satelites")]
        public int Num_Satelites { get; set; }
        public float Velocidade { get; set; }
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString = "{0: HH:mm dd/MM/yyyy}")]
        public DateTime? Data_Medicao { get; set; } = DateTime.Now.AddHours(-3);
        [Display(Name = "Endereço")]
        public string? endereco { get; set; }
    }
}
