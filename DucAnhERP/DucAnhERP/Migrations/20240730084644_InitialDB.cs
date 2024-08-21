using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DucAnhERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFirstLogin = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalDeptSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStep = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDeptSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevertId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStep = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    ApprovalSts = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStaffSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStaffSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStepSettings",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationType = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovalStep = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStepSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailHistories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Receiver = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MajorId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ScreenId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyType = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MDepartments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MMajors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MMajors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MMajorUserPermissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MMajorUserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPermissionControls",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPermissionControls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPermissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MajorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DSNhomDanhMuc",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhomDanhMuc", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "DSDanhMuc",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdNhomDanhMuc = table.Column<string>(nullable: true),
                    Ten = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMuc_NhomDanhMuc_IdNhomDanhMuc",
                        column: x => x.IdNhomDanhMuc,
                        principalTable: "NhomDanhMuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                }
             );

            migrationBuilder.CreateTable(
             name: "DSHopRanhThang",
             columns: table => new
             {
                 Id = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                 ThongTinLyTrinh_TuyenDuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinLyTrinh_LyTrinhTaiTimHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_TenHoGaSauPhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_TenHoGaTheoBanVe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_HinhThucHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_KetCauMuMo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_KetCauTuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_HinhThucMongHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_KetCauMong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_ChatMatTrong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinChungHoGa_ChatMatNgoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 PhuBiHoGa_CDai = table.Column<double>(type: "float", nullable: false),
                 PhuBiHoGa_CRong = table.Column<double>(type: "float", nullable: false),
                 BeTongLotMong_D = table.Column<double>(type: "float", nullable: false),
                 BeTongLotMong_R = table.Column<double>(type: "float", nullable: false),
                 BeTongLotMong_C = table.Column<double>(type: "float", nullable: false),
                 BeTongMongHoGa_D = table.Column<double>(type: "float", nullable: false),
                 BeTongMongHoGa_R = table.Column<double>(type: "float", nullable: false),
                 TBeTongMongHoGa_C = table.Column<double>(type: "float", nullable: false),
                 DeHoGa_D = table.Column<double>(type: "float", nullable: false),
                 DeHoGa_R = table.Column<double>(type: "float", nullable: false),
                 DeHoGa_C = table.Column<double>(type: "float", nullable: false),
                 TuongHoGa_D = table.Column<double>(type: "float", nullable: false),
                 TuongHoGa_R = table.Column<double>(type: "float", nullable: false),
                 TuongHoGa_CdTuong = table.Column<double>(type: "float", nullable: false),
                 DamGiuaHoGa_D = table.Column<double>(type: "float", nullable: false),
                 DamGiuaHoGa_R = table.Column<double>(type: "float", nullable: false),
                 DamGiuaHoGa_C = table.Column<double>(type: "float", nullable: false),
                 DamGiuaHoGa_CdDam = table.Column<double>(type: "float", nullable: false),
                 DamGiuaHoGa_CCaoDamGiuaTuongSoVoiDayHoGa = table.Column<double>(type: "float", nullable: false),
                 ChatMatTrong_D = table.Column<double>(type: "float", nullable: false),
                 ChatMatTrong_R = table.Column<double>(type: "float", nullable: false),
                 ChatMatNgoaiCanh_D = table.Column<double>(type: "float", nullable: false),
                 ChatMatNgoaiCanh_R = table.Column<double>(type: "float", nullable: false),
                 MuMoThotDuoi_D = table.Column<double>(type: "float", nullable: false),
                 MuMoThotDuoi_R = table.Column<double>(type: "float", nullable: false),
                 MuMoThotDuoi_C = table.Column<double>(type: "float", nullable: false),
                 MuMoThotDuoi_CdTuong = table.Column<double>(type: "float", nullable: false),
                 MuMoThotTren_D = table.Column<double>(type: "float", nullable: false),
                 MuMoThotTren_R = table.Column<double>(type: "float", nullable: false),
                 MuMoThotTren_C = table.Column<double>(type: "float", nullable: false),
                 MuMoThotTren_CdTuong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi1_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi1_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi1_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi1_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi2_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi2_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi2_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi2_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi3_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi3_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi3_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi3_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi4_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi4_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi4_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi4_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi5_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi5_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi5_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi5_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi6_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi6_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi6_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi6_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi7_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi7_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi7_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi7_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi8_Loai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi8_CanhDai = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi8_CanhRong = table.Column<double>(type: "float", nullable: false),
                 HinhThucDauNoi8_CanhCheo = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_PhanLoaiDayHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinTamDanHoGa2_HinhThucDayHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinTamDanHoGa2_DuongKinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_ChieuDay = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_D = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_R = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_C = table.Column<double>(type: "float", nullable: false),
                 ThongTinTamDanHoGa2_SoLuongNapDay = table.Column<int>(type: "int", nullable: false),

                 TTVLDCongRanh_LoaiVatLieuDao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTVLDCongRanh_TLChieuCaoDaoDa = table.Column<double>(type: "float", nullable: false),
                 TTVLDCongRanh_HLChieuCaoDaoDa = table.Column<double>(type: "float", nullable: false),

                 ThongTinVatLieuDaoHoGa_LoaiVatLieuDao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinVatLieuDaoHoGa_ChieuCaoDaoDa = table.Column<double>(type: "float", nullable: false),
                 ThongTinCaoDoHoGa_CaoDoTuNhien = table.Column<double>(type: "float", nullable: false),
                 ThongTinCaoDoHoGa_CdDinhViaHeHoanThien = table.Column<double>(type: "float", nullable: false),
                 ThongTinCaoDoHoGa_CaoDoDinhK98 = table.Column<double>(type: "float", nullable: false),
                 ThongTinCaoDoHoGa_CdDayHoGa = table.Column<double>(type: "float", nullable: false),
                 ThongTinCaoDoHoGa_CdDinhHoGa = table.Column<double>(type: "float", nullable: false),
                 ThongTinMaiDao_ChieuRongDayDaoNho = table.Column<double>(type: "float", nullable: false),
                 ThongTinMaiDao_TyLeMoMai = table.Column<double>(type: "float", nullable: false),
                 ThongTinMaiDao_SoCanhMaiTrai = table.Column<int>(type: "int", nullable: false),
                 ThongTinMaiDao_SoCanhMaiPhai = table.Column<int>(type: "int", nullable: false),
                 ToaDoX = table.Column<double>(type: "float", nullable: false),
                 ToaDoY = table.Column<double>(type: "float", nullable: false),
                 ThongTinLyTrinhTruyenDan_TuLyTrinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinLyTrinhTruyenDan_DenLyTrinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinLyTrinhTruyenDan_TuHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinLyTrinhTruyenDan_DenHoGa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDuongTruyenDan_HinhThucTruyenDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDuongTruyenDan_LoaiTruyenDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDuongTruyenDan_TenLoaiTruyenDanSauPhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTCDSLCauKienDuongTruyenDan_ChieuDai01CauKien = table.Column<double>(type: "float", nullable: false),
                 TTCDSLCauKienDuongTruyenDan_ChieuDaiMoiNoiCKien = table.Column<double>(type: "float", nullable: false),
                 TTCDSLCauKienDuongTruyenDan_SoLuongCKienDungDeTinhChieuDaiBoSung = table.Column<int>(type: "int", nullable: false),
                 TTCDSLCauKienDuongTruyenDan_TongChieuDai = table.Column<double>(type: "float", nullable: false),
                 ThongTinMongDuongTruyenDan_PhanLoaiMongCongTronCongHop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinMongDuongTruyenDan_LoaiMong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinMongDuongTruyenDan_HinhThucMong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDeCong_TenLoaiDeCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDeCong_CauTaoDeCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinDeCong_D = table.Column<double>(type: "float", nullable: false),
                 ThongTinDeCong_R = table.Column<double>(type: "float", nullable: false),
                 ThongTinDeCong_C = table.Column<double>(type: "float", nullable: false),
                 ThongTinDeCong_SlDeCong01CauKienTruyenDan = table.Column<double>(type: "float", nullable: false),
                 ThongTinDeCong_Kl01DeCong = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CDayPhuBi = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_SoCanh = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_LongSuDung = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CCaoLotMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CRongLotMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CCaoMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CRongMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinCauTaoCongTron_CCaoDe = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CauTaoTuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_CauTaoMuMo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_ChatMatTrong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_ChatMatNgoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_CCaoLotMong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongLotMong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CCaoMong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongMong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CCaoDe = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongDe = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CDayTuong01Ben = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_SoLuongTuong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongLongSuDung = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CCaoTuongCongHop = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CCaoMuMoThotDuoi = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongMuMoDuoi = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CCaoMuMoThotTren = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongMuMoTren = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_LoaiThanhChong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_CauTaoThanhChong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTKTHHCongHopRanh_CCaoThanhChong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CRongThanhChong = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_CDai = table.Column<double>(type: "float", nullable: false),
                 TTKTHHCongHopRanh_SoLuongThanhChong = table.Column<double>(type: "float", nullable: false),
                 ThongTinKichThuocHinhHocOngNhua_CDayPhuBi = table.Column<double>(type: "float", nullable: false),
                 ThongTinKichThuocHinhHocOngNhua_SoCanh = table.Column<int>(type: "int", nullable: false),
                 ThongTinKichThuocHinhHocOngNhua_LongSuDung = table.Column<double>(type: "float", nullable: false),
                 ThongTinKichThuocHinhHocOngNhua_CCaoDemCat = table.Column<double>(type: "float", nullable: false),
                 ThongTinKichThuocHinhHocOngNhua_CCaoDapCat = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_HinhThucMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_CauTaoChanKhay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_CauTaoGiangDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_HinhThucHanhLangBaoVe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_PhanLoaiChanKhay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_CCaoLotChanKhay = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongLotChanKhay = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongLotChanKhay = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CCaoMongChanKhay = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongMongChanKhay = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongMongChanKhay = table.Column<int>(type: "int", nullable: false),
                 ThongTinRanhThang_CCaoLot = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongLot = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CCaoMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongMong = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_PhanLoaiMai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_CRongMai = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CDayMai = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongMai = table.Column<int>(type: "int", nullable: false),
                 ThongTinRanhThang_PhanLoaiGiangDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 ThongTinRanhThang_CCaoLotGiangDinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongLotGiangDinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongLotGiangDinh = table.Column<int>(type: "int", nullable: false),
                 ThongTinRanhThang_CCaoMongGiangDinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongMongGiangDinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongMongGiangDinh = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_PhanLoaiHanhLangBaoVe = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CCaoHanhLangBaoVe = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_CRongHanhLangBaoVe = table.Column<double>(type: "float", nullable: false),
                 ThongTinRanhThang_SoLuongHangLangBaoVe = table.Column<int>(type: "int", nullable: false),
                 TTTDCongHoRanh_TenLoaiTamDanTieuChuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTTDCongHoRanh_CauTaoTamDanTruyenDanTamDanTieuChuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTTDCongHoRanh_CDai = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_CRong = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_CCao = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_TenLoaiTamDanLoai02 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTTDCongHoRanh_CauTaoTamDanTruyenDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 TTTDCongHoRanh_CRong1 = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_CCao1 = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_ChieuDaiMoiNoi = table.Column<double>(type: "float", nullable: false),
                 TTTDCongHoRanh_SoLuongTDanDungDeTinhChieuDaiBoSung = table.Column<int>(type: "int", nullable: false),
                 CDThuongLuu_HienTrangTruocKhiDaoThuongLuu = table.Column<double>(type: "float", nullable: false),
                 CDThuongLuu_DayDongChay = table.Column<double>(type: "float", nullable: false),
                 CDThuongLuu_DinhTrongLongSuDung = table.Column<double>(type: "float", nullable: false),
                 CDThuongLuu_ChieuCaoRanhThangTuDayDongChayDenDinh = table.Column<double>(type: "float", nullable: false),
                 CDHaLu_HienTrangTruocKhiDaoHaLuu = table.Column<double>(type: "float", nullable: false),
                 CDHaLu_DayDongChay = table.Column<double>(type: "float", nullable: false),
                 CDHaLu_DinhTrongLongSuDung = table.Column<double>(type: "float", nullable: false),
                 CDHaLu_ChieuCaoRanhThangTuDayDongChayDenDinh = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_ChieuRongDayDaoNho = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_TyLeMoMai = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_SoCanhMaiTrai = table.Column<int>(type: "int", nullable: false),
                 TTMDRanhOngThang_SoCanhMaiPhai = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_ChieuRongDayDaoNho1 = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_TyLeMoMai1 = table.Column<double>(type: "float", nullable: false),
                 TTMDRanhOngThang_SoCanhMaiTrai1 = table.Column<int>(type: "int", nullable: false),
                 TTMDRanhOngThang_SoCanhMaiPhai1 = table.Column<double>(type: "float", nullable: false),
                 TuToaDoX = table.Column<double>(type: "float", nullable: false),
                 TuToaDoY = table.Column<double>(type: "float", nullable: false),
                 DenToaDoX = table.Column<double>(type: "float", nullable: false),
                 DenToaDoY = table.Column<double>(type: "float", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_HopRanhThang", x => x.Id);
             });


            migrationBuilder.CreateIndex(
               name: "IX_DanhMuc_IdNhomDanhMuc",
               table: "DanhMuc",
               column: "IdNhomDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "ApprovalDeptSettings");

            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "ApprovalStaffSettings");

            migrationBuilder.DropTable(
                name: "ApprovalStepSettings");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmailHistories");

            migrationBuilder.DropTable(
                name: "MCompanies");

            migrationBuilder.DropTable(
                name: "MDepartments");

            migrationBuilder.DropTable(
                name: "MMajors");

            migrationBuilder.DropTable(
                name: "MMajorUserPermissions");

            migrationBuilder.DropTable(
                name: "MPermissionControls");

            migrationBuilder.DropTable(
                name: "MPermissions");

            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DSDanhMuc");

            migrationBuilder.DropTable(
                name: "DSNhomDanhMuc");

            migrationBuilder.DropTable(
              name: "DSHopRanhThang");

        }
    }
}
