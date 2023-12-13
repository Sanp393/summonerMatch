using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SummonerMatch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicionTop = table.Column<bool>(type: "bit", nullable: true),
                    PosicionMid = table.Column<bool>(type: "bit", nullable: true),
                    PosicionJungla = table.Column<bool>(type: "bit", nullable: true),
                    PosicionSupport = table.Column<bool>(type: "bit", nullable: true),
                    PosicionAdc = table.Column<bool>(type: "bit", nullable: true),
                    FkRangoEquipo = table.Column<int>(type: "int", nullable: true),
                    IdPartida = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                });

            migrationBuilder.CreateTable(
                name: "ImagenPerfil",
                columns: table => new
                {
                    IdImagenPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArchivoImagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenPerfil", x => x.IdImagenPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IdCardPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tituloPartida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraExpiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    posicionTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posicionJungle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posicionMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posicionSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    posicionAdc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkIdCreador = table.Column<int>(type: "int", nullable: true),
                    FkTipoPartida = table.Column<int>(type: "int", nullable: true),
                    FKIdTorneo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdCardPartida);
                });

            migrationBuilder.CreateTable(
                name: "Posicion",
                columns: table => new
                {
                    IdPosicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePosicion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posicion", x => x.IdPosicion);
                });

            migrationBuilder.CreateTable(
                name: "Rango",
                columns: table => new
                {
                    IdRango = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRango = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rango", x => x.IdRango);
                });

            migrationBuilder.CreateTable(
                name: "RegionServidor",
                columns: table => new
                {
                    IdRegionServidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRegion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionServidor", x => x.IdRegionServidor);
                });

            migrationBuilder.CreateTable(
                name: "TipoPartida",
                columns: table => new
                {
                    IdTipoPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPartida", x => x.IdTipoPartida);
                });

            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    IdTorneo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTorneo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionTorneo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantEquipos = table.Column<int>(type: "int", nullable: true),
                    FkIdCreador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.IdTorneo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admin = table.Column<bool>(type: "bit", nullable: true),
                    nombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userNickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoElectonico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fkRegionServidor = table.Column<int>(type: "int", nullable: true),
                    fkRango = table.Column<int>(type: "int", nullable: true),
                    fkPosicion = table.Column<int>(type: "int", nullable: true),
                    fkImagenPerfil = table.Column<int>(type: "int", nullable: true),
                    fkIdEquipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Valoracion",
                columns: table => new
                {
                    IdValoracion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Media = table.Column<float>(type: "real", nullable: true),
                    NumValoraciones = table.Column<int>(type: "int", nullable: true),
                    FkUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoracion", x => x.IdValoracion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "ImagenPerfil");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Posicion");

            migrationBuilder.DropTable(
                name: "Rango");

            migrationBuilder.DropTable(
                name: "RegionServidor");

            migrationBuilder.DropTable(
                name: "TipoPartida");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Valoracion");
        }
    }
}
