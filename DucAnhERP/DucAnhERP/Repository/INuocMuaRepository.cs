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
        Task<List<KTHHMDCModel>> GetBaoCaoKTHHMDC();
        Task<List<NuocMuaModel>> GetBaoCaoKTHHRX();
        Task<List<NuocMuaModel>> GetBaoCaoKTHHTC();
        Task<List<NuocMuaModel>> GetBaoCaoKTHHTDRX();
        Task<List<NuocMuaModel>> GetBaoCaoKTHHRBT();
        Task<List<NuocMuaModel>> GetBaoCaoKTHHTDRBT();
        Task<List<SLCKModel>> GetBaoCaoSLCKCT(string HinhThucTruyenDan);
        Task<List<SLTDanTTuyenModel>> GetBaoCaoSLTDTT();
        Task<List<TKSLModel>> GetBaoCaoSLMong(string HinhThucTruyenDan);
        Task<List<TKSLTTModel>> GetBaoCaoSLMongTH();
        Task<List<TKSLModel>> GetBaoCaoSLDe();
        Task<List<TKSLTTModel>> GetBaoCaoSLDeTT();
        Task<List<TKSLModel>> GetBaoCaoSLTT();
        Task<List<TKSLTTModel>> GetBaoCaoSLTTTT();

        Task<List<TKSLModel>> GetBaoCaoSLTDan(string HinhThucTruyenDan);
        Task<List<TKSLTTModel>> GetBaoCaoSLTDanTT();
        Task<List<NuocMuaModel>> GetBaoCaoMongCTSDThep();
        Task<List<NuocMuaModel>> GetBaoCaoCongTronSDThep();
        Task<List<NuocMuaModel>> GetBaoCaoDeCongSDThep();
        Task<List<NuocMuaModel>> GetBaoCaoCongHopSDThep()
    }
}
