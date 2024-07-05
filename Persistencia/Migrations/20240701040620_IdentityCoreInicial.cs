using System;
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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecharegistro = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "DatosEscaneo",
                columns: table => new
                {
                    DatosEscaneoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NuevoStock = table.Column<int>(type: "int", nullable: true),
                    AnteriorStock = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosEscaneo", x => x.DatosEscaneoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoMetodo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "PrecioWeb",
                columns: table => new
                {
                    PrecioWebId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioWeb", x => x.PrecioWebId);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Preciocompra = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Preciounitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => x.ProductoProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "CompraPago",
                columns: table => new
                {
                    CompraPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MontoPago = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    MetodoPagoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraPago", x => x.CompraPagoId);
                    table.ForeignKey(
                        name: "FK_CompraPago_MetodoPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoId");
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecharegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedor_ProductoProveedor_ProductoProveedorId",
                        column: x => x.ProductoProveedorId,
                        principalTable: "ProductoProveedor",
                        principalColumn: "ProductoProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "PrecioWebProducto",
                columns: table => new
                {
                    PrecioWebProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnteriorPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NuevoPrecio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PrecioWebId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    DetallePedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    VentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CantidadProducto = table.Column<int>(type: "int", nullable: true),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.InventarioId);
                    table.ForeignKey(
                        name: "FK_Inventario_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId");
                });

            migrationBuilder.CreateTable(
                name: "Devolucion",
                columns: table => new
                {
                    DevolucionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetallePedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucion", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK_Devolucion_DetallePedido_DetallePedidoId",
                        column: x => x.DetallePedidoId,
                        principalTable: "DetallePedido",
                        principalColumn: "DetallePedidoId");
                });

            migrationBuilder.CreateTable(
                name: "DetalleInventario",
                columns: table => new
                {
                    DetalleInventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockAnterior = table.Column<int>(type: "int", nullable: true),
                    StockIngreso = table.Column<int>(type: "int", nullable: true),
                    StockTotal = table.Column<int>(type: "int", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "InventarioProducto",
                columns: table => new
                {
                    InventarioProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fechaentrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    InventarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductoProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "NombreCategoria" },
                values: new object[,]
                {
                    { new Guid("03f545e4-5152-4b0a-a5d5-8f4e72010688"), "Fuente de alimentación" },
                    { new Guid("1253758b-bd00-4e7c-9bde-e76f3aaf1fc3"), "Memoria RAM" },
                    { new Guid("47fec3e6-fa34-4a0e-82cd-5a5d9638025b"), "Placa madre" },
                    { new Guid("b7019621-86a2-4b60-9a6d-323e9e0bd44a"), "Tarjeta gráfica" },
                    { new Guid("dd1f37a6-fe39-4536-ac2f-6eeeb446cf6f"), "Disco duro SSD" },
                    { new Guid("e9f4a89a-fc11-415a-b9d5-cb43a064d14d"), "Procesador" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "DNI", "Direccion", "Email", "Fecharegistro", "Nombres", "RUC", "Telefono" },
                values: new object[,]
                {
                    { new Guid("01b6b5cf-e32e-4275-82e8-f91d5a96f6fc"), "77680962", "Calle E, 70, Lima", "usuario348@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2665), "Carlos Ana", "20428729201", "566347286" },
                    { new Guid("0344b0fc-7001-44ca-a08c-60cd083bff89"), "89572608", "Calle E, 57, Arequipa", "comprador278@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2697), "Diego María", "20428729201", "269026968" },
                    { new Guid("04e9777a-e3cf-4302-94d4-3ab7a6813daf"), "91932812", "Calle D, 78, Trujillo", "usuario63@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2937), "Luis Sofía", "20428729201", "609062364" },
                    { new Guid("1803e182-2cb7-4e82-9948-8315900b3698"), "27319376", "Calle C, 77, Arequipa", "usuario976@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2704), "Juan María", "20428729201", "394389531" },
                    { new Guid("1a7a3b4c-3e50-448a-82c3-3417f899d37c"), "93368588", "Calle C, 41, Cusco", "correo804@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2862), "Juan Pedro", "20428729201", "888693657" },
                    { new Guid("1d5cf94a-9875-4d57-839a-c78f6ee10779"), "25735202", "Calle C, 5, Cusco", "cliente398@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3147), "Lucía Pedro", "20428729201", "422567215" },
                    { new Guid("29864b5a-4095-4679-ac0a-9579cd859bd2"), "70288412", "Calle B, 59, Lima", "contacto103@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3001), "Sofía Sofía", "20428729201", "801274722" },
                    { new Guid("2c1981cb-201b-4c50-9b12-c07fc70d1b87"), "77650483", "Calle E, 18, Piura", "usuario412@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2741), "Juan Pedro", "20428729201", "560012280" },
                    { new Guid("2c8a7002-1c08-471f-9ac5-9a489b2a5bb0"), "32474700", "Calle E, 38, Trujillo", "usuario9@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2964), "Ana Lucía", "20428729201", "142136800" },
                    { new Guid("305cff0c-7a1a-4670-8254-96adc51c06dd"), "57489385", "Calle B, 8, Piura", "contacto837@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3075), "Carlos Lucía", "20428729201", "336366847" },
                    { new Guid("347f7224-95a2-48ef-b7e1-7386fb138be1"), "86586260", "Calle B, 56, Arequipa", "comprador293@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2817), "Juan Diego", "20428729201", "836268823" },
                    { new Guid("39bfaa65-9e24-4d50-b9c9-499598dbe1e3"), "19279289", "Calle E, 87, Cusco", "cliente500@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3139), "Juan Luis", "20428729201", "898563628" },
                    { new Guid("3a968750-c735-444b-826c-8f0b5f9f323c"), "52014821", "Calle C, 53, Lima", "correo165@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2840), "Carlos Ana", "20428729201", "379689440" },
                    { new Guid("45423f43-43e5-453e-b4fd-6e80d8654bc7"), "67972584", "Calle A, 25, Piura", "correo318@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2621), "Ana Pedro", "20428729201", "823905666" },
                    { new Guid("4b85ad42-16dd-4929-8538-04a9d9a9c639"), "23400427", "Calle A, 57, Lima", "correo786@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2950), "Diego Pedro", "20428729201", "635893535" },
                    { new Guid("533c624a-6993-4bd0-a8b9-9a16d82338a0"), "61948335", "Calle A, 48, Cusco", "usuario794@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2810), "Juan Lucía", "20428729201", "646946924" },
                    { new Guid("5ea760be-0dd7-4354-9006-72ed75c6d452"), "26599162", "Calle E, 62, Cusco", "correo607@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2781), "Luis Laura", "20428729201", "143731125" },
                    { new Guid("623750fd-c7eb-4fb5-adf5-7da9c506e7c4"), "54468683", "Calle C, 34, Trujillo", "comprador604@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2824), "Ana Ana", "20428729201", "310259821" },
                    { new Guid("646a524e-0023-4d72-8781-43eb7c29e2dc"), "26624074", "Calle C, 20, Lima", "usuario137@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2831), "Diego María", "20428729201", "702226094" },
                    { new Guid("655fff76-84cc-4113-883c-3e4ce7fa7735"), "35323295", "Calle B, 92, Piura", "comprador516@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2711), "Laura Sofía", "20428729201", "964796459" },
                    { new Guid("68e95248-e21f-4a8e-b46b-a5f1ab6eccfc"), "12413904", "Calle A, 70, Arequipa", "correo83@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2789), "Pedro Ana", "20428729201", "526156476" },
                    { new Guid("69dd9783-ef39-4bae-862e-8734ed8c4985"), "70542805", "Calle C, 64, Cusco", "usuario618@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2900), "Luis Juan", "20428729201", "369163434" },
                    { new Guid("6c6b5062-664d-4061-9901-1466d440429d"), "12661397", "Calle E, 51, Arequipa", "contacto590@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3059), "Pedro Ana", "20428729201", "716343340" },
                    { new Guid("6d33f3be-5b27-4fc2-8a33-a5f925cd9fcc"), "52717412", "Calle B, 4, Piura", "usuario460@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2855), "Luis Laura", "20428729201", "647289987" },
                    { new Guid("6faa4622-ae0a-4ca2-ac38-c8f8ab540ae9"), "38686047", "Calle E, 78, Trujillo", "cliente67@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2804), "Juan Carlos", "20428729201", "505598613" },
                    { new Guid("72b2fc65-9719-4413-8b95-3f1fa6625fe8"), "30792270", "Calle E, 45, Arequipa", "contacto908@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3052), "Sofía Laura", "20428729201", "707974597" },
                    { new Guid("7c88385e-1a61-4100-81a9-1f9f1290af53"), "20210570", "Calle D, 41, Piura", "comprador233@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3131), "María María", "20428729201", "628706172" },
                    { new Guid("801540d3-0ce7-484a-9ff7-43a9d6551dbe"), "45413170", "Calle A, 31, Piura", "contacto998@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3045), "Laura Laura", "20428729201", "968527246" },
                    { new Guid("80a38d6b-edd9-43db-be65-9916ff225d6c"), "47173852", "Calle E, 23, Cusco", "correo53@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2748), "Laura Diego", "20428729201", "391049853" },
                    { new Guid("825a7830-c14d-47ba-b87d-faa05abdc8dd"), "45187632", "Calle A, 41, Arequipa", "cliente765@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2929), "Pedro Carlos", "20428729201", "914957220" },
                    { new Guid("82ac6336-04d1-4a2d-a069-bf1e8e7c4642"), "50590385", "Calle C, 47, Piura", "cliente986@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2726), "Lucía Lucía", "20428729201", "253261453" },
                    { new Guid("8322ab5d-11e4-44a9-af94-5499c9e42dd6"), "95005763", "Calle B, 95, Arequipa", "cliente223@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3025), "Laura Juan", "20428729201", "935339160" },
                    { new Guid("876c8bdc-398e-4e0b-ab47-dd3084e780f0"), "46571894", "Calle A, 11, Lima", "comprador399@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2686), "Luis Ana", "20428729201", "161835804" },
                    { new Guid("9da88606-3eff-49de-833f-32f26ac4d6a1"), "87762361", "Calle B, 25, Cusco", "correo888@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3031), "Laura Luis", "20428729201", "120659264" },
                    { new Guid("9fb1ad17-6348-443b-a23b-a9f2059ba0e5"), "30266638", "Calle A, 85, Lima", "contacto602@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3038), "Diego Diego", "20428729201", "100032901" },
                    { new Guid("a1dc9e8c-f1d5-4724-886b-9724797b5d71"), "67097055", "Calle A, 9, Lima", "cliente666@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2913), "Lucía Juan", "20428729201", "621552248" },
                    { new Guid("a5f5e195-a91b-489a-b29b-6b831cc58e00"), "76170625", "Calle A, 17, Piura", "comprador533@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2893), "Juan María", "20428729201", "506684380" },
                    { new Guid("aa89a168-eb8f-4c55-94f0-c9f847457a00"), "54267770", "Calle A, 83, Arequipa", "usuario726@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2796), "Carlos Pedro", "20428729201", "871068574" },
                    { new Guid("ad075ca5-4b11-47b5-afa3-2e53ba329b55"), "55512036", "Calle C, 77, Lima", "comprador703@hotmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2957), "Luis Luis", "20428729201", "407981485" },
                    { new Guid("be398d79-d55a-464c-92bb-5a2722bdef42"), "92721956", "Calle B, 72, Trujillo", "correo472@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2943), "Juan Lucía", "20428729201", "604149603" },
                    { new Guid("d27cb8b2-8202-46ee-bab1-4d8de2951182"), "20164710", "Calle B, 24, Lima", "contacto158@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2907), "Luis Lucía", "20428729201", "208395337" },
                    { new Guid("d3026257-ff9f-416c-9888-534cbbde0bcf"), "15649049", "Calle A, 22, Piura", "usuario956@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2734), "Ana María", "20428729201", "390000322" },
                    { new Guid("d9422309-a6ff-4999-b916-2109e4a5cfc1"), "50087402", "Calle A, 96, Lima", "comprador301@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3011), "Diego Pedro", "20428729201", "100958912" },
                    { new Guid("d9dab566-d7b4-48a7-8ebe-26bdd3a31044"), "37113588", "Calle D, 61, Lima", "comprador68@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3068), "Luis Juan", "20428729201", "858797063" },
                    { new Guid("e6af45ff-4274-4e5a-937c-90407d8a358e"), "80184797", "Calle A, 68, Piura", "usuario991@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2923), "Luis Laura", "20428729201", "302134054" },
                    { new Guid("e773edc4-e565-4409-bcb9-bc85168d80ec"), "65541326", "Calle E, 17, Cusco", "usuario829@example.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2676), "Sofía Luis", "20428729201", "430387712" },
                    { new Guid("e7e16985-c52b-4018-b2a9-8c3a3f810856"), "47997607", "Calle B, 98, Cusco", "contacto460@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2848), "María Laura", "20428729201", "326971860" },
                    { new Guid("e898429f-db9d-4761-a069-52c8d804f1bb"), "88071788", "Calle D, 39, Arequipa", "contacto596@outlook.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2719), "Luis Pedro", "20428729201", "577374377" },
                    { new Guid("e95725be-fb71-498f-9d9f-ddf7948d771d"), "75517717", "Calle B, 78, Lima", "correo954@gmail.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(2608), "María Lucía", "20428729201", "575740018" },
                    { new Guid("fb426b74-9fb8-4de2-a8df-174a514de1a6"), "96742254", "Calle B, 96, Trujillo", "usuario499@yahoo.com", new DateTime(2024, 7, 1, 4, 6, 20, 5, DateTimeKind.Utc).AddTicks(3018), "Luis Sofía", "20428729201", "265737609" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPago",
                columns: new[] { "MetodoPagoId", "TipoMetodo" },
                values: new object[,]
                {
                    { new Guid("1beb2875-4b57-404c-ac78-2fbe1762b133"), "PayPal" },
                    { new Guid("25a03479-ebb3-4f75-a368-622ec0cd9373"), "American Express" },
                    { new Guid("2921ae1b-171b-4d4f-b940-381fc2c0be42"), "efectivo" },
                    { new Guid("32392a6f-2570-49fa-8fc9-798b322920ce"), "MasterCard" },
                    { new Guid("7484104a-48a6-4f27-8041-ffeab27e2537"), "Visa" }
                });

            migrationBuilder.InsertData(
                table: "ProductoProveedor",
                columns: new[] { "ProductoProveedorId", "Preciocompra", "Preciounitario" },
                values: new object[,]
                {
                    { new Guid("004002aa-27df-4e19-b289-f3dec6811a54"), 85.25m, 58.63m },
                    { new Guid("0407737c-29f7-4796-b448-c68d03c9afcf"), 560.76m, 622.70m },
                    { new Guid("0a1ee0b0-a04e-4569-876f-4a9eb5735ce6"), 704.94m, 191.89m },
                    { new Guid("0f235ff2-1bd4-4bdd-b1e8-d3b631a17973"), 85.60m, 505.69m },
                    { new Guid("10e0254c-b556-4bfd-975b-a446c9ea568d"), 404.15m, 109.66m },
                    { new Guid("14134ee9-de1c-47f3-aadd-a87b555a75d3"), 340.89m, 596.20m },
                    { new Guid("19b60b72-fe13-484a-8b74-c8705bbc0715"), 742.93m, 432.40m },
                    { new Guid("207b7bb4-f927-4d36-ade8-93068e03df29"), 428.79m, 13.71m },
                    { new Guid("21b45a50-b7d4-40f8-94de-b320573bb411"), 366.63m, 818.58m },
                    { new Guid("2ad295ac-4ddc-425b-9c41-42fc4fe6337a"), 797.58m, 21.14m },
                    { new Guid("345ffa63-c6bd-4ee2-aec0-15a483bddac1"), 453.07m, 995.95m },
                    { new Guid("37bb82e7-1619-46fe-9998-095915812a38"), 730.35m, 669.02m },
                    { new Guid("39b689f3-b1c7-4b61-a44a-b35db4dc7deb"), 891.77m, 694.99m },
                    { new Guid("3c5f0b8d-5883-47ae-8c20-af3d5b9ffa98"), 279.57m, 301.70m },
                    { new Guid("3d9aa8dc-52ed-45ce-a5ee-a3617c706d2d"), 172.79m, 678.52m },
                    { new Guid("427f5a12-67f6-4fb1-8869-accb0b923ed2"), 512.32m, 248.05m },
                    { new Guid("4dbc7fec-d030-4166-9198-3769166e17b1"), 173.01m, 438.30m },
                    { new Guid("55e8890e-b98b-4bc5-91dd-46ee4c4b9253"), 332.11m, 63.68m },
                    { new Guid("59759d0f-c3e1-4330-a181-45ff732e68ee"), 689.70m, 158.11m },
                    { new Guid("5aa59da5-e773-4da4-a568-544d80d54bfa"), 463.67m, 44.39m },
                    { new Guid("5fc86587-cb5b-4162-b97f-26021ecb7050"), 455.19m, 896.63m },
                    { new Guid("6158a637-265b-43bd-8474-ebdb22b762be"), 556.21m, 105.42m },
                    { new Guid("64714694-60de-4409-b19b-015514e28d65"), 338.34m, 924.92m },
                    { new Guid("7aa86c77-ab4b-4a0d-b2e4-52d220077b26"), 490.52m, 806.29m },
                    { new Guid("7ea68be5-0120-40bd-81fb-d8e82ac03f77"), 684.40m, 711.21m },
                    { new Guid("879b4802-82f8-4172-8b9f-258c894a84f9"), 414.97m, 184.21m },
                    { new Guid("8a62c2e0-bbe7-4ff2-ae9e-4c4d4f393128"), 873.64m, 954.62m },
                    { new Guid("925801d0-db20-4bc3-8511-8df8e1daf4bc"), 612.74m, 241.42m },
                    { new Guid("9d677ca9-ceb6-44cf-acd5-6898c5142a49"), 5.20m, 596.81m },
                    { new Guid("9d9d06de-9ef3-464b-8ddb-ef6d16e84a73"), 905.44m, 601.90m },
                    { new Guid("9f28d6cb-b9dd-4546-9ab6-4a9e1d280711"), 869.63m, 418.59m },
                    { new Guid("a061e04d-9b78-4b3a-933f-73168b8de749"), 825.00m, 614.14m },
                    { new Guid("aba5e142-31fb-480b-91b4-bacfdcf1d0f0"), 89.43m, 393.19m },
                    { new Guid("ac279da4-99c6-44ac-b166-bb890bf4c232"), 397.27m, 430.49m },
                    { new Guid("ace59ed3-9698-4976-8f0e-39ede4d506ee"), 349.75m, 487.41m },
                    { new Guid("b0695150-fd12-43ce-959d-e758558c1ae0"), 73.70m, 151.12m },
                    { new Guid("c0db53c1-ff98-4196-b71a-83172245d642"), 697.77m, 941.53m },
                    { new Guid("c675dafe-01c6-494b-a9ea-df7ba4170e27"), 912.97m, 913.49m },
                    { new Guid("c7a2c489-e0c8-4795-a01e-46a7a7bd7f2b"), 619.96m, 713.93m },
                    { new Guid("cbc22ef3-4c5f-497c-ab3c-9e59b566cea5"), 801.99m, 530.99m },
                    { new Guid("cbd2f97e-d5e2-402d-bd0b-7009fe18ff2e"), 34.74m, 200.40m },
                    { new Guid("d476a1b4-57a8-4900-b4fb-8ef5647ef4ef"), 662.37m, 757.31m },
                    { new Guid("db2a45b5-8d51-49c4-b073-33cab12d357a"), 208.05m, 951.26m },
                    { new Guid("e308ad4d-7021-4db8-832c-b2ff002239c1"), 404.45m, 117.66m },
                    { new Guid("e73b17b4-bd39-4b10-809b-61c62f82dc17"), 818.31m, 687.06m },
                    { new Guid("e9919ed8-3721-446a-81c6-3ff7ebf5781e"), 879.51m, 649.01m },
                    { new Guid("f09b2bfe-dbe6-4592-a0ce-5ba497b8b73c"), 551.45m, 865.16m },
                    { new Guid("f34e94b7-613c-4285-9b40-9df0c59bfaf4"), 8.81m, 91.52m },
                    { new Guid("fd6a4c67-0ca3-40a0-9942-a03fd3f95246"), 196.84m, 123.01m },
                    { new Guid("fd9e7054-45f9-449d-bbe9-8165af8fd62d"), 209.92m, 31.65m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
