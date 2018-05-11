using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiphyAPI.DTO
{
    public class DataTransferObject
    {

        /// <summary>
        /// Exists should be overridden in each implementing class
        /// </summary>
        public virtual bool Exists
        {
            get { return false; }
        }

        /// <summary>
        /// ToString return
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} [Exists={1}]",
                this.GetType().ToString(),
                this.Exists.ToString());
        }
    }
}