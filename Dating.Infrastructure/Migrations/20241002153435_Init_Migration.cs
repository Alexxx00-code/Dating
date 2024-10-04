using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dating.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyesColors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyesColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairColors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SexOrientations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SexOrientations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZodiacSigns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZodiacSigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Firstname = table.Column<string>(type: "text", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    SexOrientationId = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    BaseImageName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<int>(type: "integer", nullable: true),
                    MinPartnerHeight = table.Column<int>(type: "integer", nullable: true),
                    MaxPartnerHeight = table.Column<int>(type: "integer", nullable: true),
                    MinPartnerWeight = table.Column<int>(type: "integer", nullable: true),
                    MaxPartnerWeight = table.Column<int>(type: "integer", nullable: true),
                    MinPartnerYear = table.Column<int>(type: "integer", nullable: true),
                    MaxPartnerYear = table.Column<int>(type: "integer", nullable: true),
                    ColorEyesId = table.Column<long>(type: "bigint", nullable: true),
                    EyesColorId = table.Column<long>(type: "bigint", nullable: true),
                    HairColorId = table.Column<long>(type: "bigint", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_EyesColors_EyesColorId",
                        column: x => x.EyesColorId,
                        principalTable: "EyesColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_HairColors_HairColorId",
                        column: x => x.HairColorId,
                        principalTable: "HairColors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_SexOrientations_SexOrientationId",
                        column: x => x.SexOrientationId,
                        principalTable: "SexOrientations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Path = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstUserId = table.Column<long>(type: "bigint", nullable: false),
                    SecondUserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OnesidedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MutualDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RefusedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationships_Users_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Relationships_Users_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => new { x.LanguageId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPartnerCity",
                columns: table => new
                {
                    PartnerCityId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPartnerCity", x => new { x.PartnerCityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPartnerCity_Cities_PartnerCityId",
                        column: x => x.PartnerCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPartnerCity_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPartnerEyesColor",
                columns: table => new
                {
                    PartnerEyesColorId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPartnerEyesColor", x => new { x.PartnerEyesColorId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPartnerEyesColor_EyesColors_PartnerEyesColorId",
                        column: x => x.PartnerEyesColorId,
                        principalTable: "EyesColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPartnerEyesColor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPartnerHairColor",
                columns: table => new
                {
                    PartnerHairColorId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPartnerHairColor", x => new { x.PartnerHairColorId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPartnerHairColor_HairColors_PartnerHairColorId",
                        column: x => x.PartnerHairColorId,
                        principalTable: "HairColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPartnerHairColor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPartnerZodiacSign",
                columns: table => new
                {
                    PartnerZodiacSignId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPartnerZodiacSign", x => new { x.PartnerZodiacSignId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserPartnerZodiacSign_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPartnerZodiacSign_ZodiacSigns_PartnerZodiacSignId",
                        column: x => x.PartnerZodiacSignId,
                        principalTable: "ZodiacSigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTag",
                columns: table => new
                {
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTag", x => new { x.TagId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserTag_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTag_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EyesColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Brown" },
                    { 2L, "Blue" },
                    { 3L, "Green" },
                    { 4L, "Grey" },
                    { 5L, "Another" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Male" },
                    { 2L, "Female" }
                });

            migrationBuilder.InsertData(
                table: "HairColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Brunette" },
                    { 2L, "BrownHaired" },
                    { 3L, "Blond" },
                    { 4L, "Redhead" },
                    { 5L, "Another" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Russian" },
                    { 2L, "English" }
                });

            migrationBuilder.InsertData(
                table: "SexOrientations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Heterosexual" },
                    { 2L, "Homosexual" },
                    { 3L, "Bisexual" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Sport" },
                    { 2L, "Movie" },
                    { 3L, "Serials" },
                    { 4L, "Politics" }
                });

            migrationBuilder.InsertData(
                table: "ZodiacSigns",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Aquarius" },
                    { 2L, "Pisces" },
                    { 3L, "Aries" },
                    { 4L, "Taurus" },
                    { 5L, "Gemini" },
                    { 6L, "Cancer" },
                    { 7L, "Leo" },
                    { 8L, "Virgo" },
                    { 9L, "Libra" },
                    { 10L, "Scorpio" },
                    { 11L, "Sagittarius" },
                    { 12L, "Capricorn" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_FirstUserId",
                table: "Relationships",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_SecondUserId",
                table: "Relationships",
                column: "SecondUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_UserId",
                table: "UserLanguage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPartnerCity_UserId",
                table: "UserPartnerCity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPartnerEyesColor_UserId",
                table: "UserPartnerEyesColor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPartnerHairColor_UserId",
                table: "UserPartnerHairColor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPartnerZodiacSign_UserId",
                table: "UserPartnerZodiacSign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EyesColorId",
                table: "Users",
                column: "EyesColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_HairColorId",
                table: "Users",
                column: "HairColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SexOrientationId",
                table: "Users",
                column: "SexOrientationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TelegramId",
                table: "Users",
                column: "TelegramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_UserId",
                table: "UserTag",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "UserPartnerCity");

            migrationBuilder.DropTable(
                name: "UserPartnerEyesColor");

            migrationBuilder.DropTable(
                name: "UserPartnerHairColor");

            migrationBuilder.DropTable(
                name: "UserPartnerZodiacSign");

            migrationBuilder.DropTable(
                name: "UserTag");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "ZodiacSigns");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EyesColors");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "HairColors");

            migrationBuilder.DropTable(
                name: "SexOrientations");
        }
    }
}
