using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
public interface IHuyenRepository : IBaseRepository<Huyen>
{
Task<List<HuyenModel>> GetAllByVM(HuyenModel dataModel, string groupId);
Task<List<TinhModel>> GetTinhs(string groupId);
}
}
