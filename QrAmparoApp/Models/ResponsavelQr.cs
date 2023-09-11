using System;
using System.Collections.Generic;
using System.Text;

namespace QrAmparoApp.Models
{
    public class ResponsavelQr
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string GrauParentesco { get; set; }
        public Idoso Idoso { get; set; }
        public Usuario Usuario { get; set; }

    }
}
