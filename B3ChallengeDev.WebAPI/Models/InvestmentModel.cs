using System.ComponentModel.DataAnnotations;

namespace B3ChallengeDev.WebAPI.Models
{
    public class InvestmentModel
    {
        [Required(ErrorMessage = "Propriedade InitialValue é obrigatória")]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Propriedade InitialValue deve ser um valor positivo")]
        public decimal InitialValue { get; set; }

        [Required(ErrorMessage = "Propriedade RescueMonths é obrigatória")]
        [Range(2, 360, ErrorMessage = "Propriedade RescueMonths deve ser no mínimo 1 mês e no máximo 360 mêses")]
        public int RescueMonths { get; set; }

        public InvestmentModel(decimal initialValue, int rescueMonths)
        {
            InitialValue = initialValue;
            RescueMonths = rescueMonths;
        }
    }
}