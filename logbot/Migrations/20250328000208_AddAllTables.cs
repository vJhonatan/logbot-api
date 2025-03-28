using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace logbot.Migrations
{
    /// <inheritdoc />
    public partial class AddAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_CompanyModel_CompanyIdId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyModel",
                table: "CompanyModel");

            migrationBuilder.RenameTable(
                name: "CompanyModel",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AutomatedReplies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TriggerMessage = table.Column<string>(type: "text", nullable: false),
                    ReplyMessage = table.Column<string>(type: "text", nullable: false),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomatedReplies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_Companies_CompanyIdId",
                        column: x => x.CompanyIdId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    SenderName = table.Column<string>(type: "text", nullable: false),
                    SenderId = table.Column<string>(type: "text", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Responded = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Companies_CompanyIdId",
                        column: x => x.CompanyIdId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<string>(type: "text", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConversationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Platform = table.Column<int>(type: "integer", nullable: false),
                    ConversationIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageSent = table.Column<string>(type: "text", nullable: false),
                    MessageReceived = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationLogs_Companies_CompanyIdId",
                        column: x => x.CompanyIdId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationLogs_Conversations_ConversationIdId",
                        column: x => x.ConversationIdId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationLogs_Employees_EmployeeIdId",
                        column: x => x.EmployeeIdId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConversationIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepOrder = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    ExpectedResponseType = table.Column<int>(type: "integer", nullable: false),
                    NextStepId = table.Column<Guid>(type: "uuid", nullable: true),
                    Action = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationSteps_Conversations_ConversationIdId",
                        column: x => x.ConversationIdId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Companies_CompanyIdId",
                        column: x => x.CompanyIdId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderIdId",
                        column: x => x.OrderIdId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderIdId",
                        column: x => x.OrderIdId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductIdId",
                        column: x => x.ProductIdId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConversationIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    StepIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeIdId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResponseContent = table.Column<string>(type: "text", nullable: false),
                    ReceivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserResponses_ConversationSteps_StepIdId",
                        column: x => x.StepIdId,
                        principalTable: "ConversationSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResponses_Conversations_ConversationIdId",
                        column: x => x.ConversationIdId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResponses_Employees_EmployeeIdId",
                        column: x => x.EmployeeIdId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationLogs_CompanyIdId",
                table: "ConversationLogs",
                column: "CompanyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationLogs_ConversationIdId",
                table: "ConversationLogs",
                column: "ConversationIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationLogs_EmployeeIdId",
                table: "ConversationLogs",
                column: "EmployeeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_CompanyIdId",
                table: "Conversations",
                column: "CompanyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationSteps_ConversationIdId",
                table: "ConversationSteps",
                column: "ConversationIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CompanyIdId",
                table: "Messages",
                column: "CompanyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderIdId",
                table: "OrderItems",
                column: "OrderIdId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductIdId",
                table: "OrderItems",
                column: "ProductIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CompanyIdId",
                table: "Payments",
                column: "CompanyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderIdId",
                table: "Payments",
                column: "OrderIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_ConversationIdId",
                table: "UserResponses",
                column: "ConversationIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_EmployeeIdId",
                table: "UserResponses",
                column: "EmployeeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResponses_StepIdId",
                table: "UserResponses",
                column: "StepIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees",
                column: "CompanyIdId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyIdId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "AutomatedReplies");

            migrationBuilder.DropTable(
                name: "ConversationLogs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UserResponses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ConversationSteps");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "CompanyModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyModel",
                table: "CompanyModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_CompanyModel_CompanyIdId",
                table: "Employees",
                column: "CompanyIdId",
                principalTable: "CompanyModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
