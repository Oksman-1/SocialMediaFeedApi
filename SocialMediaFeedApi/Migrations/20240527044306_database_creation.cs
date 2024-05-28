using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SocialMediaFeedApi.Migrations
{
    /// <inheritdoc />
    public partial class database_creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Following",
                columns: table => new
                {
                    FollowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersFollowedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Following", x => x.FollowId);
                    table.ForeignKey(
                        name: "FK_Following_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "PostId");
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Username", "Website" },
                values: new object[,]
                {
                    { new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220"), "Oksman123@gmail.com", "Oksman_Ibiza", "https://www.oksman123.com/" },
                    { new Guid("6a94ce84-5fc7-4b1d-9887-48f84986d405"), "Manny_Bobo@gmail.com", "Manny_Sharpest_Guy", "https://www.Mani_Sholey.com/" },
                    { new Guid("ea8b26f5-f721-4809-8053-93a0d67dbf10"), "ChuksOkon@gmail.com", "Chukszee_518", "https://www.chukzee.com/" }
                });

            migrationBuilder.InsertData(
                table: "Following",
                columns: new[] { "FollowId", "UserId", "UsersFollowedId" },
                values: new object[,]
                {
                    { new Guid("b9b7d106-b1d6-4418-bc4e-ad07818c6067"), new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220"), new Guid("ea8b26f5-f721-4809-8053-93a0d67dbf10") },
                    { new Guid("ef0cbbae-e0b9-480c-9aeb-b99565e79c1a"), new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220"), new Guid("6a94ce84-5fc7-4b1d-9887-48f84986d405") }
                });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "PostId", "Content", "CreatedAt", "IsLiked", "UserId" },
                values: new object[,]
                {
                    { new Guid("4c84a49a-e2cf-4548-af83-206b6e51a645"), "That’s why we put together this list of 66!....they will surely graduate soon.", new DateTimeOffset(new DateTime(2024, 5, 27, 5, 43, 6, 511, DateTimeKind.Unspecified).AddTicks(8371), new TimeSpan(0, 1, 0, 0, 0)), false, new Guid("6a94ce84-5fc7-4b1d-9887-48f84986d405") },
                    { new Guid("6f7b9c0e-d769-4d6b-b170-cd80cbaa0162"), "Please bro!, let's keep finding the answers to these questions even if they are hard....", new DateTimeOffset(new DateTime(2024, 5, 27, 5, 43, 6, 511, DateTimeKind.Unspecified).AddTicks(8347), new TimeSpan(0, 1, 0, 0, 0)), false, new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220") },
                    { new Guid("b7f5c9e2-f2dd-4a63-8031-ebada7cd3696"), "You can use these text messages to inquire about your status.....", new DateTimeOffset(new DateTime(2024, 5, 27, 5, 43, 6, 511, DateTimeKind.Unspecified).AddTicks(8375), new TimeSpan(0, 1, 0, 0, 0)), false, new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220") },
                    { new Guid("f8fcf536-6ca7-45e1-b73c-5e8668ce785c"), "Yooooooooo hoooooooooooo!!......How are you doing!! .", new DateTimeOffset(new DateTime(2024, 5, 27, 5, 43, 6, 511, DateTimeKind.Unspecified).AddTicks(8377), new TimeSpan(0, 1, 0, 0, 0)), false, new Guid("672b5d69-c4e1-4467-95b6-5fdfa025b220") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Following_UserId",
                table: "Following",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Following");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
