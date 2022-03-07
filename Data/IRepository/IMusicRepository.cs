
using playlist.Models;
using playlist.Service.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Data.IRepository
{
    public interface IMusicRepository
    {
        Task<IList<MusicView>> GetAllAsync();
        Task<MusicView> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Music> UpdateAsync(Music music);
        Task CreateAsync(Music music);
    }
}
