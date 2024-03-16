using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosVideosCore.Model
{
    public class Video
    {
        public int Id { get; set; }
        public string Descritivo { get; set; }
        public string CaminhoVideo { get; set; }
        public string? CaminhoVideoZip { get; set; }
        public StatusVideo StatusVideo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataFimProcessamento { get; set; }
    }
}
