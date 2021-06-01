using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateToken.Entity.JsonOutput
{
    public class GenerateTokenJsonOutPut
    {
        public string Token { get; set; }
        public int Expires_in { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
    }
}
