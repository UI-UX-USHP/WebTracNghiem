using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TracNghiem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayThi = table.Column<DateOnly>(type: "date", nullable: true),
                    ThoiGianThi = table.Column<int>(type: "int", nullable: true),
                    TenDeThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongCauKho = table.Column<int>(type: "int", nullable: true),
                    SoLuongCauHoi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MucDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMucDo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MucDo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVien",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    GioiTinh = table.Column<byte>(type: "tinyint", nullable: true),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaGiangVien = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CauHoi1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAnA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAnB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAnC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAnD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMonHoc = table.Column<int>(type: "int", nullable: true),
                    MaMucDo = table.Column<int>(type: "int", nullable: true),
                    MaMonHocNavigationId = table.Column<int>(type: "int", nullable: true),
                    MaMucDoNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CauHoi_MonHoc_MaMonHocNavigationId",
                        column: x => x.MaMonHocNavigationId,
                        principalTable: "MonHoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CauHoi_MucDo_MaMucDoNavigationId",
                        column: x => x.MaMucDoNavigationId,
                        principalTable: "MucDo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeThiCauHoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDeThi = table.Column<int>(type: "int", nullable: true),
                    MaCauHoi = table.Column<int>(type: "int", nullable: true),
                    MaCauHoiNavigationId = table.Column<int>(type: "int", nullable: true),
                    MaDeThiNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThiCauHoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeThiCauHoi_CauHoi_MaCauHoiNavigationId",
                        column: x => x.MaCauHoiNavigationId,
                        principalTable: "CauHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeThiCauHoi_DeThi_MaDeThiNavigationId",
                        column: x => x.MaDeThiNavigationId,
                        principalTable: "DeThi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KetQua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSinhVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DapAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDeThiCauHoi = table.Column<int>(type: "int", nullable: true),
                    MaDeThiCauHoiNavigationId = table.Column<int>(type: "int", nullable: true),
                    MaSinhVienNavigationId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KetQua_DeThiCauHoi_MaDeThiCauHoiNavigationId",
                        column: x => x.MaDeThiCauHoiNavigationId,
                        principalTable: "DeThiCauHoi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KetQua_ThanhVien_MaSinhVienNavigationId",
                        column: x => x.MaSinhVienNavigationId,
                        principalTable: "ThanhVien",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_MaMonHocNavigationId",
                table: "CauHoi",
                column: "MaMonHocNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CauHoi_MaMucDoNavigationId",
                table: "CauHoi",
                column: "MaMucDoNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThiCauHoi_MaCauHoiNavigationId",
                table: "DeThiCauHoi",
                column: "MaCauHoiNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeThiCauHoi_MaDeThiNavigationId",
                table: "DeThiCauHoi",
                column: "MaDeThiNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_MaDeThiCauHoiNavigationId",
                table: "KetQua",
                column: "MaDeThiCauHoiNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQua_MaSinhVienNavigationId",
                table: "KetQua",
                column: "MaSinhVienNavigationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQua");

            migrationBuilder.DropTable(
                name: "DeThiCauHoi");

            migrationBuilder.DropTable(
                name: "ThanhVien");

            migrationBuilder.DropTable(
                name: "CauHoi");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "MucDo");
        }
    }
}
