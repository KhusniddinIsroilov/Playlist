using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Models
{
    public class Singer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CreatedDate { get; set; }
    }
}
