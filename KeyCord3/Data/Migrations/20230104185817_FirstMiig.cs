using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyCord3.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMiig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Categoria",
            //    columns: table => new
            //    {
            //        idcat = table.Column<int>(name: "id_cat", type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nomecat = table.Column<string>(name: "nome_cat", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        desccat = table.Column<string>(name: "desc_cat", type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categoria", x => x.idcat);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Plataforma",
            //    columns: table => new
            //    {
            //        idplat = table.Column<int>(name: "id_plat", type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nomeplat = table.Column<string>(name: "nome_plat", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        descplat = table.Column<string>(name: "desc_plat", type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Plataforma", x => x.idplat);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Produtora",
            //    columns: table => new
            //    {
            //        idprod = table.Column<int>(name: "id_prod", type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nomeprod = table.Column<string>(name: "nome_prod", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        descprod = table.Column<string>(name: "desc_prod", type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Produtora", x => x.idprod);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Utilizador",
            //    columns: table => new
            //    {
            //        idut = table.Column<int>(name: "id_ut", type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        userut = table.Column<string>(name: "user_ut", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        fotout = table.Column<string>(name: "foto_ut", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        idAspNet = table.Column<string>(name: "id_AspNet", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Utilizador", x => x.idut);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Admini",
            //    columns: table => new
            //    {
            //        idadmin = table.Column<int>(name: "id_admin", type: "int", nullable: false),
            //        idcriador = table.Column<int>(name: "id_criador", type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Admini", x => x.idadmin);
            //        table.ForeignKey(
            //            name: "FK_Admini_Admini_id_criador",
            //            column: x => x.idcriador,
            //            principalTable: "Admini",
            //            principalColumn: "id_admin",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Admini_Utilizador_id_admin",
            //            column: x => x.idadmin,
            //            principalTable: "Utilizador",
            //            principalColumn: "id_ut",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cliente",
            //    columns: table => new
            //    {
            //        idcli = table.Column<int>(name: "id_cli", type: "int", nullable: false),
            //        nomecli = table.Column<string>(name: "nome_cli", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        moradacli = table.Column<string>(name: "morada_cli", type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
            //        estadocli = table.Column<bool>(name: "estado_cli", type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cliente", x => x.idcli);
            //        table.ForeignKey(
            //            name: "FK_Cliente_Utilizador_id_cli",
            //            column: x => x.idcli,
            //            principalTable: "Utilizador",
            //            principalColumn: "id_ut",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Funcionario",
            //    columns: table => new
            //    {
            //        idfunc = table.Column<int>(name: "id_func", type: "int", nullable: false),
            //        nomeFunc = table.Column<string>(name: "nome_Func", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        phoneFunc = table.Column<string>(name: "phone_Func", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        idadd = table.Column<int>(name: "id_add", type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Funcionario", x => x.idfunc);
            //        table.ForeignKey(
            //            name: "FK_Funcionario_Admini_id_add",
            //            column: x => x.idadd,
            //            principalTable: "Admini",
            //            principalColumn: "id_admin",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Funcionario_Utilizador_id_func",
            //            column: x => x.idfunc,
            //            principalTable: "Utilizador",
            //            principalColumn: "id_ut",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoriumCliente",
            //    columns: table => new
            //    {
            //        IdCat = table.Column<int>(type: "int", nullable: false),
            //        IdCli = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoriumCliente", x => new { x.IdCat, x.IdCli });
            //        table.ForeignKey(
            //            name: "FK_CategoriumCliente_Categoria_IdCat",
            //            column: x => x.IdCat,
            //            principalTable: "Categoria",
            //            principalColumn: "id_cat",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoriumCliente_Cliente_IdCli",
            //            column: x => x.IdCli,
            //            principalTable: "Cliente",
            //            principalColumn: "id_cli",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Jogo",
            //    columns: table => new
            //    {
            //        idjogo = table.Column<int>(name: "id_jogo", type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        nomejogo = table.Column<string>(name: "nome_jogo", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        precojogo = table.Column<int>(name: "preco_jogo", type: "int", nullable: false),
            //        desconto = table.Column<int>(type: "int", unicode: false, nullable: false),
            //        descjogo = table.Column<string>(name: "desc_jogo", type: "nvarchar(max)", nullable: false),
            //        anopublic = table.Column<int>(name: "ano_public", type: "int", nullable: false),
            //        fotojogo = table.Column<string>(name: "foto_jogo", type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
            //        idcat = table.Column<int>(name: "id_cat", type: "int", nullable: false),
            //        idprod = table.Column<int>(name: "id_prod", type: "int", nullable: false),
            //        idplat = table.Column<int>(name: "id_plat", type: "int", nullable: false),
            //        idfunc = table.Column<int>(name: "id_func", type: "int", nullable: false),
            //        dataedicao = table.Column<DateTime>(name: "data_edicao", type: "datetime", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Jogo", x => x.idjogo);
            //        table.ForeignKey(
            //            name: "FK_Jogo_Categoria_id_cat",
            //            column: x => x.idcat,
            //            principalTable: "Categoria",
            //            principalColumn: "id_cat",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Jogo_Funcionario_id_func",
            //            column: x => x.idfunc,
            //            principalTable: "Funcionario",
            //            principalColumn: "id_func",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Jogo_Plataforma_id_plat",
            //            column: x => x.idplat,
            //            principalTable: "Plataforma",
            //            principalColumn: "id_plat",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Jogo_Produtora_id_prod",
            //            column: x => x.idprod,
            //            principalTable: "Produtora",
            //            principalColumn: "id_prod",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Compra",
            //    columns: table => new
            //    {
            //        idjogo = table.Column<int>(name: "id_jogo", type: "int", nullable: false),
            //        idcli = table.Column<int>(name: "id_cli", type: "int", nullable: false),
            //        datacompra = table.Column<DateTime>(name: "data_compra", type: "datetime", nullable: false),
            //        precocompra = table.Column<int>(name: "preco_compra", type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Compra", x => new { x.idjogo, x.idcli });
            //        table.ForeignKey(
            //            name: "FK_Compra_Cliente_id_cli",
            //            column: x => x.idcli,
            //            principalTable: "Cliente",
            //            principalColumn: "id_cli",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Compra_Jogo_id_jogo",
            //            column: x => x.idjogo,
            //            principalTable: "Jogo",
            //            principalColumn: "id_jogo",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Admini_id_criador",
            //    table: "Admini",
            //    column: "id_criador");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoriumCliente_IdCli",
            //    table: "CategoriumCliente",
            //    column: "IdCli");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Compra_id_cli",
            //    table: "Compra",
            //    column: "id_cli");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Funciona__6BE8F805A6AAA0A2",
            //    table: "Funcionario",
            //    column: "id_add",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Funciona__F7C545202352A5F1",
            //    table: "Funcionario",
            //    column: "phone_Func",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Jogo_id_cat",
            //    table: "Jogo",
            //    column: "id_cat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Jogo_id_plat",
            //    table: "Jogo",
            //    column: "id_plat");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Jogo_id_prod",
            //    table: "Jogo",
            //    column: "id_prod");

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Jogo__61295648A0143B6C",
            //    table: "Jogo",
            //    column: "id_func",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "UQ__Utilizad__B9B11AFD7F1EF4A9",
            //    table: "Utilizador",
            //    column: "user_ut",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CategoriumCliente");

            //migrationBuilder.DropTable(
            //    name: "Compra");

            //migrationBuilder.DropTable(
            //    name: "Cliente");

            //migrationBuilder.DropTable(
            //    name: "Jogo");

            //migrationBuilder.DropTable(
            //    name: "Categoria");

            //migrationBuilder.DropTable(
            //    name: "Funcionario");

            //migrationBuilder.DropTable(
            //    name: "Plataforma");

            //migrationBuilder.DropTable(
            //    name: "Produtora");

            //migrationBuilder.DropTable(
            //    name: "Admini");

            //migrationBuilder.DropTable(
            //    name: "Utilizador");
        }
    }
}
