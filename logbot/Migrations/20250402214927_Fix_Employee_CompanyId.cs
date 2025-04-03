using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logbot.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Employee_CompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Companies_CompanyIdId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Conversations_ConversationIdId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Employees_EmployeeIdId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Companies_CompanyIdId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationSteps_Conversations_ConversationIdId",
                table: "ConversationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_CompanyIdId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderIdId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductIdId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Companies_CompanyIdId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderIdId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_ConversationSteps_StepIdId",
                table: "UserResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_Conversations_ConversationIdId",
                table: "UserResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_Employees_EmployeeIdId",
                table: "UserResponses");

            migrationBuilder.RenameColumn(
                name: "StepIdId",
                table: "UserResponses",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "UserResponses",
                newName: "ConversationStepId");

            migrationBuilder.RenameColumn(
                name: "ConversationIdId",
                table: "UserResponses",
                newName: "ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_StepIdId",
                table: "UserResponses",
                newName: "IX_UserResponses_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_EmployeeIdId",
                table: "UserResponses",
                newName: "IX_UserResponses_ConversationStepId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_ConversationIdId",
                table: "UserResponses",
                newName: "IX_UserResponses_ConversationId");

            migrationBuilder.RenameColumn(
                name: "OrderIdId",
                table: "Payments",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CompanyIdId",
                table: "Payments",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderIdId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CompanyIdId",
                table: "Payments",
                newName: "IX_Payments_CompanyId");

            migrationBuilder.RenameColumn(
                name: "ProductIdId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrderIdId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductIdId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderIdId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameColumn(
                name: "CompanyIdId",
                table: "Messages",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CompanyIdId",
                table: "Messages",
                newName: "IX_Messages_CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyIdId",
                table: "Employees",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyIdId",
                table: "Employees",
                newName: "IX_Employees_CompanyId");

            migrationBuilder.RenameColumn(
                name: "ConversationIdId",
                table: "ConversationSteps",
                newName: "ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationSteps_ConversationIdId",
                table: "ConversationSteps",
                newName: "IX_ConversationSteps_ConversationId");

            migrationBuilder.RenameColumn(
                name: "CompanyIdId",
                table: "Conversations",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_CompanyIdId",
                table: "Conversations",
                newName: "IX_Conversations_CompanyId");

            migrationBuilder.RenameColumn(
                name: "EmployeeIdId",
                table: "ConversationLogs",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "ConversationIdId",
                table: "ConversationLogs",
                newName: "ConversationId");

            migrationBuilder.RenameColumn(
                name: "CompanyIdId",
                table: "ConversationLogs",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_EmployeeIdId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_ConversationIdId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_ConversationId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_CompanyIdId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Companies_CompanyId",
                table: "ConversationLogs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Conversations_ConversationId",
                table: "ConversationLogs",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Employees_EmployeeId",
                table: "ConversationLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Companies_CompanyId",
                table: "Conversations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationSteps_Conversations_ConversationId",
                table: "ConversationSteps",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_CompanyId",
                table: "Messages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_ConversationSteps_ConversationStepId",
                table: "UserResponses",
                column: "ConversationStepId",
                principalTable: "ConversationSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_Conversations_ConversationId",
                table: "UserResponses",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_Employees_EmployeeId",
                table: "UserResponses",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Companies_CompanyId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Conversations_ConversationId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationLogs_Employees_EmployeeId",
                table: "ConversationLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_Companies_CompanyId",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationSteps_Conversations_ConversationId",
                table: "ConversationSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Companies_CompanyId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Companies_CompanyId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_ConversationSteps_ConversationStepId",
                table: "UserResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_Conversations_ConversationId",
                table: "UserResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserResponses_Employees_EmployeeId",
                table: "UserResponses");

            migrationBuilder.DropIndex(
                name: "IX_Products_CompanyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CompanyId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "UserResponses",
                newName: "StepIdId");

            migrationBuilder.RenameColumn(
                name: "ConversationStepId",
                table: "UserResponses",
                newName: "EmployeeIdId");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "UserResponses",
                newName: "ConversationIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_EmployeeId",
                table: "UserResponses",
                newName: "IX_UserResponses_StepIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_ConversationStepId",
                table: "UserResponses",
                newName: "IX_UserResponses_EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_UserResponses_ConversationId",
                table: "UserResponses",
                newName: "IX_UserResponses_ConversationIdId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Payments",
                newName: "OrderIdId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Payments",
                newName: "CompanyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                newName: "IX_Payments_OrderIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_CompanyId",
                table: "Payments",
                newName: "IX_Payments_CompanyIdId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "ProductIdId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "OrderIdId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductIdId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderIdId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Messages",
                newName: "CompanyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_CompanyId",
                table: "Messages",
                newName: "IX_Messages_CompanyIdId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Employees",
                newName: "CompanyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                newName: "IX_Employees_CompanyIdId");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "ConversationSteps",
                newName: "ConversationIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationSteps_ConversationId",
                table: "ConversationSteps",
                newName: "IX_ConversationSteps_ConversationIdId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Conversations",
                newName: "CompanyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_CompanyId",
                table: "Conversations",
                newName: "IX_Conversations_CompanyIdId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "ConversationLogs",
                newName: "EmployeeIdId");

            migrationBuilder.RenameColumn(
                name: "ConversationId",
                table: "ConversationLogs",
                newName: "ConversationIdId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "ConversationLogs",
                newName: "CompanyIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_EmployeeId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_EmployeeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_ConversationId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_ConversationIdId");

            migrationBuilder.RenameIndex(
                name: "IX_ConversationLogs_CompanyId",
                table: "ConversationLogs",
                newName: "IX_ConversationLogs_CompanyIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Companies_CompanyIdId",
                table: "ConversationLogs",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Conversations_ConversationIdId",
                table: "ConversationLogs",
                column: "ConversationIdId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationLogs_Employees_EmployeeIdId",
                table: "ConversationLogs",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_Companies_CompanyIdId",
                table: "Conversations",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationSteps_Conversations_ConversationIdId",
                table: "ConversationSteps",
                column: "ConversationIdId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Companies_CompanyIdId",
                table: "Messages",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderIdId",
                table: "OrderItems",
                column: "OrderIdId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductIdId",
                table: "OrderItems",
                column: "ProductIdId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Companies_CompanyIdId",
                table: "Payments",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderIdId",
                table: "Payments",
                column: "OrderIdId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_ConversationSteps_StepIdId",
                table: "UserResponses",
                column: "StepIdId",
                principalTable: "ConversationSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_Conversations_ConversationIdId",
                table: "UserResponses",
                column: "ConversationIdId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserResponses_Employees_EmployeeIdId",
                table: "UserResponses",
                column: "EmployeeIdId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
