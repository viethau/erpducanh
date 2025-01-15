using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
public interface IKhuHanhChinhRepository : IBaseRepository<KhuHanhChinh>
{
Task<List<KhuHanhChinhModel>> GetAllByVM(KhuHanhChinhModel dataModel, string groupId);
Task<List<TinhModel>> GetTinhs(string groupId);
Task<List<HuyenModel>> GetHuyens(string groupId);
Task<List<XaModel>> GetXas(string groupId);
}
}
