using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateToken.Entity.JsonOutPut
{
    public class GenerateTokenJsonOutPut
    {
        [Required]
        public string Token { get; set; }
        public int Expires_in { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
}
