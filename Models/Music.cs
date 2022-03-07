using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SingerID { get; set; }
        public int Length { get; set; }
        public int PlaylistID { get; set; }
        public string CreatedDate { get; set; }
    }
}
