using System.ComponentModel.DataAnnotations;

namespace MeuCurriculo.Models {
    public class Habilidade : EntidadeBase {
        [Required]
        public string Descricao { get; set; }
    }
}
