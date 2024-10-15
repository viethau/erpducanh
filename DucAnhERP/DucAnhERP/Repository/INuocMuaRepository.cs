using DucAnhERP.Models;
using DucAnhERP.ViewModel;

namespace DucAnhERP.Repository
{
    public interface INuocMuaRepository : IBaseRepository<NuocMua>
    {

        Task<List<NuocMuaModel>> GetAllByVM(NuocMuaModel nuocMuaModel);
        Task<int> MultiInsert(List<NuocMua> entities);
        Task<string> InsertLaterFlag(NuocMua entity, int FlagLast);
        Task<List<NuocMuaModel>> GetBaoCaoTTHoGa(NuocMuaModel nuocMuaModel);
        Task<List<NuocMuaModel>> GetBaoCaoKLBPhapHGa(NuocMuaModel nuocMuaModel);
        Task<List<NuocMuaModel>> GetBaoCaoKHopHGaTDan(NuocMuaModel nuocMuaModel);
        Task<List<PLHGBaoCaoModel>> GetBaoCaoTongSLHGa();
        Task<List<PLHGBaoCaoSLHGTTModel>> GetBaoCaoTongSLHGaTTuyen();
        Task<List<PLTDHGBaoCaoTSLTDHGModel>> GetBaoCaoTongSLTDanHGa();
        Task<List<PLTDHGBaoCaoTSLTDHGTTModel>> GetBaoCaoSLTDanHGaTTuyen();

    }
}
