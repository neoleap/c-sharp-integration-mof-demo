using Microsoft.EntityFrameworkCore.Migrations;

namespace CSharpDemo.Data.Migrations
{
    public partial class intialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trandata",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencycode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    trackid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    responseURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    errorURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    udf10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    langid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payorIDType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payorIDNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trandata", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trandata");
        }
    }
}
