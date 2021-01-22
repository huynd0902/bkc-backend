﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace bkc_backend.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BKC_Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    TotalSeat = table.Column<int>(type: "int", nullable: false),
                    AvailableSeat = table.Column<int>(type: "int", nullable: false),
                    BuId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BuName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmployeeBuId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmployeeBuName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Driver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    GuestName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Participant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_RelatedPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_RelatedPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_RoleUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeBuId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_RoleUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeLineManagerId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeLineManagerName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    EmployeeBuId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    EmployeeBuName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    EmployeeDepartment = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    CreateDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    StartDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EndDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FromLocation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ToLocation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TotalParticipant = table.Column<int>(type: "int", nullable: false),
                    ReasonBooking = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ApproverName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ApproverId = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ApprovedDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    NoteByApprover = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    TicketTripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_TicketTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_TicketTrip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BKC_Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FromLocation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ToLocation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NoteByAdmin = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TicketTripId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BKC_Trip", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BKC_Car",
                columns: new[] { "Id", "AvailableSeat", "BuId", "BuName", "CurrentLocation", "Number", "Status", "TotalSeat" },
                values: new object[,]
                {
                    { 1001, 12, "300000001732966", "H.O", null, "GOLD-XYZZ11", false, 12 },
                    { 1002, 7, "300000001732966", "H.O", null, "GOLD-9X11232", false, 7 },
                    { 1003, 14, "300000001732966", "H.O", null, "GOLD-9X27363", false, 14 }
                });

            migrationBuilder.InsertData(
                table: "BKC_Driver",
                columns: new[] { "Id", "CarId", "EmployeeBuId", "EmployeeBuName", "EmployeeEmail", "EmployeeId", "EmployeeName", "EmployeePhone" },
                values: new object[,]
                {
                    { 2001, 1001, "300000001732966", "H.O", "abc@gmail.com", "602748", "Nguyễn Văn Tài", "0934773645" },
                    { 2002, 1002, "300000001732966", "H.O", "abc@gmail.com", "102144", "Trần Văn Cường", "0334773235" },
                    { 2003, 1003, "300000001732966", "H.O", "abc@gmail.com", "104077", "Nguyễn Thị Hoa", "0884773235" }
                });

            migrationBuilder.InsertData(
                table: "BKC_Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Admin" },
                    { 3, "Member" },
                    { 1, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "BKC_RoleUser",
                columns: new[] { "Id", "EmployeeBuId", "EmployeeId", "EmployeeName", "RoleId" },
                values: new object[,]
                {
                    { 1, "300000001732966", "102144", null, 1 },
                    { 2, "300000001732966", "104077", null, 3 },
                    { 3, "300000001732979", "602748", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BKC_Car");

            migrationBuilder.DropTable(
                name: "BKC_Driver");

            migrationBuilder.DropTable(
                name: "BKC_Location");

            migrationBuilder.DropTable(
                name: "BKC_Participant");

            migrationBuilder.DropTable(
                name: "BKC_RelatedPeople");

            migrationBuilder.DropTable(
                name: "BKC_Role");

            migrationBuilder.DropTable(
                name: "BKC_RoleUser");

            migrationBuilder.DropTable(
                name: "BKC_Ticket");

            migrationBuilder.DropTable(
                name: "BKC_TicketTrip");

            migrationBuilder.DropTable(
                name: "BKC_Trip");
        }
    }
}
