using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM.DAL.Migrations
{
    /// <inheritdoc />
    public partial class edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_accountsId",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "accountsId",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_accountsId",
                table: "transactions",
                column: "accountsId",
                principalTable: "accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_accounts_accountsId",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "accountsId",
                table: "transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_accounts_accountsId",
                table: "transactions",
                column: "accountsId",
                principalTable: "accounts",
                principalColumn: "Id");
        }
    }
}
