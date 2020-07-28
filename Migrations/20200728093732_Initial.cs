using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace AnimalShelter.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    breed = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    intelligence_coefficient = table.Column<int>(type: "int(11)", nullable: false),
                    cleansed = table.Column<byte>(type: "tinyint(1)", nullable: false),
                    centre_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cats", x => x.id);
                    table.ForeignKey(
                        name: "fk_cats_centres",
                        column: x => x.centre_id,
                        principalTable: "centres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    breed = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cleansed = table.Column<byte>(type: "tinyint(1)", nullable: false),
                    centre_id = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogs", x => x.id);
                    table.ForeignKey(
                        name: "fk_dogs_centres",
                        column: x => x.centre_id,
                        principalTable: "centres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_cats_centres",
                table: "cats",
                column: "centre_id");

            migrationBuilder.CreateIndex(
                name: "name",
                table: "centres",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_dogs_centres",
                table: "dogs",
                column: "centre_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cats");

            migrationBuilder.DropTable(
                name: "dogs");

            migrationBuilder.DropTable(
                name: "centres");
        }
    }
}
