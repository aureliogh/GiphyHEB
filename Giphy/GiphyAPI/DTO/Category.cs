using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiphyAPI.DTO
{
    public class Category : DataTransferObject
    {
        public int? id_category { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public int sorting { get; set; }
        public int id_user { get; set; }
        public DateTime? adddttm { get; set; }

        public override bool Exists
        {
            get { return (this.id_category.GetValueOrDefault(-1) > 0); }
        }
    }
}