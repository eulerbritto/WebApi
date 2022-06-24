using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations.SqlServerMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });


            migrationBuilder.CreateTable(
                  name: "Leads",
                  columns: table => new
                  {
                      Id = table.Column<int>(type: "int", nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                      Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Price = table.Column<decimal>(type: "decimal", nullable: true),
                      Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_Leads", x => x.Id);
                  });





        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
            
            migrationBuilder.DropTable(
               name: "Leads");
        }
    }
}
