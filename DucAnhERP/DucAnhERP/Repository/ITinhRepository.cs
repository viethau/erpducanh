using DucAnhERP.ViewModel;
using DucAnhERP.Models;
namespace DucAnhERP.Repository
{
public interface ITinhRepository : IBaseRepository<Tinh>
{
Task<List<TinhModel>> GetAllByVM(TinhModel dataModel, string groupId);
}
}
