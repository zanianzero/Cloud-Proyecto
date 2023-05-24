using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpresaUTN.API.Migrations
{
    /// <inheritdoc />
    public partial class v03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Restaurantes_RestauranteId",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_RestauranteId",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Platos");

            migrationBuilder.AddColumn<int>(
                name: "RestauranteCodigoRestaurante",
                table: "Platos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlatoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Platos_RestauranteCodigoRestaurante",
                table: "Platos",
                column: "RestauranteCodigoRestaurante");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes",
                column: "PlatoId",
                principalTable: "Platos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Restaurantes_RestauranteCodigoRestaurante",
                table: "Platos",
                column: "RestauranteCodigoRestaurante",
                principalTable: "Restaurantes",
                principalColumn: "CodigoRestaurante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Platos_Restaurantes_RestauranteCodigoRestaurante",
                table: "Platos");

            migrationBuilder.DropIndex(
                name: "IX_Platos_RestauranteCodigoRestaurante",
                table: "Platos");

            migrationBuilder.DropColumn(
                name: "RestauranteCodigoRestaurante",
                table: "Platos");

            migrationBuilder.AddColumn<int>(
                name: "RestauranteId",
                table: "Platos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlatoId",
                table: "Ingredientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Platos_RestauranteId",
                table: "Platos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Platos_PlatoId",
                table: "Ingredientes",
                column: "PlatoId",
                principalTable: "Platos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Platos_Restaurantes_RestauranteId",
                table: "Platos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "CodigoRestaurante",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
