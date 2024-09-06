using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface INuocMuaRepository : IBaseRepository<NuocMua>
    {
        Task<List<NuocMuaModel>> GetData();
        Task<int> MultiInsert(List<NuocMua> entities);
    }
}
