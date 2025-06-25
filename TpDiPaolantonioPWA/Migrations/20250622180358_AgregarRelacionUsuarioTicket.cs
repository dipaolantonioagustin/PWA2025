using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpDiPaolantonioPWA.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionUsuarioTicket : Migration
    {
        /// <inheritdoc />
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //migrationBuilder.CreateTable(
        //    name: "nacionalidad",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        nacionalidad = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //    });

        //migrationBuilder.CreateTable(
        //    name: "pais",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_pais", x => x.id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "sala",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        nombre_sala = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_sala", x => x.id);
        //    });

        //migrationBuilder.CreateTable(
        //    name: "tipo_evento",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        tipo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_tipo_evento", x => x.id);
        //    });

        ////migrationBuilder.CreateTable(
        ////    name: "Usuarios",
        ////    columns: table => new
        ////    {
        ////        Id = table.Column<int>(type: "int", nullable: false)
        ////            .Annotation("SqlServer:Identity", "1, 1"),
        ////        nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
        ////        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
        ////        Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
        ////    },
        ////    constraints: table =>
        ////    {
        ////        table.PrimaryKey("PK_Usuarios", x => x.Id);
        ////    });

        //migrationBuilder.CreateTable(
        //    name: "autor",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false),
        //        nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //        apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //        nacionalidad_id = table.Column<int>(type: "int", nullable: true)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_autor", x => x.id);
        //        table.ForeignKey(
        //            name: "FK_autor_pais",
        //            column: x => x.nacionalidad_id,
        //            principalTable: "pais",
        //            principalColumn: "id");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "evento",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        nombre_evento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //        descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //        fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
        //        fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false),
        //        autor_id = table.Column<int>(type: "int", nullable: false),
        //        sala_id = table.Column<int>(type: "int", nullable: false),
        //        portada = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //        tipo_id = table.Column<int>(type: "int", nullable: false),
        //        valor = table.Column<double>(type: "float", nullable: false),
        //        descripcion_detalle = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_evento", x => x.id);
        //        table.ForeignKey(
        //            name: "FK_evento_autor",
        //            column: x => x.autor_id,
        //            principalTable: "autor",
        //            principalColumn: "id");
        //        table.ForeignKey(
        //            name: "FK_evento_sala",
        //            column: x => x.sala_id,
        //            principalTable: "sala",
        //            principalColumn: "id");
        //        table.ForeignKey(
        //            name: "FK_evento_tipo_evento",
        //            column: x => x.tipo_id,
        //            principalTable: "tipo_evento",
        //            principalColumn: "id");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "obra",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        nombre_obra = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
        //        fecha_obra = table.Column<DateOnly>(type: "date", nullable: false),
        //        imagen_obra = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: false),
        //        id_autor = table.Column<int>(type: "int", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_obra", x => x.id);
        //        table.ForeignKey(
        //            name: "FK_obra_autor",
        //            column: x => x.id_autor,
        //            principalTable: "autor",
        //            principalColumn: "id");
        //    });

        //migrationBuilder.CreateTable(
        //    name: "ticket",
        //    columns: table => new
        //    {
        //        id = table.Column<int>(type: "int", nullable: false)
        //            .Annotation("SqlServer:Identity", "1, 1"),
        //        id_evento = table.Column<int>(type: "int", nullable: false),
        //        cant_entradas = table.Column<int>(type: "int", nullable: false),
        //        valor_total = table.Column<double>(type: "float", nullable: false),
        //        id_usuario = table.Column<int>(type: "int", nullable: false)
        //    },
        //    constraints: table =>
        //    {
        //        table.PrimaryKey("PK_ticket", x => x.id);
        //        table.ForeignKey(
        //            name: "FK_ticket_evento1",
        //            column: x => x.id_evento,
        //            principalTable: "evento",
        //            principalColumn: "id");
        //        table.ForeignKey(
        //            name: "FK_ticket_usuario",
        //            column: x => x.id_usuario,
        //            principalTable: "Usuarios",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Restrict);
        //    });

        //migrationBuilder.CreateIndex(
        //    name: "IX_autor_nacionalidad_id",
        //    table: "autor",
        //    column: "nacionalidad_id");

        //migrationBuilder.CreateIndex(
        //    name: "IX_evento_autor_id",
        //    table: "evento",
        //    column: "autor_id");

        //migrationBuilder.CreateIndex(
        //    name: "IX_evento_sala_id",
        //    table: "evento",
        //    column: "sala_id");

        //migrationBuilder.CreateIndex(
        //    name: "IX_evento_tipo_id",
        //    table: "evento",
        //    column: "tipo_id");

        //migrationBuilder.CreateIndex(
        //    name: "IX_obra_id_autor",
        //    table: "obra",
        //    column: "id_autor");

        //migrationBuilder.CreateIndex(
        //    name: "IX_ticket_id_evento",
        //    table: "ticket",
        //    column: "id_evento");

        //        migrationBuilder.CreateIndex(
        //            name: "IX_ticket_id_usuario",
        //            table: "ticket",
        //            column: "id_usuario");
        //    }

        //    /// <inheritdoc />
        //    protected override void Down(MigrationBuilder migrationBuilder)
        //    {
        //        migrationBuilder.DropTable(
        //            name: "nacionalidad");

        //        migrationBuilder.DropTable(
        //            name: "obra");

        //        migrationBuilder.DropTable(
        //            name: "ticket");

        //        migrationBuilder.DropTable(
        //            name: "evento");

        //        migrationBuilder.DropTable(
        //            name: "Usuarios");

        //        migrationBuilder.DropTable(
        //            name: "autor");

        //        migrationBuilder.DropTable(
        //            name: "sala");

        //        migrationBuilder.DropTable(
        //            name: "tipo_evento");

        //        migrationBuilder.DropTable(
        //            name: "pais");
        //    }


     
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                // Agregar columna UsuarioId a la tabla Ticket
                migrationBuilder.AddColumn<int>(
                    name: "UsuarioId",
                    table: "Ticket",
                    type: "int",
                    nullable: false,
                    defaultValue: 0);

                // Crear índice en UsuarioId
                migrationBuilder.CreateIndex(
                    name: "IX_Ticket_UsuarioId",
                    table: "Ticket",
                    column: "UsuarioId");

                // Crear la relación FK entre Ticket y Usuario
                migrationBuilder.AddForeignKey(
                    name: "FK_Ticket_Usuario_UsuarioId",
                    table: "Ticket",
                    column: "UsuarioId",
                    principalTable: "Usuario",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                // Eliminar la FK
                migrationBuilder.DropForeignKey(
                    name: "FK_Ticket_Usuario_UsuarioId",
                    table: "Ticket");

                // Eliminar índice
                migrationBuilder.DropIndex(
                    name: "IX_Ticket_UsuarioId",
                    table: "Ticket");

                // Eliminar columna UsuarioId
                migrationBuilder.DropColumn(
                    name: "UsuarioId",
                    table: "Ticket");
            }
        }







    
}
