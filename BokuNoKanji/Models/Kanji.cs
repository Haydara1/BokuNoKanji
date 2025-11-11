using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokuNoKanji.Models
{
    public class Kanji
    {
        public string? Character { get; set; }

        public string? Onyomi { get; set; }

        public string? Kunyomi { get; set; }

        public string? Meaning { get; set; }

        public int Strokes { get; set; }

        public int Grade { get; set; }
        
        public int Jlpt { get; set; }

        public int Freq { get; set; }
    }
}
