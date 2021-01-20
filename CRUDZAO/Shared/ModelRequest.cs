using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDZAO.Shared
{
    public class ModelRequest
    {
        [Required]
        public Guid id { get; set; }

        [Required]
        public string value { get; set; }

        public ModelRequest Clone() =>
            (ModelRequest)this.MemberwiseClone();

    }
}
