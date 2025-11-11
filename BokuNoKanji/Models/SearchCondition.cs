using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokuNoKanji.Models
{
    public class SearchCondition
    {
        public string? Field { get; set; }   // e.g. "Strokes", "Grade", "JLPT"
        public string? Operator { get; set; } // e.g. "=", "<", ">", "Contains"
        public string? Value { get; set; }   // user input
        public string? Logical { get; set; } // "AND" / "OR"
    }
}
