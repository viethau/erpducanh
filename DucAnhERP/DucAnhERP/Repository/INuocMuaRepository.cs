using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface INuocMuaRepository : IBaseRepository<MNuocMua>
    {
        Task<List<NuocMuaModel>> GetData();
        Task<int> MultiInsert(List<MNuocMua> entities);
    }
}
