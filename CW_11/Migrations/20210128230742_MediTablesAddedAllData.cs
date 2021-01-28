using Microsoft.EntityFrameworkCore.Migrations;

namespace CW_11.Migrations
{
    public partial class MediTablesAddedAllData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Antybiotyk", "lek" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2,
                columns: new[] { "Description", "Type" },
                values: new object[] { "Wyjazdowy", "Antybiotyk" });
        }
    }
}
