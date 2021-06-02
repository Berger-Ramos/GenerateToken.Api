using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenerateToken.Entity.JsonInput
{
    public class CreateTokenJsonInput
    {
       
        public string Client_id { get; set; }
        public string Client_secret { get; set; }
        public string Grant_type { get; set; }
        public string Scope { get; set; }

    }
}
