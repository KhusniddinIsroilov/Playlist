using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service.ViewModels
{
    public class MusicView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public int Length { get; set; }
        public string Playlist { get; set; }
        public string CreatedDate { get; set; }
    }
}
