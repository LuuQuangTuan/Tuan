using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class creatDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duAns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    luongThuong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duAns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hoTen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ngaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    sDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    diaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cMND = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "suKiens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ngayBatDau = table.Column<DateTime>(type: "date", nullable: false),
                    ngayKetThuc = table.Column<DateTime>(type: "date", nullable: false),
                    tieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suKiens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "donXinNghiPheps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhanVienId = table.Column<int>(type: "int", nullable: false),
                    soNgayNghi = table.Column<int>(type: "int", nullable: false),
                    lyDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lyDoTuChoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donXinNghiPheps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_donXinNghiPheps_nhanViens_nhanVienId",
                        column: x => x.nhanVienId,
                        principalTable: "nhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luongTongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "date", nullable: false),
                    luongLamThem = table.Column<double>(type: "float", nullable: false),
                    luongCung = table.Column<double>(type: "float", nullable: false),
                    luongKhauTru = table.Column<double>(type: "float", nullable: false),
                    luongTong = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luongTongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_luongTongs_nhanViens_Id",
                        column: x => x.Id,
                        principalTable: "nhanViens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chamCongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    luongTongId = table.Column<int>(type: "int", nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chamCongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chamCongs_luongTongs_luongTongId",
                        column: x => x.luongTongId,
                        principalTable: "luongTongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luongKhauTrus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    luongTongId = table.Column<int>(type: "int", nullable: false),
                    soNgayMuon = table.Column<int>(type: "int", nullable: false),
                    soGioMuon = table.Column<int>(type: "int", nullable: false),
                    tienKhauTru = table.Column<double>(type: "float", nullable: false),
                    dateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luongKhauTrus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_luongKhauTrus_luongTongs_luongTongId",
                        column: x => x.luongTongId,
                        principalTable: "luongTongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "luongLamThems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    luongTongId = table.Column<int>(type: "int", nullable: false),
                    duAnId = table.Column<int>(type: "int", nullable: false),
                    soGioLam = table.Column<int>(type: "int", nullable: false),
                    tienThuong = table.Column<double>(type: "float", nullable: false),
                    dateTime = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_luongLamThems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_luongLamThems_duAns_duAnId",
                        column: x => x.duAnId,
                        principalTable: "duAns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_luongLamThems_luongTongs_luongTongId",
                        column: x => x.luongTongId,
                        principalTable: "luongTongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chamCongs_luongTongId",
                table: "chamCongs",
                column: "luongTongId");

            migrationBuilder.CreateIndex(
                name: "IX_donXinNghiPheps_nhanVienId",
                table: "donXinNghiPheps",
                column: "nhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_luongKhauTrus_luongTongId",
                table: "luongKhauTrus",
                column: "luongTongId");

            migrationBuilder.CreateIndex(
                name: "IX_luongLamThems_duAnId",
                table: "luongLamThems",
                column: "duAnId");

            migrationBuilder.CreateIndex(
                name: "IX_luongLamThems_luongTongId",
                table: "luongLamThems",
                column: "luongTongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chamCongs");

            migrationBuilder.DropTable(
                name: "donXinNghiPheps");

            migrationBuilder.DropTable(
                name: "luongKhauTrus");

            migrationBuilder.DropTable(
                name: "luongLamThems");

            migrationBuilder.DropTable(
                name: "suKiens");

            migrationBuilder.DropTable(
                name: "duAns");

            migrationBuilder.DropTable(
                name: "luongTongs");

            migrationBuilder.DropTable(
                name: "nhanViens");
        }
    }
}
