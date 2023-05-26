using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hotel.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_amenities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Cus_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cus_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cus_phone = table.Column<int>(type: "int", nullable: false),
                    HotelsHotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Cus_id);
                    table.ForeignKey(
                        name: "FK_Customers_Hotels_HotelsHotel_Id",
                        column: x => x.HotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelsHotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelsHotel_Id",
                        column: x => x.HotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelsHotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Staff_Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Hotels_HotelsHotel_Id",
                        column: x => x.HotelsHotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_HotelsHotel_Id",
                table: "Customers",
                column: "HotelsHotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelsHotel_Id",
                table: "Rooms",
                column: "HotelsHotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_HotelsHotel_Id",
                table: "Staffs",
                column: "HotelsHotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
