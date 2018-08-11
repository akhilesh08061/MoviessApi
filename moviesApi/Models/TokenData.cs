using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moviesApi.Models
{
    public class TokenData
    {
        public string client_id { get; set; }

        public string client_Secret { get; set; }

        public string scope { get; set; }

        public string grant_type { get; set; }

        public string username { get; set; }
        
        public string password { get; set; }
    }
}
