using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentSecure.Migrations
{
    /// <inheritdoc />
    public partial class EncryptedLoginSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "yXKk9bUZDvhilCZmBZZwWg==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "jD6IFU9Zw3ZqcVH9HdB/kg==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "nh1PjUN3V5PXiaIEMmLQFg==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "3MzHP6In7L7tpBqNIjbnqA==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "BrYessoH7fMuT/26siod/A==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "NLAU0uwc8nP3vFtGQUe+ZQ==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "98CAgGKZQhWP27CHT5bdzw==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "ZME7dbf40cxMc54LL45z2A==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "UraK2iAw0DeDTsPtTBoB2w==");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "S58scxNNhgqzuZLjTz8CZw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "PasswordHere");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "PasswordHere");
        }
    }
}
