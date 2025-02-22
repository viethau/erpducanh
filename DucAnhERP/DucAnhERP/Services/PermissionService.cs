using DucAnhERP.Models;
using DucAnhERP.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DucAnhERP.Repository;

namespace DucAnhERP.Services
{
    public class PermissionService
    {
        private readonly IPhanQuyenRepository _phanQuyenService;
        private readonly ILogger<PermissionService> _logger;
        private List<PermissionModel> _listPer = new();
        private ApplicationUser _user;

        public PermissionService(IPhanQuyenRepository phanQuyenService, ILogger<PermissionService> logger)
        {
            _phanQuyenService = phanQuyenService;
            _logger = logger;
        }

        public async Task InitializePermissions(string groupId, ApplicationUser user, string majorId)
        {
            _user = user;
            _listPer = await _phanQuyenService.getAllPermissionByMajor(groupId, "", user, majorId);

            if (_listPer == null || !_listPer.Any())
            {
                _logger.LogWarning("No permissions found for groupId: {GroupId}, majorId: {MajorId}", groupId, majorId);
            }
            else
            {
                _logger.LogInformation("Permissions loaded successfully for groupId: {GroupId}, majorId: {MajorId}", groupId, majorId);
            }
        }

        public bool HasPermission(int permissionType)
        {
            return _user.CreateBy == "symtem" || _listPer.Any(p => p.PermissionType == permissionType);
        }
    }
}
