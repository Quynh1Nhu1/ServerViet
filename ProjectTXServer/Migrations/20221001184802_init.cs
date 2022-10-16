using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTXServer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    LocateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.LocateId);
                });

            migrationBuilder.CreateTable(
                name: "GenderType",
                columns: table => new
                {
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderType", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDoB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHashs = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCover = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductIntro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRate = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<float>(type: "real", nullable: false),
                    AreaLocationLocateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Area_AreaLocationLocateId",
                        column: x => x.AreaLocationLocateId,
                        principalTable: "Area",
                        principalColumn: "LocateId");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInGender",
                columns: table => new
                {
                    GenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInGender", x => new { x.GenderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInGender_GenderType_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GenderType",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInGender_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInLocation",
                columns: table => new
                {
                    LocateId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInLocation", x => new { x.ProductId, x.LocateId });
                    table.ForeignKey(
                        name: "FK_ProductInLocation_Area_LocateId",
                        column: x => x.LocateId,
                        principalTable: "Area",
                        principalColumn: "LocateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInLocation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInProductType",
                columns: table => new
                {
                    ProductTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInProductType", x => new { x.ProductTypeId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductInProductType_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInProductType_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "LocateId", "LocateName" },
                values: new object[,]
                {
                    { 1, "TP.HCM" },
                    { 2, "Hà Nội" },
                    { 3, "Đà Nẵng" },
                    { 4, "Trà Vinh" },
                    { 5, "Nha Trang" },
                    { 6, "Vĩnh Phúc" },
                    { 7, "An Giang" },
                    { 8, "Cần Thơ" }
                });

            migrationBuilder.InsertData(
                table: "GenderType",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "Man" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "Women" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "AreaLocationLocateId", "ProductCover", "ProductDescription", "ProductIntro", "ProductName", "ProductPrice", "ProductRate" },
                values: new object[,]
                {
                    { "02a3ed08-9f18-4fd9-9789-fa95114865de", null, "css/images/product_pantmen1.PNG", "This is pantman1", "link clip", "pantman1", 870000f, 5 },
                    { "0bc1e240-bb69-457b-8af3-c7ef825446da", null, "css/images/product_pantwomen5.PNG", "This is pantwoman5", "link clip", "pantwoman5", 477000f, 5 },
                    { "108a0d71-bd7c-4247-8052-79cf34da30fa", null, "css/images/product_men6.PNG", "Make in china", "link clip", "T shirt for men", 140000f, 5 },
                    { "10c6f609-a376-4654-9e54-772a011774bc", null, "css/images/product_women1.PNG", "Headsfer T-shirt for women1 have a passion with SWAG", "link clip", "women1", 990000f, 5 },
                    { "174b1d16-35bc-4d07-9c76-8772f23309ef", null, "css/images/product_women5.PNG", "This is women5", "link clip", "women5", 950000f, 5 },
                    { "1785cfb4-8c6c-4edf-8fc6-ae004e9145ad", null, "css/images/product_men8.PNG", "T-shirt smile, that is the best for you", "link clip", "T-shirt smile", 6400000f, 5 },
                    { "1c71cb12-68b8-4c8f-bd07-1ffdeca30f61", null, "css/images/product_pantmen4.PNG", "This is pantman4", "link clip", "pantman4", 8000000f, 5 },
                    { "2551fe50-6fb7-4f30-ac87-7f80186b475e", null, "css/images/product_pantwomen4.PNG", "This is pantwoman4", "link clip", "pantwoman4", 866000f, 5 },
                    { "38928510-eb25-4373-8adf-c8f20c7ee534", null, "css/images/product_women9.PNG", "This is women9", "link clip", "women9", 45000f, 5 },
                    { "5404f3dd-9d6f-41eb-a74a-c84d87a56608", null, "css/images/product_men2.PNG", "Men T-shirt The Astronut", "link clip", "BST Summer T-shirt", 120000f, 1 },
                    { "5c92efa7-9e2e-4185-8da4-5ed79bdfedcf", null, "css/images/product_men5.PNG", "This is Unifas", "link clip", "Unifas", 5400000f, 5 },
                    { "66669eb6-6366-4d97-8271-6542bf88d425", null, "css/images/product_men1.PNG", "This is BST Product", "link clip", "The Astronut", 80000f, 1 },
                    { "93492ed7-443d-4efa-937e-dcb189dbd657", null, "css/images/product_pantmen3.PNG", "This is pantman3", "link clip", "pantman3", 1900000f, 5 },
                    { "98dc195f-ba34-4668-ba27-ce9e0939a0cb", null, "css/images/product_pantwomen3.PNG", "This is pantwoman3", "link clip", "pantwoman3", 234000f, 5 },
                    { "9d2891fd-98e8-44ea-af70-4b2dcc11c9f7", null, "css/images/product_pantwomen2.PNG", "This is pantwoman2", "link clip", "pantwoman2", 4890000f, 5 },
                    { "a232bb1a-f1f7-4929-9307-a1a8e3b0a90e", null, "css/images/product_women2.PNG", "This is women2", "link clip", "women2", 670000f, 5 },
                    { "a5fb324a-c75a-4b17-964a-30e9187c1270", null, "css/images/product_men4.PNG", "The Anti formalism T-shirt for men", "link clip", "Anti formalism", 4400000f, 3 },
                    { "b71b9324-77be-4d5b-8725-c3c1bd82fca5", null, "css/images/product_women4.PNG", "This is women4", "link clip", "women4", 350000f, 5 },
                    { "b7ce2d18-0dfa-4281-847e-3c03806eedce", null, "css/images/product_women8.PNG", "This is women8", "link clip", "women8", 150000f, 5 },
                    { "cdf3b598-3c66-4de5-a774-5a055cb3aaa5", null, "css/images/product_women6.PNG", "This is women6", "link clip", "women6", 4250000f, 5 },
                    { "ce38bd82-7d36-4046-b173-d98f0995490a", null, "css/images/product_men10.PNG", "That is Astronaut", "link clip", "Astronaut", 96000f, 5 },
                    { "cf6ef659-8813-4374-bc65-c161aefe8e60", null, "css/images/product_women7.PNG", "This is women7", "link clip", "women7", 6750000f, 5 },
                    { "d3db9d49-ea86-4b1c-a365-979fdd04f1bc", null, "css/images/product_men3.PNG", "The King man T shirt make by coton", "link clip", "King man T shirt", 1400000f, 3 },
                    { "d69e5e7a-4725-46a8-96a4-0fd61559ba6a", null, "css/images/product_men9.PNG", "True choise for guy", "link clip", "Magic T-shirt", 740000f, 5 },
                    { "de04143d-5165-4f28-ba59-d9a6fbe4281b", null, "css/images/product_pantmen5.PNG", "This is pantman5", "link clip", "pantman5", 980000f, 5 },
                    { "e2f1cf08-e94e-49c8-a095-1cac23e23aa3", null, "css/images/product_women3.PNG", "This is women3", "link clip", "women3", 450000f, 5 },
                    { "f537de7f-c04a-4a7f-bf8a-43c530d40b99", null, "css/images/product_men7.PNG", "This is YourName Product", "link clip", "YourName", 1600000f, 5 },
                    { "f798f4eb-06ba-4150-8a6c-78c93c0ab85a", null, "css/images/product_pantwomen1.PNG", "This is pantwoman1", "link clip", "pantwoman1", 96000f, 5 },
                    { "f799531e-8ec5-491b-be3a-01590ffc8bcb", null, "css/images/product_pantmen2.PNG", "This is pantman2", "link clip", "pantman2", 1400000f, 5 },
                    { "fb0f49e1-e65f-448e-842a-561d2c18a7a1", null, "css/images/product_women10.PNG", "This is women10", "link clip", "women10", 99000f, 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "ProductTypeId", "ProductTypeName" },
                values: new object[,]
                {
                    { "44841efa-a3ae-4dc9-9699-8ccd89a79f7d", "Shirt" },
                    { "de113193-41e2-48a9-9862-2ba31bcf1816", "Pants" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "360E601E-92F2-4F08-832B-604A21293258", "db8872a7-46f9-4f0b-9819-e297d69854bc", "Admin", "AppRole", "Admin", "admin" },
                    { "f49e4348-718f-43e3-b1f6-6dc89c5Bb4fd", "2f94b13b-8304-4036-a240-8a11185dcc55", "Staff", "AppRole", "Staff", "staff" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordHashs", "PasswordSalt", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TokenCreated", "TokenExpires", "TwoFactorEnabled", "UserDoB", "UserFirstName", "UserLastName", "UserName", "UserPhoneNumber" },
                values: new object[,]
                {
                    { "DE544998-A3CC-4E12-ABB4-0642E57BD222", 0, "a98cc324-8cfa-4b9e-ba86-b0f9fe9fcfd5", "AppUser", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, new byte[] { 97, 44, 41, 103, 196, 188, 200, 0, 9, 59, 166, 54, 144, 5, 212, 53, 118, 185, 244, 59, 152, 119, 175, 129, 24, 191, 90, 235, 205, 80, 133, 95, 164, 203, 51, 224, 36, 21, 40, 13, 92, 237, 15, 193, 0, 5, 191, 108, 219, 225, 31, 244, 173, 229, 238, 55, 16, 206, 224, 141, 95, 100, 190, 157 }, new byte[] { 154, 65, 102, 153, 217, 8, 65, 219, 183, 144, 88, 172, 134, 251, 42, 52, 180, 43, 174, 39, 198, 250, 202, 141, 1, 81, 84, 27, 155, 44, 130, 45, 246, 126, 91, 189, 194, 156, 124, 33, 101, 189, 57, 10, 5, 83, 160, 227, 240, 10, 11, 37, 114, 40, 221, 243, 70, 144, 234, 235, 185, 117, 114, 93, 8, 89, 42, 71, 14, 19, 103, 141, 67, 1, 157, 17, 37, 199, 162, 149, 103, 235, 140, 163, 62, 252, 127, 253, 155, 183, 81, 239, 122, 162, 182, 88, 84, 45, 7, 107, 245, 28, 252, 228, 56, 52, 36, 130, 46, 194, 69, 181, 204, 137, 19, 168, 206, 129, 156, 116, 4, 33, 49, 206, 185, 91, 155, 190 }, null, false, "", "7f6083f9-c0f0-49af-911e-717c1e04d14a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin first name", "admin last name", "Admin", "08658568790" },
                    { "f49e4348-718f-43e3-b1f6-6dc89c5Bb5ff", 0, "82ddafc9-ddbe-41b3-a797-34b51a825e10", "AppUser", "staff@gmail.com", true, false, null, "STAFF@GMAIL.COM", "STAFF@GMAIL.COM", null, new byte[] { 97, 44, 41, 103, 196, 188, 200, 0, 9, 59, 166, 54, 144, 5, 212, 53, 118, 185, 244, 59, 152, 119, 175, 129, 24, 191, 90, 235, 205, 80, 133, 95, 164, 203, 51, 224, 36, 21, 40, 13, 92, 237, 15, 193, 0, 5, 191, 108, 219, 225, 31, 244, 173, 229, 238, 55, 16, 206, 224, 141, 95, 100, 190, 157 }, new byte[] { 154, 65, 102, 153, 217, 8, 65, 219, 183, 144, 88, 172, 134, 251, 42, 52, 180, 43, 174, 39, 198, 250, 202, 141, 1, 81, 84, 27, 155, 44, 130, 45, 246, 126, 91, 189, 194, 156, 124, 33, 101, 189, 57, 10, 5, 83, 160, 227, 240, 10, 11, 37, 114, 40, 221, 243, 70, 144, 234, 235, 185, 117, 114, 93, 8, 89, 42, 71, 14, 19, 103, 141, 67, 1, 157, 17, 37, 199, 162, 149, 103, 235, 140, 163, 62, 252, 127, 253, 155, 183, 81, 239, 122, 162, 182, 88, 84, 45, 7, 107, 245, 28, 252, 228, 56, 52, 36, 130, 46, 194, 69, 181, 204, 137, 19, 168, 206, 129, 156, 116, 4, 33, 49, 206, 185, 91, 155, 190 }, null, false, "", "601fa554-e87c-47c3-a910-2af406d499d0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff first name", "staff last name", "Staff", "08658568790" }
                });

            migrationBuilder.InsertData(
                table: "ProductInGender",
                columns: new[] { "GenderId", "ProductId" },
                values: new object[,]
                {
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "02a3ed08-9f18-4fd9-9789-fa95114865de" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "108a0d71-bd7c-4247-8052-79cf34da30fa" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "1785cfb4-8c6c-4edf-8fc6-ae004e9145ad" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "1c71cb12-68b8-4c8f-bd07-1ffdeca30f61" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "5404f3dd-9d6f-41eb-a74a-c84d87a56608" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "5c92efa7-9e2e-4185-8da4-5ed79bdfedcf" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "66669eb6-6366-4d97-8271-6542bf88d425" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "93492ed7-443d-4efa-937e-dcb189dbd657" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "a5fb324a-c75a-4b17-964a-30e9187c1270" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "ce38bd82-7d36-4046-b173-d98f0995490a" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "d3db9d49-ea86-4b1c-a365-979fdd04f1bc" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "d69e5e7a-4725-46a8-96a4-0fd61559ba6a" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "de04143d-5165-4f28-ba59-d9a6fbe4281b" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "f537de7f-c04a-4a7f-bf8a-43c530d40b99" },
                    { "98121c51-bfde-49a7-b501-0c2a1e2924af", "f799531e-8ec5-491b-be3a-01590ffc8bcb" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "0bc1e240-bb69-457b-8af3-c7ef825446da" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "10c6f609-a376-4654-9e54-772a011774bc" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "174b1d16-35bc-4d07-9c76-8772f23309ef" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "2551fe50-6fb7-4f30-ac87-7f80186b475e" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "38928510-eb25-4373-8adf-c8f20c7ee534" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "98dc195f-ba34-4668-ba27-ce9e0939a0cb" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "9d2891fd-98e8-44ea-af70-4b2dcc11c9f7" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "a232bb1a-f1f7-4929-9307-a1a8e3b0a90e" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "b71b9324-77be-4d5b-8725-c3c1bd82fca5" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "b7ce2d18-0dfa-4281-847e-3c03806eedce" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "cdf3b598-3c66-4de5-a774-5a055cb3aaa5" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "cf6ef659-8813-4374-bc65-c161aefe8e60" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "e2f1cf08-e94e-49c8-a095-1cac23e23aa3" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "f798f4eb-06ba-4150-8a6c-78c93c0ab85a" },
                    { "ea066ee9-33cd-4007-9e9b-a49ee06f0048", "fb0f49e1-e65f-448e-842a-561d2c18a7a1" }
                });

            migrationBuilder.InsertData(
                table: "ProductInLocation",
                columns: new[] { "LocateId", "ProductId" },
                values: new object[,]
                {
                    { 5, "02a3ed08-9f18-4fd9-9789-fa95114865de" },
                    { 6, "0bc1e240-bb69-457b-8af3-c7ef825446da" },
                    { 6, "108a0d71-bd7c-4247-8052-79cf34da30fa" },
                    { 3, "10c6f609-a376-4654-9e54-772a011774bc" },
                    { 7, "174b1d16-35bc-4d07-9c76-8772f23309ef" },
                    { 8, "1785cfb4-8c6c-4edf-8fc6-ae004e9145ad" },
                    { 8, "1c71cb12-68b8-4c8f-bd07-1ffdeca30f61" },
                    { 5, "2551fe50-6fb7-4f30-ac87-7f80186b475e" },
                    { 3, "38928510-eb25-4373-8adf-c8f20c7ee534" },
                    { 2, "5404f3dd-9d6f-41eb-a74a-c84d87a56608" },
                    { 5, "5c92efa7-9e2e-4185-8da4-5ed79bdfedcf" },
                    { 1, "66669eb6-6366-4d97-8271-6542bf88d425" }
                });

            migrationBuilder.InsertData(
                table: "ProductInLocation",
                columns: new[] { "LocateId", "ProductId" },
                values: new object[,]
                {
                    { 7, "93492ed7-443d-4efa-937e-dcb189dbd657" },
                    { 4, "98dc195f-ba34-4668-ba27-ce9e0939a0cb" },
                    { 3, "9d2891fd-98e8-44ea-af70-4b2dcc11c9f7" },
                    { 4, "a232bb1a-f1f7-4929-9307-a1a8e3b0a90e" },
                    { 4, "a5fb324a-c75a-4b17-964a-30e9187c1270" },
                    { 6, "b71b9324-77be-4d5b-8725-c3c1bd82fca5" },
                    { 2, "b7ce2d18-0dfa-4281-847e-3c03806eedce" },
                    { 8, "cdf3b598-3c66-4de5-a774-5a055cb3aaa5" },
                    { 2, "ce38bd82-7d36-4046-b173-d98f0995490a" },
                    { 1, "cf6ef659-8813-4374-bc65-c161aefe8e60" },
                    { 3, "d3db9d49-ea86-4b1c-a365-979fdd04f1bc" },
                    { 1, "d69e5e7a-4725-46a8-96a4-0fd61559ba6a" },
                    { 1, "de04143d-5165-4f28-ba59-d9a6fbe4281b" },
                    { 5, "e2f1cf08-e94e-49c8-a095-1cac23e23aa3" },
                    { 7, "f537de7f-c04a-4a7f-bf8a-43c530d40b99" },
                    { 2, "f798f4eb-06ba-4150-8a6c-78c93c0ab85a" },
                    { 6, "f799531e-8ec5-491b-be3a-01590ffc8bcb" },
                    { 4, "fb0f49e1-e65f-448e-842a-561d2c18a7a1" }
                });

            migrationBuilder.InsertData(
                table: "ProductInProductType",
                columns: new[] { "ProductId", "ProductTypeId" },
                values: new object[,]
                {
                    { "108a0d71-bd7c-4247-8052-79cf34da30fa", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "10c6f609-a376-4654-9e54-772a011774bc", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "174b1d16-35bc-4d07-9c76-8772f23309ef", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "1785cfb4-8c6c-4edf-8fc6-ae004e9145ad", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "38928510-eb25-4373-8adf-c8f20c7ee534", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "5404f3dd-9d6f-41eb-a74a-c84d87a56608", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "5c92efa7-9e2e-4185-8da4-5ed79bdfedcf", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "66669eb6-6366-4d97-8271-6542bf88d425", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "a232bb1a-f1f7-4929-9307-a1a8e3b0a90e", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "a5fb324a-c75a-4b17-964a-30e9187c1270", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "b71b9324-77be-4d5b-8725-c3c1bd82fca5", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "b7ce2d18-0dfa-4281-847e-3c03806eedce", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "cdf3b598-3c66-4de5-a774-5a055cb3aaa5", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "ce38bd82-7d36-4046-b173-d98f0995490a", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "cf6ef659-8813-4374-bc65-c161aefe8e60", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "d3db9d49-ea86-4b1c-a365-979fdd04f1bc", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "d69e5e7a-4725-46a8-96a4-0fd61559ba6a", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "e2f1cf08-e94e-49c8-a095-1cac23e23aa3", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "f537de7f-c04a-4a7f-bf8a-43c530d40b99", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "fb0f49e1-e65f-448e-842a-561d2c18a7a1", "44841efa-a3ae-4dc9-9699-8ccd89a79f7d" },
                    { "02a3ed08-9f18-4fd9-9789-fa95114865de", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "0bc1e240-bb69-457b-8af3-c7ef825446da", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "1c71cb12-68b8-4c8f-bd07-1ffdeca30f61", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "2551fe50-6fb7-4f30-ac87-7f80186b475e", "de113193-41e2-48a9-9862-2ba31bcf1816" }
                });

            migrationBuilder.InsertData(
                table: "ProductInProductType",
                columns: new[] { "ProductId", "ProductTypeId" },
                values: new object[,]
                {
                    { "93492ed7-443d-4efa-937e-dcb189dbd657", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "98dc195f-ba34-4668-ba27-ce9e0939a0cb", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "9d2891fd-98e8-44ea-af70-4b2dcc11c9f7", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "de04143d-5165-4f28-ba59-d9a6fbe4281b", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "f798f4eb-06ba-4150-8a6c-78c93c0ab85a", "de113193-41e2-48a9-9862-2ba31bcf1816" },
                    { "f799531e-8ec5-491b-be3a-01590ffc8bcb", "de113193-41e2-48a9-9862-2ba31bcf1816" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "360E601E-92F2-4F08-832B-604A21293258", "DE544998-A3CC-4E12-ABB4-0642E57BD222" },
                    { "f49e4348-718f-43e3-b1f6-6dc89c5Bb4fd", "f49e4348-718f-43e3-b1f6-6dc89c5Bb5ff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_AreaLocationLocateId",
                table: "Product",
                column: "AreaLocationLocateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInGender_ProductId",
                table: "ProductInGender",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInLocation_LocateId",
                table: "ProductInLocation",
                column: "LocateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInProductType_ProductId",
                table: "ProductInProductType",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInGender");

            migrationBuilder.DropTable(
                name: "ProductInLocation");

            migrationBuilder.DropTable(
                name: "ProductInProductType");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "GenderType");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
