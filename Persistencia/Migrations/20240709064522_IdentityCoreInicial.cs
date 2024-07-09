using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class IdentityCoreInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreCompleto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NombreCategoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DNI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUC = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombres = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecharegistro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DatosEscaneo",
                columns: table => new
                {
                    DatosEscaneoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NuevoStock = table.Column<int>(type: "int", nullable: true),
                    AnteriorStock = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEscaneo", x => x.DatosEscaneoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TipoMetodo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrecioWeb",
                columns: table => new
                {
                    PrecioWebId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioWeb", x => x.PrecioWebId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    ProductoProveedorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Preciocompra = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Preciounitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => x.ProductoProveedorId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StockMinimo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClienteId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompraPago",
                columns: table => new
                {
                    CompraPagoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaPago = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MontoPago = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MetodoPagoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraPago", x => x.CompraPagoId);
                    table.ForeignKey(
                        name: "FK_CompraPago_MetodoPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contacto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RUC = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecharegistro = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProductoProveedorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedor_ProductoProveedor_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedor",
                        principalColumn: "ProductoProveedorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrecioWebProducto",
                columns: table => new
                {
                    PrecioWebProductoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AnteriorPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NuevoPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PrecioWebId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioWebProducto", x => x.PrecioWebProductoId);
                    table.ForeignKey(
                        name: "FK_PrecioWebProducto_PrecioWeb_PrecioWebId",
                        column: x => x.PrecioWebId,
                        principalTable: "PrecioWeb",
                        principalColumn: "PrecioWebId");
                    table.ForeignKey(
                        name: "FK_PrecioWebProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    DetallePedidoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    VentaId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaPedido = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.DetallePedidoId);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_DetallePedido_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    InventarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FechaEntrada = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CantidadProducto = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventario_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Devolucion",
                columns: table => new
                {
                    DevolucionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetallePedidoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucion", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK_Devolucion_DetallePedido_DetallePedidoId",
                        column: x => x.DetallePedidoId,
                        principalTable: "DetallePedido",
                        principalColumn: "DetallePedidoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleInventario",
                columns: table => new
                {
                    DetalleInventarioId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StockAnterior = table.Column<int>(type: "int", nullable: true),
                    StockIngreso = table.Column<int>(type: "int", nullable: true),
                    StockTotal = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    InventarioId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleInventario", x => x.DetalleInventarioId);
                    table.ForeignKey(
                        name: "FK_DetalleInventario_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "InventarioId");
                    table.ForeignKey(
                        name: "FK_DetalleInventario_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InventarioProducto",
                columns: table => new
                {
                    InventarioProductoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Fechaentrega = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    InventarioId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ProductoProveedorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioProducto", x => x.InventarioProductoId);
                    table.ForeignKey(
                        name: "FK_InventarioProducto_Inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Inventario",
                        principalColumn: "InventarioId");
                    table.ForeignKey(
                        name: "FK_InventarioProducto_ProductoProveedor_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedor",
                        principalColumn: "ProductoProveedorId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "NombreCategoria" },
                values: new object[,]
                {
                    { new Guid("19f3d846-3d87-4ccf-8120-f7d6e6c45e16"), "Placa madre" },
                    { new Guid("311da66f-5494-4b12-93bd-65471f93f4c6"), "Memoria RAM" },
                    { new Guid("55eb20f0-59db-402e-87e1-ba366915766e"), "Tarjeta gráfica" },
                    { new Guid("8bc7b025-5ed5-4f62-999f-ecbf15230cd8"), "Procesador" },
                    { new Guid("d22ab31f-9451-4dc6-a849-19790a4422b1"), "Fuente de alimentación" },
                    { new Guid("e56bd5b2-65f2-4f69-86a5-e3925be8b268"), "Disco duro SSD" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "DNI", "Direccion", "Email", "Fecharegistro", "Nombres", "RUC", "Telefono" },
                values: new object[,]
                {
                    { new Guid("072ce1a2-d27e-4bbc-8dee-3bb4a26e2c52"), "27768334", "Calle C, 54, Lima", "contacto352@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8617), "Ana Juan", "20428729201", "759133910" },
                    { new Guid("146374ef-5bc3-4aa1-86f2-dd31b0905f23"), "33447984", "Calle B, 39, Piura", "comprador545@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8608), "Carlos Carlos", "20428729201", "876015641" },
                    { new Guid("185c3c62-9f9d-4049-b75c-a525bf9ca611"), "32483881", "Calle A, 71, Lima", "correo794@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8531), "Lucía Ana", "20428729201", "784177984" },
                    { new Guid("1f5bef0a-0347-434c-9a04-e8cfb45ea512"), "74560453", "Calle D, 52, Piura", "cliente812@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8693), "Laura Juan", "20428729201", "417315050" },
                    { new Guid("20c6b5ab-03a9-40d4-89c3-556fc9e82a54"), "17744149", "Calle D, 79, Cusco", "correo74@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8627), "Luis Luis", "20428729201", "489212141" },
                    { new Guid("23e51e2d-6859-4822-a757-67103616b687"), "21940017", "Calle A, 18, Trujillo", "correo33@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8743), "Carlos María", "20428729201", "247293245" },
                    { new Guid("262f8e43-3c50-4c2e-8808-386268259b3b"), "34553407", "Calle B, 50, Trujillo", "usuario571@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8846), "María Diego", "20428729201", "201702762" },
                    { new Guid("29ab1cb0-029e-41e7-9ea1-6f21c86b17fe"), "69879300", "Calle D, 89, Piura", "cliente756@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8825), "Diego Luis", "20428729201", "978778826" },
                    { new Guid("2ae221e8-26ab-4a89-a285-9394ed9d54fc"), "74587820", "Calle C, 96, Trujillo", "usuario833@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8536), "Pedro Luis", "20428729201", "854608599" },
                    { new Guid("2bafddb5-f6bd-483a-93a3-0742d58d5d24"), "98893574", "Calle A, 21, Cusco", "comprador679@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8807), "Lucía Ana", "20428729201", "290588259" },
                    { new Guid("2ca29e10-04ed-4e19-81ef-1d3c6d660602"), "76998441", "Calle B, 53, Piura", "contacto754@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8829), "Lucía Carlos", "20428729201", "755850393" },
                    { new Guid("2d6cd22b-cc3a-4e3d-96bb-87a525507385"), "67490942", "Calle E, 3, Piura", "cliente161@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8771), "María Ana", "20428729201", "410681979" },
                    { new Guid("34b5b3a4-6500-487c-8ba4-096e2ab4dafd"), "61323090", "Calle B, 84, Cusco", "cliente847@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8541), "Lucía Laura", "20428729201", "280998310" },
                    { new Guid("3589a5ce-059e-49cf-a9e7-f5055b22677d"), "67220744", "Calle D, 21, Arequipa", "comprador352@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8582), "Sofía Lucía", "20428729201", "573812581" },
                    { new Guid("39a50513-d633-49b3-9aa2-a660e8e29134"), "38012646", "Calle B, 31, Trujillo", "usuario705@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8577), "Laura Pedro", "20428729201", "542068233" },
                    { new Guid("3b1de3ee-d174-4cd8-90eb-747557bf3597"), "28843581", "Calle D, 46, Piura", "cliente332@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8599), "Diego Juan", "20428729201", "567593358" },
                    { new Guid("3ff14285-2536-4346-a0ad-ac80250764dd"), "27086838", "Calle D, 98, Arequipa", "contacto703@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8753), "Sofía Ana", "20428729201", "983441752" },
                    { new Guid("407af8c9-ed8c-44d2-b9ca-98e1b34716d9"), "75501278", "Calle C, 18, Trujillo", "cliente559@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8812), "Laura María", "20428729201", "456286636" },
                    { new Guid("46bd69da-64af-4a84-ba4a-42a8cffa9710"), "16352421", "Calle C, 2, Cusco", "correo880@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8837), "Juan Diego", "20428729201", "344655070" },
                    { new Guid("4f50c028-6878-4b5a-9a88-842a9fac37d9"), "44078247", "Calle D, 95, Piura", "comprador467@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8820), "Laura Juan", "20428729201", "285795366" },
                    { new Guid("559fa0ec-ad09-48f6-a84f-f7ada5cc57b8"), "63266548", "Calle D, 5, Piura", "cliente626@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8674), "Carlos Juan", "20428729201", "308354253" },
                    { new Guid("5e764bd0-73f0-4e6d-94cf-b9f4b2113265"), "79350623", "Calle E, 62, Arequipa", "comprador947@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8842), "Sofía Carlos", "20428729201", "525334838" },
                    { new Guid("69e92ba4-af53-4b35-bd3f-44c41834f76b"), "92813222", "Calle D, 9, Piura", "correo125@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8546), "Diego Carlos", "20428729201", "822865713" },
                    { new Guid("6e33393e-83c3-4ef4-ab6c-d01ef9ada7ad"), "54458992", "Calle D, 22, Lima", "cliente336@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8661), "Pedro Luis", "20428729201", "581813392" },
                    { new Guid("7435aae5-c69c-4bf2-bcbb-274ae968b7e1"), "18071500", "Calle A, 3, Trujillo", "usuario704@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8656), "María Sofía", "20428729201", "710413041" },
                    { new Guid("743b703b-e811-4d79-893b-2077883964ce"), "28792775", "Calle A, 88, Lima", "cliente640@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8678), "Laura Pedro", "20428729201", "363206263" },
                    { new Guid("762d2ec6-f554-4351-8d54-4590b5365411"), "72266226", "Calle B, 44, Trujillo", "contacto865@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8734), "Diego Juan", "20428729201", "278572453" },
                    { new Guid("802d71f9-4b4d-47de-85fb-d164ec5d7216"), "17524683", "Calle B, 80, Cusco", "cliente838@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8816), "Ana Carlos", "20428729201", "293090187" },
                    { new Guid("805c723f-4bda-4c1d-bccf-ba765d057738"), "52459379", "Calle C, 19, Trujillo", "correo136@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8730), "Lucía Ana", "20428729201", "907558272" },
                    { new Guid("94ab8811-28b5-4349-a0ce-5bbb2b5db5da"), "76569211", "Calle D, 10, Trujillo", "cliente301@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8604), "Luis Carlos", "20428729201", "585606322" },
                    { new Guid("98bcc89d-8c56-4322-b213-2640d5d07686"), "67714031", "Calle A, 19, Trujillo", "contacto10@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8594), "María María", "20428729201", "306549007" },
                    { new Guid("99a175d2-b5d7-4e61-b7f1-4106ec6bc67a"), "63018711", "Calle B, 84, Piura", "cliente277@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8749), "Sofía Carlos", "20428729201", "687972854" },
                    { new Guid("9ffd09b4-c9fe-4706-ba7c-e065c0c28b1c"), "52608402", "Calle C, 92, Piura", "comprador523@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8739), "Luis Lucía", "20428729201", "328164170" },
                    { new Guid("a3f862c3-5c95-4f1f-ba0f-9304a2ce8a54"), "84547008", "Calle E, 71, Piura", "contacto416@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8761), "Sofía Ana", "20428729201", "259136534" },
                    { new Guid("abbbdc14-1583-447b-a505-d3d27d0e73e0"), "34586180", "Calle B, 89, Arequipa", "usuario646@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8589), "María Carlos", "20428729201", "598916548" },
                    { new Guid("abe74a75-ae3e-4a4d-b2e5-6fdacb203135"), "11191493", "Calle E, 16, Lima", "usuario430@hotmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8698), "Lucía Pedro", "20428729201", "888888057" },
                    { new Guid("b23b4b40-a557-4977-bccc-776f162fe65e"), "27516469", "Calle E, 52, Arequipa", "correo44@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8779), "Diego Ana", "20428729201", "338001075" },
                    { new Guid("b7ab3caa-ea41-42a3-8947-3aa2e0096ff8"), "56094260", "Calle B, 98, Trujillo", "usuario939@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8757), "Sofía Lucía", "20428729201", "221838571" },
                    { new Guid("b9ae2790-3b4c-40eb-81fc-b98a0c793264"), "31483201", "Calle E, 15, Cusco", "cliente137@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8666), "Ana Sofía", "20428729201", "612127311" },
                    { new Guid("c1e92e1e-99c1-4229-be0f-ffb166443d35"), "75946486", "Calle A, 61, Lima", "cliente24@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8613), "Diego Pedro", "20428729201", "238871430" },
                    { new Guid("c5469194-907c-4f9c-a2c4-44568950a049"), "34826166", "Calle C, 77, Cusco", "cliente169@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8775), "Carlos Luis", "20428729201", "430662889" },
                    { new Guid("c85d1256-f316-4067-a37d-07438ed155c2"), "99479770", "Calle B, 46, Piura", "cliente183@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8683), "Luis María", "20428729201", "534247091" },
                    { new Guid("cb75628a-28ae-4303-acf2-40f537993669"), "12902089", "Calle C, 36, Trujillo", "cliente847@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8670), "María Sofía", "20428729201", "844307363" },
                    { new Guid("d13b1ade-a82c-4399-b1f5-3fadbe0c0d69"), "10303286", "Calle D, 78, Lima", "cliente877@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8621), "Laura Pedro", "20428729201", "629926953" },
                    { new Guid("d6de0b72-8105-4e27-bb98-3761a6ea5933"), "59787142", "Calle E, 2, Cusco", "cliente847@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8767), "Pedro Ana", "20428729201", "385842380" },
                    { new Guid("d8c2986d-5775-4e46-a476-9086da2de01d"), "70091790", "Calle B, 22, Arequipa", "correo713@gmail.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8702), "Luis Ana", "20428729201", "808657605" },
                    { new Guid("e22d6121-aa6e-4c8b-8ee7-8bae9f8790a2"), "30223230", "Calle E, 49, Trujillo", "usuario193@example.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8689), "Laura Sofía", "20428729201", "559682528" },
                    { new Guid("e2796f59-acb7-4ddf-ab94-967bc17f39cc"), "61606075", "Calle B, 22, Arequipa", "contacto583@yahoo.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8526), "Diego Pedro", "20428729201", "158227086" },
                    { new Guid("e512828d-2157-425f-ac45-f6ebdadd8a35"), "20609013", "Calle A, 82, Lima", "contacto508@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8833), "Juan Carlos", "20428729201", "569732748" },
                    { new Guid("e54d164c-9c75-4717-882a-cc75b5000fd3"), "74031920", "Calle D, 90, Lima", "usuario447@outlook.com", new DateTime(2024, 7, 9, 6, 45, 21, 833, DateTimeKind.Utc).AddTicks(8515), "Ana Luis", "20428729201", "898794259" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPago",
                columns: new[] { "MetodoPagoId", "TipoMetodo" },
                values: new object[,]
                {
                    { new Guid("57cc5106-ecfe-4446-addf-25189c512fe8"), "American Express" },
                    { new Guid("8cb8e463-d57e-435b-9c7b-db23e06355ec"), "MasterCard" },
                    { new Guid("bcd7e399-f6c0-4c62-9384-9c09db747bc6"), "efectivo" },
                    { new Guid("c30fa8e1-6e41-463f-b148-cdf8632574f1"), "Visa" },
                    { new Guid("fc76310c-facb-4ed5-b4b3-d824839d80ef"), "PayPal" }
                });

            migrationBuilder.InsertData(
                table: "ProductoProveedor",
                columns: new[] { "ProductoProveedorId", "Preciocompra", "Preciounitario" },
                values: new object[,]
                {
                    { new Guid("04e80c47-c593-4d67-be1c-bb87a2111432"), 453.53m, 539.57m },
                    { new Guid("04ebf9ef-3297-4c41-a75b-84e0a90f57e5"), 992.56m, 644.79m },
                    { new Guid("06b14ef2-c748-4ebd-93a1-ce95e88bd026"), 605.00m, 151.91m },
                    { new Guid("07f59584-bc67-45b5-881f-c60a7839b35a"), 434.88m, 309.07m },
                    { new Guid("088fedaa-2f23-4817-a1d5-9c453805b592"), 52.84m, 491.36m },
                    { new Guid("09004982-7843-4dc2-abed-5ac0782bb89e"), 683.62m, 973.41m },
                    { new Guid("09caa86d-caba-4bac-a404-f58f6a7af43d"), 405.41m, 659.12m },
                    { new Guid("0c1dae8e-640d-46ad-9c22-107ffc1e5b72"), 74.62m, 706.19m },
                    { new Guid("11389a39-d9e7-4807-a209-38191249a5cc"), 543.35m, 420.63m },
                    { new Guid("1bd4ba98-8375-4ce7-af35-89d0f86136b1"), 45.34m, 357.08m },
                    { new Guid("1d11ab51-32a9-4b43-85e6-e266b9df8608"), 687.51m, 416.37m },
                    { new Guid("2227f996-0438-44c0-ad4b-7f93be941b6a"), 764.86m, 255.93m },
                    { new Guid("2c4f1531-c139-4945-80e2-508f288b8f22"), 331.37m, 491.83m },
                    { new Guid("335e88f5-ec25-4fa9-b448-eb802624ae75"), 515.48m, 20.57m },
                    { new Guid("43436ac6-bc44-4169-aa12-e924b9fe8b7b"), 815.93m, 427.18m },
                    { new Guid("46defa87-a46d-4226-9ea2-7226e4bd7ab3"), 82.38m, 258.79m },
                    { new Guid("48249c6a-5b7b-4202-8395-8a1353df8c7d"), 260.74m, 40.88m },
                    { new Guid("4fd7bbf8-15c8-403a-9184-2df01b7f33fa"), 173.02m, 166.09m },
                    { new Guid("588e95a3-9dc9-48c3-9f6e-e74170c0e75b"), 927.92m, 753.11m },
                    { new Guid("593a99af-487c-4e7d-a7cf-acc6c64f9a42"), 51.05m, 975.27m },
                    { new Guid("5b779871-73a5-45f2-a31f-26517cb21cb1"), 693.45m, 496.26m },
                    { new Guid("5caa93f0-3f62-43e3-8418-de8a0844180d"), 805.06m, 934.06m },
                    { new Guid("7396d7e0-fb06-4b2e-a819-565f064819a3"), 474.53m, 170.05m },
                    { new Guid("76611625-e493-4d24-9d71-790b62bd4378"), 703.98m, 21.11m },
                    { new Guid("7cf65263-bb02-4325-89fb-f22c7827f4d4"), 328.76m, 48.92m },
                    { new Guid("87049c8d-66f5-46d5-b977-a2a92ac97fff"), 171.91m, 398.22m },
                    { new Guid("879270a0-33ac-4e92-94c5-97627cf0964f"), 917.08m, 544.84m },
                    { new Guid("889b6fa2-2aec-45f2-bcef-0e17d7bec959"), 10.78m, 570.34m },
                    { new Guid("8b723b47-1f6f-4f1e-8a1c-16f4e74bc2f7"), 57.56m, 627.30m },
                    { new Guid("8d29e189-0759-4590-88b7-1fb908e4b98d"), 219.62m, 665.34m },
                    { new Guid("95df3988-cd85-4824-b1d8-170288228884"), 809.00m, 832.34m },
                    { new Guid("9a896212-e2de-48ef-aeb5-cc9915f3cb21"), 721.49m, 345.21m },
                    { new Guid("9ad4ac0c-56a2-495c-b18f-404d35e2595e"), 554.51m, 650.67m },
                    { new Guid("9d78c114-8d0f-4bd0-b02f-770066a6c4fe"), 722.24m, 586.83m },
                    { new Guid("a2354b1d-a4ed-4fe0-81f5-65cf15b820d3"), 631.39m, 586.42m },
                    { new Guid("a32fd5ec-0407-41cc-995a-20afd36048be"), 237.19m, 862.40m },
                    { new Guid("b3c02f61-b1b8-4101-9240-ba7cb9ee6969"), 404.80m, 678.74m },
                    { new Guid("b93869ba-9655-493a-96cb-c94e2358988c"), 558.19m, 294.94m },
                    { new Guid("bf027b6c-0b07-4fb9-8172-a87b7e7d0ab9"), 791.98m, 839.98m },
                    { new Guid("cabebff7-9b6d-4072-89c8-92fce6ef2a8d"), 317.02m, 520.36m },
                    { new Guid("cdbaa7d4-0e7f-4c4f-af86-069c25fa4ab9"), 180.48m, 169.73m },
                    { new Guid("cf0f0d0f-f68e-44b7-b353-117d06aef45c"), 185.61m, 925.92m },
                    { new Guid("cfbc0c5b-0948-43e2-9f59-2c85a5a2aaef"), 341.47m, 794.23m },
                    { new Guid("d250d2da-9713-43f2-8cd2-918ece870ac9"), 731.96m, 35.74m },
                    { new Guid("db432f06-0040-4c4e-8ff1-94cb51dc423d"), 655.26m, 109.34m },
                    { new Guid("e14c6d7a-a8d8-428d-a4df-72d1da27e292"), 537.93m, 861.74m },
                    { new Guid("e364a05c-5e6f-40c9-b526-055dc7314f3b"), 775.42m, 796.04m },
                    { new Guid("ee8f66b4-ee7e-4fc6-9782-8a063326755c"), 318.21m, 297.68m },
                    { new Guid("efb6651a-a7a6-497d-b030-31381f8ba953"), 928.87m, 952.70m },
                    { new Guid("f1b4ac25-01e4-4953-aab1-a107856ff207"), 351.54m, 897.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompraPago_MetodoPagoId",
                table: "CompraPago",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInventario_InventarioId",
                table: "DetalleInventario",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInventario_ProductoId",
                table: "DetalleInventario",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoId",
                table: "DetallePedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_VentaId",
                table: "DetallePedido",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucion_DetallePedidoId",
                table: "Devolucion",
                column: "DetallePedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_ProveedorId",
                table: "Inventario",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_InventarioId",
                table: "InventarioProducto",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_ProductoProveedorId",
                table: "InventarioProducto",
                column: "ProductoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioWebProducto_PrecioWebId",
                table: "PrecioWebProducto",
                column: "PrecioWebId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioWebProducto_ProductoId",
                table: "PrecioWebProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaId",
                table: "Producto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_ProductoProveedorId",
                table: "Proveedor",
                column: "ProductoProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_ClienteId",
                table: "Venta",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CompraPago");

            migrationBuilder.DropTable(
                name: "DatosEscaneo");

            migrationBuilder.DropTable(
                name: "DetalleInventario");

            migrationBuilder.DropTable(
                name: "Devolucion");

            migrationBuilder.DropTable(
                name: "InventarioProducto");

            migrationBuilder.DropTable(
                name: "PrecioWebProducto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "PrecioWeb");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProductoProveedor");
        }
    }
}
