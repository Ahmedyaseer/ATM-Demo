using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATM.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccountIdPropertyAndUpdateTabelsNameAccountTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_accountsId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "accountsId",
                table: "Transactions",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_accountsId",
                table: "Transactions",
                newName: "IX_Transactions_accountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_accountId",
                table: "Transactions",
                column: "accountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_accountId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "Transactions",
                newName: "accountsId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_accountId",
                table: "Transactions",
                newName: "IX_Transactions_accountsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_accountsId",
                table: "Transactions",
                column: "accountsId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
