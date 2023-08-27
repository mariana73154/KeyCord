using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyCord3.Data.Migrations
{
    /// <inheritdoc />
    public partial class add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "UQ__Funciona__6BE8F805204DC7C6",
                table: "Funcionario",
                newName: "IX_Funcionario_id_add");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Funcionario_id_add",
                table: "Funcionario",
                newName: "UQ__Funciona__6BE8F805204DC7C6");
        }
    }
}
