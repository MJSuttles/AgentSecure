using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentSecure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHashingFields_AddEncryptedPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Logins");

            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Logins",
                newName: "Password");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Logins",
                newName: "PasswordSalt");

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Logins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "9VA/iVDzsQCGgzeG0Fw0RSlpaBlSamO9OzJzp0i79RE=", "R5xj8P2gu8AJE0KPsiq8yg==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "CY8F8WQ8EYAbuZruzTaZDl+Nxu6bGqUXc4TY96hSbig=", "I6xXQrwYNAqj4e4YiYO5Og==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "k1Kmt7JLjWqTit4xVRXIYyDy7iORMGiBbdDQw2VGQfQ=", "D4+TXYlmXEBdUpjOLzW1Lg==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "uej4OJedlWTIj0aub04BORDZ8HBoV7/IDbE97TAFobY=", "U+LP8KasPsSjPCZBFJ77DQ==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "cPK/Sy7BpwyHs9dPA1T8U95aqknPjOrDJKDJ0ty1iLI=", "EvsjXDl1dqQiXyPgjYe5Ng==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "R83FOc1CdKqW8XaXxxdRFOdMwylwr1Ceqk7wDKpgDxA=", "VZ/gjVqFNCGwU52AEgkrBg==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "qUjlK+Rd7puN4WpSBWgF15RCEAKsgou7Xu/Yr9fCt7g=", "3REpqxWqz1Z40FixY4wqww==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "q7mwv8gP6geiDjIrKeUi7Zzg8SxP3mdw7NVmiHwzIRg=", "GwQJtcq1mKzAZhLg6gun9Q==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "wqes201ndwzAYeiUGNzze1dR8c3o3bL+sk+PV+AgSS0=", "N5WevqxTGApq/mhPUy0yxA==" });

            migrationBuilder.UpdateData(
                table: "Logins",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HashedPassword", "PasswordSalt" },
                values: new object[] { "AF+EGXI5FTlYEYOJnaHnAZxe3sClHhhF+I0mg4ki9/U=", "gwF0lFnI4pxLYUO1VxGO3w==" });
        }
    }
}
