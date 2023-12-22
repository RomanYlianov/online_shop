using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineshop.Data.Migrations
{
    public partial class InitDatabaseStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //create database structure

            migrationBuilder.CreateTable(
                name: "deliverymethod",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliverymethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paymentmethod",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    money_value = table.Column<double>(type: "float", nullable: false),
                    payment_type = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    provider = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    cvv = table.Column<short>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymethod", x => x.id);

                    table.ForeignKey(name: "FK_paymentmethod_user_id_AspNetUser_id",
                        column: v => v.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "supplerfirm",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    register_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rating = table.Column<double>(type: "float", defaultValueSql: "0"),
                    marks_count = table.Column<long>(type: "bigint", defaultValueSql: "0"),
                    money_value = table.Column<double>(type: "float", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplerfirm", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    cipher = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    category_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    supplerfirm_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count_all = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    rating = table.Column<double>(type: "float", defaultValueSql: "0.0"),
                    marks_count = table.Column<long>(type: "bigint", defaultValueSql: "0"),
                    is_hot = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);

                    table.ForeignKey(name: "FK_product_supplerfirm_supplerfirm_id",
                        column: v => v.supplerfirm_id,
                        principalTable: "supplerfirm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(name: "FK_product_category_category_id",
                        column: v => v.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    tittle = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    text = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modification_time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.id);
                    table.ForeignKey(name: "FK_comment_product_product_id",
                       column: v => v.product_id,
                       principalTable: "product",
                       principalColumn: "id",
                       onDelete: ReferentialAction.Cascade
                   );

                    table.ForeignKey(name: "FK_comment_AspNetUsers_user_id",
                        column: v => v.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    text = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    creation_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    explanation_time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_product_product_id", x => x.id);
                    table.ForeignKey(name: "FK_event_product_product_id",
                        column: v => v.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "basket",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    buyer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    count = table.Column<int>(type: "int", nullable: false),
                    intermediate_cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_basket", x => x.id);
                    table.ForeignKey(name: "FK_basket_product_product_id",
                        column: v => v.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_comment_AspNetUsers_buyer_id",
                       column: v => v.buyer_id,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade
                   );
                }
           );

            migrationBuilder.CreateTable(
               name: "order",
               columns: table => new
               {
                   id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                   cipher = table.Column<string>(type: "nvarchar(50)", nullable: false),
                   count = table.Column<int>(type: "int", nullable: false),
                   final_price = table.Column<double>(type: "float", nullable: false),
                   buyer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   deliverymethod_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   paymentmethod_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                   mark = table.Column<double>(type: "float", nullable: false),
                   receipt_code = table.Column<short>(type: "smallint", nullable: false),
                   track_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                   order_status = table.Column<string>(type: "nvarchar(50)", nullable: false),
                   creation_time = table.Column<DateTime>(type: "datetime2", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_order", x => x.id);

                   table.ForeignKey(name: "FK_order_deliverymethod_deliverymethod_id",
                      column: v => v.deliverymethod_id,
                      principalTable: "deliverymethod",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Cascade
                   );
                   table.ForeignKey(name: "FK_order_paymentmethod_paymentmethod_id",
                      column: v => v.paymentmethod_id,
                      principalTable: "paymentmethod",
                      principalColumn: "id",
                      onDelete: ReferentialAction.Cascade
                   );

                   table.ForeignKey(name: "FK_order_AspNetUsers_user_id",
                       column: v => v.buyer_id,
                       principalTable: "AspNetUsers",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.NoAction
                   );
               }
           );

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    products_count = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.product_id, x.order_id });

                    table.ForeignKey(name: "FK_OrderProduct_order_id",
                     column: v => v.order_id,
                     principalTable: "order",
                     principalColumn: "id",
                     onDelete: ReferentialAction.Cascade
                 );

                    table.ForeignKey(name: "FK_OrderProduct_product_id",
                     column: v => v.product_id,
                     principalTable: "product",
                     principalColumn: "id",
                     onDelete: ReferentialAction.NoAction
                 );
                });

            migrationBuilder.CreateTable(
                name: "evaluationQueue",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    buyer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    product_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_added_comment = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    is_rate_product = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evaluationQueue", x => x.id);
                    table.ForeignKey(name: "FK_evaluationQueue_AspNetUsers_buyer_id",
                        column: v => v.buyer_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_evaluationQueue_product_product_id",
                        column: v => v.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(name: "FK_evaluationQueue_order_order_id",
                       column: v => v.order_id,
                       principalTable: "order",
                       principalColumn: "id",
                       onDelete: ReferentialAction.NoAction
                   );
                }
             );
            migrationBuilder.CreateTable(
                name: "UserSupplerfirm",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    supplerfirm_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSupplerFirm", x => new { x.supplerfirm_id, x.user_id });
                    table.ForeignKey(name: "FK_UserSupplerfirm_AspNetUsers_Id",
                        column: v => v.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(name: "FK_UserSupplerfirm_SupplerFirm_id",
                        column: x => x.supplerfirm_id,
                        principalTable: "supplerfirm",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "deliverymethod");
            migrationBuilder.DropTable(name: "paymentmethod");
            migrationBuilder.DropTable(name: "supplerfirm");
            migrationBuilder.DropTable(name: "category");
            migrationBuilder.DropTable(name: "product");
            migrationBuilder.DropTable(name: "comment");
            migrationBuilder.DropTable(name: "event");
            migrationBuilder.DropTable(name: "basket");
            migrationBuilder.DropTable(name: "order");
            migrationBuilder.DropTable(name: "evaluationQueue");
            migrationBuilder.DropTable(name: "UserSupplerFirm");
            migrationBuilder.DropTable(name: "UserSupplerFirm");
        }
    }
}
