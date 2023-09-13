using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddToNodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NodeId1",
                table: "nodes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_nodes_NodeId1",
                table: "nodes",
                column: "NodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_nodes_nodes_NodeId1",
                table: "nodes",
                column: "NodeId1",
                principalTable: "nodes",
                principalColumn: "NodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nodes_nodes_NodeId1",
                table: "nodes");

            migrationBuilder.DropIndex(
                name: "IX_nodes_NodeId1",
                table: "nodes");

            migrationBuilder.DropColumn(
                name: "NodeId1",
                table: "nodes");
        }
    }
}
