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
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JugadorTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorJungle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorAdc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkPartida = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                });

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    IdPartida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JugadorTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorJungle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorSupport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JugadorAdc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkUsuarioCreador = table.Column<int>(type: "int", nullable: true),
                    FkTipoPartida = table.Column<int>(type: "int", nullable: true),
                    FkTorneo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
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
                name: "Region",
                columns: table => new
                {
                    IdRegion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRegion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.IdRegion);
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
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantidadEquipos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.IdTorneo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsAdministrador = table.Column<bool>(type: "bit", nullable: true),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioLoL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FkPosicion = table.Column<int>(type: "int", nullable: true),
                    FkRango = table.Column<int>(type: "int", nullable: true),
                    FkRegion = table.Column<int>(type: "int", nullable: true),
                    FkValoracion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Valoracion",
                columns: table => new
                {
                    IdValoracion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntuacionMedia = table.Column<float>(type: "real", nullable: true),
                    CantidadValoraciones = table.Column<int>(type: "int", nullable: true)
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
                name: "Partida");

            migrationBuilder.DropTable(
                name: "Posicion");

            migrationBuilder.DropTable(
                name: "Rango");

            migrationBuilder.DropTable(
                name: "Region");

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
