using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiphyAPI.DTO
{
    public class User : DataTransferObject
    {
        public int? id_user { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public DateTime? adddttm { get; set; }
        public DateTime? lastlogin { get; set; }

        public override bool Exists
        {
            get { return (this.id_user.GetValueOrDefault(-1) > 0);  }
            
        }
    }
}