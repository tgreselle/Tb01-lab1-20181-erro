using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppTb01Lab1_Greselle.Models
{
    public class Automovel
    {
        public int AutomovelID { get; set; }

        [Required(ErrorMessage ="Tipo Obrigatorio")]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Descricao Obrigatorio")]
        [StringLength(300, ErrorMessage = "Maximo de 300 Caractres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Marca é obrigatoria ")]
        public string Marca { get; set; }

        public bool? Disponivel { get; set; }

        public DateTime? Datacadastro { get; set; }
    }
}
