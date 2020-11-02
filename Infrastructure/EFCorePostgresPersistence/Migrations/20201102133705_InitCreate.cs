using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePostgresPersistence.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Username = table.Column<string>(nullable: true),
                    PrimaryEmailEmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountEmailAddresses",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(nullable: false),
                    IsVerified = table.Column<bool>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountEmailAddresses", x => x.EmailAddress);
                    table.ForeignKey(
                        name: "FK_AccountEmailAddresses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthTokens",
                columns: table => new
                {
                    TokenString = table.Column<string>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    LastUsed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthTokens", x => x.TokenString);
                    table.ForeignKey(
                        name: "FK_AuthTokens_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    AccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Claims_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordCredentials",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHashingAlgorithm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordCredentials", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_PasswordCredentials_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerificationTokens",
                columns: table => new
                {
                    VerificationToken = table.Column<string>(nullable: false),
                    EmailAddress1 = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerificationTokens", x => x.VerificationToken);
                    table.ForeignKey(
                        name: "FK_EmailVerificationTokens_AccountEmailAddresses_EmailAddress1",
                        column: x => x.EmailAddress1,
                        principalTable: "AccountEmailAddresses",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetTokens",
                columns: table => new
                {
                    ResetToken = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PasswordCredentialAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetTokens", x => x.ResetToken);
                    table.ForeignKey(
                        name: "FK_PasswordResetTokens_PasswordCredentials_PasswordCredentialA~",
                        column: x => x.PasswordCredentialAccountId,
                        principalTable: "PasswordCredentials",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountEmailAddresses_AccountId",
                table: "AccountEmailAddresses",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PrimaryEmailEmailAddress",
                table: "Accounts",
                column: "PrimaryEmailEmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AuthTokens_AccountId",
                table: "AuthTokens",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_AccountId",
                table: "Claims",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerificationTokens_EmailAddress1",
                table: "EmailVerificationTokens",
                column: "EmailAddress1");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetTokens_PasswordCredentialAccountId",
                table: "PasswordResetTokens",
                column: "PasswordCredentialAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AccountEmailAddresses_PrimaryEmailEmailAddress",
                table: "Accounts",
                column: "PrimaryEmailEmailAddress",
                principalTable: "AccountEmailAddresses",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountEmailAddresses_Accounts_AccountId",
                table: "AccountEmailAddresses");

            migrationBuilder.DropTable(
                name: "AuthTokens");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "EmailVerificationTokens");

            migrationBuilder.DropTable(
                name: "PasswordResetTokens");

            migrationBuilder.DropTable(
                name: "PasswordCredentials");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountEmailAddresses");
        }
    }
}
