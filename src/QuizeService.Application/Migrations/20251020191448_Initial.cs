using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using QuizeService.Domain.Questions;

#nullable disable

namespace QuizeService.Application.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AvatarId = table.Column<Guid>(type: "uuid", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    middle_name = table.Column<string>(type: "text", nullable: true),
                    Platoon = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "match_questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: true),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false),
                    left_column = table.Column<List<Pair>>(type: "jsonb", nullable: false),
                    right_column = table.Column<List<Pair>>(type: "jsonb", nullable: false),
                    correct_matches = table.Column<List<CorrectMatch>>(type: "jsonb", nullable: false),
                    TestId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_match_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_match_questions_Tests_TestId1",
                        column: x => x.TestId1,
                        principalTable: "Tests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_match_questions_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "single_choice_questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: true),
                    options = table.Column<List<Pair>>(type: "jsonb", nullable: false),
                    correct_answers = table.Column<List<int>>(type: "jsonb", nullable: false),
                    TestId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_single_choice_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_single_choice_questions_Tests_TestId1",
                        column: x => x.TestId1,
                        principalTable: "Tests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_single_choice_questions_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "text_input_questions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question_text = table.Column<string>(type: "text", nullable: false),
                    image_id = table.Column<Guid>(type: "uuid", nullable: true),
                    case_sensitive = table.Column<bool>(type: "boolean", nullable: false),
                    correct_answers = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_text_input_questions", x => x.id);
                    table.ForeignKey(
                        name: "FK_text_input_questions_Tests_test_id",
                        column: x => x.test_id,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_match_questions_test_id",
                table: "match_questions",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_match_questions_TestId1",
                table: "match_questions",
                column: "TestId1");

            migrationBuilder.CreateIndex(
                name: "IX_single_choice_questions_test_id",
                table: "single_choice_questions",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_single_choice_questions_TestId1",
                table: "single_choice_questions",
                column: "TestId1");

            migrationBuilder.CreateIndex(
                name: "IX_text_input_questions_test_id",
                table: "text_input_questions",
                column: "test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "match_questions");

            migrationBuilder.DropTable(
                name: "single_choice_questions");

            migrationBuilder.DropTable(
                name: "text_input_questions");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Tests");
        }
    }
}
