using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
public interface IXaRepository : IBaseRepository<Xa>
{
Task<List<XaModel>> GetAllByVM(XaModel dataModel, string groupId);
Task<List<TinhModel>> GetTinhs(string groupId);
Task<List<HuyenModel>> GetHuyens(string groupId);
}
}
