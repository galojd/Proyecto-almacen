using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class Integrarseeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "NombreCategoria" },
                values: new object[,]
                {
                    { new Guid("654c4ca9-57ad-47e1-bd56-019144664a1d"), "Memoria RAM" },
                    { new Guid("7e0d270c-8356-4725-838a-8d16fd9ce811"), "Placa madre" },
                    { new Guid("856e2097-4112-44c1-b34f-a5c499e60961"), "Disco duro SSD" },
                    { new Guid("aa2b875c-822d-4a54-a2fc-3daf1798c499"), "Fuente de alimentación" },
                    { new Guid("e3d666f0-db18-4931-8a61-c67a1e31a0b3"), "Tarjeta gráfica" },
                    { new Guid("fa59a80d-0627-42cd-a003-cf2287662f59"), "Procesador" }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "DNI", "Direccion", "Email", "Fecharegistro", "Nombres", "RUC", "Telefono" },
                values: new object[,]
                {
                    { new Guid("00a56b0c-f2cc-431f-8a12-5ab2a505e722"), "39634982", "Calle C, 32, Cusco", "contacto634@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5606), "Juan Juan", "20428729201", "716245202" },
                    { new Guid("02b4df43-2bb8-4104-a627-3fb52e87e70b"), "57613926", "Calle D, 52, Piura", "usuario848@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5804), "Lucía Pedro", "20428729201", "665797752" },
                    { new Guid("04615b61-05b1-4aa7-b111-afcf51a7119f"), "78217464", "Calle E, 1, Lima", "cliente766@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5918), "Lucía Juan", "20428729201", "292230750" },
                    { new Guid("0490a791-100e-47e2-90c9-1191514cc7d3"), "72967426", "Calle A, 15, Arequipa", "usuario539@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5905), "Sofía María", "20428729201", "943234892" },
                    { new Guid("04eacc27-39ad-41c9-8b6e-457000f6e661"), "36240549", "Calle E, 98, Lima", "comprador381@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5719), "Pedro Pedro", "20428729201", "276900746" },
                    { new Guid("0c73f76f-0c29-4d18-8a7e-218473ac4209"), "82895064", "Calle B, 82, Piura", "comprador192@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5671), "Diego Sofía", "20428729201", "585828330" },
                    { new Guid("143c088a-19c7-4406-8560-df39e522f186"), "69199362", "Calle E, 79, Lima", "comprador616@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5439), "Ana Pedro", "20428729201", "546691678" },
                    { new Guid("179b8a6c-5de3-4f71-93c9-e36d3c05240d"), "52199599", "Calle D, 50, Trujillo", "comprador620@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5889), "Sofía Laura", "20428729201", "374422351" },
                    { new Guid("231bcf78-2646-4eb5-97e4-68a48399ec9e"), "40210063", "Calle B, 64, Cusco", "correo148@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5478), "Sofía Diego", "20428729201", "153043378" },
                    { new Guid("251a0e18-1b64-49af-b2e2-4f5c219ea2a3"), "91179238", "Calle B, 61, Lima", "cliente245@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5648), "María Juan", "20428729201", "199766094" },
                    { new Guid("282bdc0b-bfe4-4dff-9407-c749e0a32a83"), "91204294", "Calle D, 69, Lima", "cliente614@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5883), "Pedro Ana", "20428729201", "987959466" },
                    { new Guid("2f23674e-0f64-47a2-893d-e7cb233427fb"), "28698796", "Calle E, 75, Cusco", "contacto201@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5678), "Sofía Lucía", "20428729201", "395733856" },
                    { new Guid("326298d7-2306-429d-8a00-bcd138ba01fd"), "85408612", "Calle D, 68, Cusco", "comprador295@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5704), "Ana Laura", "20428729201", "659675344" },
                    { new Guid("34bf30d2-3b1b-4236-93aa-8a7f43523bbf"), "62754907", "Calle C, 87, Lima", "cliente524@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5757), "Diego Lucía", "20428729201", "576227467" },
                    { new Guid("3dae94bd-d46d-45a7-be16-46d4c3e85a68"), "44023696", "Calle C, 5, Arequipa", "usuario459@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5811), "Carlos Ana", "20428729201", "757073609" },
                    { new Guid("3f67f3c8-be73-4e70-a15a-0f0d989b6daa"), "92834102", "Calle D, 81, Trujillo", "comprador48@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5750), "María Lucía", "20428729201", "226958895" },
                    { new Guid("47c0181f-6e0b-4133-881a-a6f31552d11c"), "71375110", "Calle E, 56, Lima", "cliente477@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5655), "Sofía Ana", "20428729201", "686988363" },
                    { new Guid("4f1620f2-4495-436c-98b6-60741fd60686"), "71424380", "Calle E, 74, Cusco", "contacto727@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5556), "Ana Diego", "20428729201", "802401673" },
                    { new Guid("53d37697-05f9-4a07-aa2b-de8b2e4adc8a"), "95545898", "Calle E, 61, Cusco", "contacto373@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5691), "Juan Lucía", "20428729201", "384662504" },
                    { new Guid("548cac2f-b7fa-4470-b0a3-92d1d5bac64a"), "78325890", "Calle A, 48, Cusco", "cliente957@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5593), "Laura María", "20428729201", "166929531" },
                    { new Guid("57fdb539-a698-4f39-a587-28a0f0528ad1"), "99386184", "Calle A, 3, Cusco", "usuario184@gmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5550), "Ana Pedro", "20428729201", "522882105" },
                    { new Guid("58e8f5b8-7f3a-4a0f-999d-63297b203270"), "41842164", "Calle E, 73, Trujillo", "correo955@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5535), "María María", "20428729201", "908579655" },
                    { new Guid("592541f6-66fb-4dbd-8052-d8ec202e9599"), "28863153", "Calle A, 57, Cusco", "comprador129@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5463), "Pedro Lucía", "20428729201", "600452551" },
                    { new Guid("6949bd44-dcd0-4868-8797-6738ce5a8aef"), "67859551", "Calle E, 63, Cusco", "usuario471@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5664), "Laura Carlos", "20428729201", "924375810" },
                    { new Guid("6a1c2d0b-8e95-43b8-b5a8-2c9a7042fc59"), "62229502", "Calle A, 74, Cusco", "cliente140@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5570), "María María", "20428729201", "428856182" },
                    { new Guid("6c91801c-ea26-45cd-8b08-592dd9ba4c20"), "76840088", "Calle A, 76, Lima", "correo521@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5783), "Lucía Ana", "20428729201", "872079958" },
                    { new Guid("6d34b708-2464-4f47-a7a0-749ce977d251"), "69768177", "Calle B, 63, Trujillo", "correo518@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5770), "Luis Luis", "20428729201", "463655339" },
                    { new Guid("6d3bd710-da8e-4789-862b-964144eab326"), "36956740", "Calle E, 42, Lima", "usuario257@gmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5599), "Laura Ana", "20428729201", "568955331" },
                    { new Guid("7fbf2af5-4fa4-4971-8039-d27a5c998140"), "69554673", "Calle B, 50, Cusco", "comprador309@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5777), "Ana Luis", "20428729201", "826521602" },
                    { new Guid("83625041-3d72-4257-9020-043b77a6e152"), "31620370", "Calle D, 70, Piura", "correo361@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5471), "Lucía Ana", "20428729201", "401348121" },
                    { new Guid("83a25cf5-7f60-4a89-bb78-70ebd411faaa"), "77626681", "Calle C, 92, Trujillo", "comprador221@gmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5612), "María Diego", "20428729201", "629682586" },
                    { new Guid("85aa8cca-5626-42fd-8578-b7f878980f5d"), "35118427", "Calle E, 15, Cusco", "correo983@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5579), "Lucía Laura", "20428729201", "517216437" },
                    { new Guid("863d2e77-544e-4cd9-85bb-16bf721afc72"), "54035101", "Calle C, 96, Arequipa", "comprador187@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5543), "Laura Lucía", "20428729201", "622906551" },
                    { new Guid("899f92f3-c569-497b-9a07-ce5b043df558"), "19768757", "Calle C, 65, Trujillo", "comprador504@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5710), "Juan Laura", "20428729201", "256264319" },
                    { new Guid("8c227e71-dcbc-43da-b68e-8b3b05f12beb"), "25733633", "Calle C, 61, Trujillo", "cliente464@hotmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5818), "Lucía Juan", "20428729201", "258484895" },
                    { new Guid("9095b3be-bf48-4734-aada-08c95dbacf62"), "32161809", "Calle A, 92, Cusco", "comprador908@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5896), "Sofía Carlos", "20428729201", "264227608" },
                    { new Guid("942d1060-b603-4c96-937a-f5cdcca09422"), "19622813", "Calle B, 99, Piura", "comprador930@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5911), "Diego Pedro", "20428729201", "612536189" },
                    { new Guid("95824d62-1390-40eb-bcd0-05af6ddab3de"), "10791289", "Calle C, 56, Arequipa", "usuario936@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5456), "Lucía Sofía", "20428729201", "204031731" },
                    { new Guid("a3a16956-ab86-468a-acc1-4968a641a114"), "20954878", "Calle E, 74, Lima", "comprador524@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5875), "Luis Luis", "20428729201", "317620155" },
                    { new Guid("a53ecaf3-44f1-4b63-9592-b438ebac2f3e"), "26749173", "Calle A, 55, Arequipa", "contacto490@gmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5798), "Luis Sofía", "20428729201", "707669779" },
                    { new Guid("b5a4cd48-cef0-4542-954a-ce84c6ce2bb6"), "32898000", "Calle E, 9, Arequipa", "contacto496@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5764), "Diego Juan", "20428729201", "403006184" },
                    { new Guid("be9bac9c-ec5e-4d6c-9e2a-8b4d65180fbf"), "50064378", "Calle E, 7, Trujillo", "usuario513@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5447), "Pedro Luis", "20428729201", "591640556" },
                    { new Guid("bf469706-301e-4e74-9996-3ee8dd44c4cf"), "39572818", "Calle E, 46, Cusco", "cliente583@gmail.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5789), "Carlos Sofía", "20428729201", "706581209" },
                    { new Guid("c281b853-1920-4150-b51d-225e1b0e17e6"), "44364498", "Calle C, 74, Lima", "contacto554@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5684), "María Luis", "20428729201", "748908798" },
                    { new Guid("d205a35b-7f0b-4eb4-b726-12ec7cbb7240"), "57007629", "Calle E, 18, Arequipa", "comprador60@outlook.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5586), "Lucía Carlos", "20428729201", "737971538" },
                    { new Guid("d8b183a0-9cf0-4c0c-8432-d606eaeeccb9"), "89067623", "Calle B, 12, Cusco", "contacto21@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5697), "Juan María", "20428729201", "204351475" },
                    { new Guid("dacc4543-f3cc-48b7-871a-1f424e7e9a17"), "94764976", "Calle A, 8, Piura", "contacto614@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5489), "Carlos Juan", "20428729201", "767190077" },
                    { new Guid("e374f4e0-f6f6-429e-bb67-4daf4e7093e6"), "38457314", "Calle C, 55, Piura", "usuario229@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5429), "Sofía Carlos", "20428729201", "781818429" },
                    { new Guid("f3b2d9d7-c142-4c66-a735-b6db66eece8e"), "26815696", "Calle E, 92, Piura", "comprador5@example.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5563), "María Laura", "20428729201", "247452158" },
                    { new Guid("f46d3220-59f1-45ec-a2de-1482a6e55290"), "90848440", "Calle C, 21, Arequipa", "contacto357@yahoo.com", new DateTime(2024, 6, 3, 4, 48, 34, 640, DateTimeKind.Utc).AddTicks(5495), "Ana Diego", "20428729201", "803750689" }
                });

            migrationBuilder.InsertData(
                table: "MetodoPago",
                columns: new[] { "MetodoPagoId", "TipoMetodo" },
                values: new object[,]
                {
                    { new Guid("03f6aca8-0b76-4d58-93ff-e0ffab433736"), "Visa" },
                    { new Guid("2e6054e2-0bd5-40b6-9b34-d00ea32b2238"), "efectivo" },
                    { new Guid("4b6883ec-bf81-43eb-9d4f-b91ce2d0fc10"), "PayPal" },
                    { new Guid("9e1e5daf-28d2-4ce7-b90d-80c1e8f3dabc"), "American Express" },
                    { new Guid("a68cea38-f847-4d1c-b765-bf5592fdd467"), "MasterCard" }
                });

            migrationBuilder.InsertData(
                table: "ProductoProveedor",
                columns: new[] { "ProductoProveedorId", "Preciocompra", "Preciounitario" },
                values: new object[,]
                {
                    { new Guid("024bb457-7af1-4a53-9c50-1ef1ea3529d3"), 111.04m, 547.65m },
                    { new Guid("07553da9-babf-48d7-b84d-9e8602a27f8b"), 791.54m, 917.45m },
                    { new Guid("0dca7743-361c-4cbf-9863-0a77717c0990"), 922.23m, 344.70m },
                    { new Guid("141d47e1-9207-4040-9f8f-85c0fbb2d9e6"), 398.77m, 42.77m },
                    { new Guid("1aed321e-30d3-4a0b-8d1c-795246bc87a4"), 554.32m, 328.81m },
                    { new Guid("30f2f5a3-c6bf-414e-9f5c-54b5638cd3ce"), 967.21m, 958.55m },
                    { new Guid("32340c46-290f-4a52-adfe-c1f902bd148c"), 996.91m, 417.41m },
                    { new Guid("34a8ce98-0f6c-4b8f-a991-cd8a85493463"), 124.38m, 347.85m },
                    { new Guid("372c38c7-9046-4354-83f0-0c557ec17031"), 425.98m, 730.94m },
                    { new Guid("375527b6-f607-4377-a391-9fd6bd7f5aff"), 16.04m, 506.03m },
                    { new Guid("375e0007-75ba-4e00-9ec4-03612f499d27"), 598.51m, 478.51m },
                    { new Guid("386bbba1-866e-40ff-8908-f77f88a51e09"), 605.18m, 763.18m },
                    { new Guid("44eddea2-517e-4ebe-a1fe-3c8f2e349062"), 440.49m, 941.00m },
                    { new Guid("4ec67425-aa27-499b-bf90-37eba0f9cca1"), 687.40m, 66.79m },
                    { new Guid("520091ad-cc78-451b-9db1-2b8da38f1458"), 68.76m, 961.37m },
                    { new Guid("556adf7d-4f04-462a-adf0-b29ff85b2de8"), 980.55m, 130.25m },
                    { new Guid("5967022e-b982-47d2-9bdd-0567f460c42d"), 305.17m, 196.03m },
                    { new Guid("5d78105e-7d98-4bee-9f76-c2cf20c95197"), 23.13m, 144.73m },
                    { new Guid("5ec8a7ba-8b88-4140-8439-57502b8ad8a3"), 107.07m, 122.67m },
                    { new Guid("5f3760a0-1564-45ec-914e-ebf0f33729ad"), 346.23m, 367.62m },
                    { new Guid("6253f395-ee15-4c50-8764-d2b447f064c4"), 955.66m, 264.02m },
                    { new Guid("642f52bc-4baf-4593-92b5-ee3dbeabbf55"), 940.43m, 814.60m },
                    { new Guid("664215bf-c65d-4b27-96b0-ebd263893d2a"), 588.19m, 849.11m },
                    { new Guid("711c711d-f31b-4920-87bb-d739d796bbce"), 717.00m, 432.89m },
                    { new Guid("73bb254f-4ecc-41c0-89b0-ed7fdb96dc4b"), 495.50m, 7.56m },
                    { new Guid("73e9bdda-c8c8-4060-a7a5-9324fde3b9cc"), 382.93m, 654.44m },
                    { new Guid("75cc3b2e-2fec-4d66-8819-baeae06808ed"), 387.88m, 615.75m },
                    { new Guid("7918e625-9510-4985-a983-f028d6d65ec3"), 607.17m, 568.08m },
                    { new Guid("7951ddc3-8235-400d-81a3-3d5775a9fb40"), 615.31m, 836.80m },
                    { new Guid("83f97613-cdea-4d56-8fcf-49ffa107dca4"), 825.97m, 949.99m },
                    { new Guid("8455a439-d9e0-4b99-a7f3-10cb5d5148d4"), 324.92m, 774.75m },
                    { new Guid("856c3d2d-41d5-4f4d-8317-f8b96b258dbe"), 456.15m, 91.87m },
                    { new Guid("89b66a0f-75c0-4ca4-aa84-ee1b053883dd"), 613.38m, 437.64m },
                    { new Guid("8a6266a7-ea93-40ad-b6f8-0ca7cd07f9ae"), 623.34m, 253.62m },
                    { new Guid("8acc635c-012a-444e-9de3-4fe45159b214"), 973.71m, 659.58m },
                    { new Guid("91fa5b14-059a-4d34-ae92-a070a24b3b0a"), 858.56m, 45.09m },
                    { new Guid("94b24a98-3ada-4d18-ae04-a5188e18cb25"), 717.04m, 267.60m },
                    { new Guid("94c8f18d-9815-43c6-9af7-793dd07f3054"), 553.17m, 413.93m },
                    { new Guid("96c2534c-202e-4f60-b1fc-4f4f1a12367d"), 174.19m, 307.45m },
                    { new Guid("aa15101a-c1d1-4203-aff4-3f4221a0a1ec"), 501.04m, 486.52m },
                    { new Guid("ab4fb55a-ce51-40bf-95f1-c7335fe87c13"), 655.96m, 434.49m },
                    { new Guid("b3c3c2b5-203f-43e7-82bc-f079f03ac44c"), 1.72m, 703.59m },
                    { new Guid("c0e4f0ff-f17f-469a-b436-c70061d322e7"), 883.41m, 739.25m },
                    { new Guid("cac06979-4069-4be1-ae10-ae897d553f36"), 274.44m, 501.33m },
                    { new Guid("ccb0613d-95cb-4c7a-b6fa-44be740bdc53"), 105.54m, 764.30m },
                    { new Guid("d825eed0-b045-4424-916a-54a28373fee6"), 123.82m, 540.73m },
                    { new Guid("ddbeac85-647d-4c10-a0b5-46bef75c8f97"), 785.89m, 532.82m },
                    { new Guid("ea8629b5-1cec-4397-9617-9279098bb153"), 225.54m, 487.81m },
                    { new Guid("efda06fc-4044-4bb6-95ab-1c550ae84cbf"), 349.03m, 462.95m },
                    { new Guid("f646ff11-1789-44b7-ac2b-8f60f78af63b"), 257.50m, 329.72m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("654c4ca9-57ad-47e1-bd56-019144664a1d"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("7e0d270c-8356-4725-838a-8d16fd9ce811"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("856e2097-4112-44c1-b34f-a5c499e60961"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("aa2b875c-822d-4a54-a2fc-3daf1798c499"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e3d666f0-db18-4931-8a61-c67a1e31a0b3"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("fa59a80d-0627-42cd-a003-cf2287662f59"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("00a56b0c-f2cc-431f-8a12-5ab2a505e722"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("02b4df43-2bb8-4104-a627-3fb52e87e70b"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("04615b61-05b1-4aa7-b111-afcf51a7119f"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("0490a791-100e-47e2-90c9-1191514cc7d3"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("04eacc27-39ad-41c9-8b6e-457000f6e661"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("0c73f76f-0c29-4d18-8a7e-218473ac4209"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("143c088a-19c7-4406-8560-df39e522f186"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("179b8a6c-5de3-4f71-93c9-e36d3c05240d"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("231bcf78-2646-4eb5-97e4-68a48399ec9e"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("251a0e18-1b64-49af-b2e2-4f5c219ea2a3"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("282bdc0b-bfe4-4dff-9407-c749e0a32a83"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("2f23674e-0f64-47a2-893d-e7cb233427fb"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("326298d7-2306-429d-8a00-bcd138ba01fd"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("34bf30d2-3b1b-4236-93aa-8a7f43523bbf"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("3dae94bd-d46d-45a7-be16-46d4c3e85a68"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("3f67f3c8-be73-4e70-a15a-0f0d989b6daa"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("47c0181f-6e0b-4133-881a-a6f31552d11c"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("4f1620f2-4495-436c-98b6-60741fd60686"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("53d37697-05f9-4a07-aa2b-de8b2e4adc8a"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("548cac2f-b7fa-4470-b0a3-92d1d5bac64a"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("57fdb539-a698-4f39-a587-28a0f0528ad1"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("58e8f5b8-7f3a-4a0f-999d-63297b203270"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("592541f6-66fb-4dbd-8052-d8ec202e9599"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("6949bd44-dcd0-4868-8797-6738ce5a8aef"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("6a1c2d0b-8e95-43b8-b5a8-2c9a7042fc59"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("6c91801c-ea26-45cd-8b08-592dd9ba4c20"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("6d34b708-2464-4f47-a7a0-749ce977d251"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("6d3bd710-da8e-4789-862b-964144eab326"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("7fbf2af5-4fa4-4971-8039-d27a5c998140"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("83625041-3d72-4257-9020-043b77a6e152"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("83a25cf5-7f60-4a89-bb78-70ebd411faaa"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("85aa8cca-5626-42fd-8578-b7f878980f5d"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("863d2e77-544e-4cd9-85bb-16bf721afc72"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("899f92f3-c569-497b-9a07-ce5b043df558"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("8c227e71-dcbc-43da-b68e-8b3b05f12beb"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("9095b3be-bf48-4734-aada-08c95dbacf62"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("942d1060-b603-4c96-937a-f5cdcca09422"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("95824d62-1390-40eb-bcd0-05af6ddab3de"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("a3a16956-ab86-468a-acc1-4968a641a114"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("a53ecaf3-44f1-4b63-9592-b438ebac2f3e"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("b5a4cd48-cef0-4542-954a-ce84c6ce2bb6"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("be9bac9c-ec5e-4d6c-9e2a-8b4d65180fbf"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("bf469706-301e-4e74-9996-3ee8dd44c4cf"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("c281b853-1920-4150-b51d-225e1b0e17e6"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("d205a35b-7f0b-4eb4-b726-12ec7cbb7240"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("d8b183a0-9cf0-4c0c-8432-d606eaeeccb9"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("dacc4543-f3cc-48b7-871a-1f424e7e9a17"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("e374f4e0-f6f6-429e-bb67-4daf4e7093e6"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("f3b2d9d7-c142-4c66-a735-b6db66eece8e"));

            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "ClienteId",
                keyValue: new Guid("f46d3220-59f1-45ec-a2de-1482a6e55290"));

            migrationBuilder.DeleteData(
                table: "MetodoPago",
                keyColumn: "MetodoPagoId",
                keyValue: new Guid("03f6aca8-0b76-4d58-93ff-e0ffab433736"));

            migrationBuilder.DeleteData(
                table: "MetodoPago",
                keyColumn: "MetodoPagoId",
                keyValue: new Guid("2e6054e2-0bd5-40b6-9b34-d00ea32b2238"));

            migrationBuilder.DeleteData(
                table: "MetodoPago",
                keyColumn: "MetodoPagoId",
                keyValue: new Guid("4b6883ec-bf81-43eb-9d4f-b91ce2d0fc10"));

            migrationBuilder.DeleteData(
                table: "MetodoPago",
                keyColumn: "MetodoPagoId",
                keyValue: new Guid("9e1e5daf-28d2-4ce7-b90d-80c1e8f3dabc"));

            migrationBuilder.DeleteData(
                table: "MetodoPago",
                keyColumn: "MetodoPagoId",
                keyValue: new Guid("a68cea38-f847-4d1c-b765-bf5592fdd467"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("024bb457-7af1-4a53-9c50-1ef1ea3529d3"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("07553da9-babf-48d7-b84d-9e8602a27f8b"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("0dca7743-361c-4cbf-9863-0a77717c0990"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("141d47e1-9207-4040-9f8f-85c0fbb2d9e6"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("1aed321e-30d3-4a0b-8d1c-795246bc87a4"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("30f2f5a3-c6bf-414e-9f5c-54b5638cd3ce"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("32340c46-290f-4a52-adfe-c1f902bd148c"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("34a8ce98-0f6c-4b8f-a991-cd8a85493463"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("372c38c7-9046-4354-83f0-0c557ec17031"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("375527b6-f607-4377-a391-9fd6bd7f5aff"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("375e0007-75ba-4e00-9ec4-03612f499d27"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("386bbba1-866e-40ff-8908-f77f88a51e09"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("44eddea2-517e-4ebe-a1fe-3c8f2e349062"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("4ec67425-aa27-499b-bf90-37eba0f9cca1"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("520091ad-cc78-451b-9db1-2b8da38f1458"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("556adf7d-4f04-462a-adf0-b29ff85b2de8"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("5967022e-b982-47d2-9bdd-0567f460c42d"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("5d78105e-7d98-4bee-9f76-c2cf20c95197"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("5ec8a7ba-8b88-4140-8439-57502b8ad8a3"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("5f3760a0-1564-45ec-914e-ebf0f33729ad"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("6253f395-ee15-4c50-8764-d2b447f064c4"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("642f52bc-4baf-4593-92b5-ee3dbeabbf55"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("664215bf-c65d-4b27-96b0-ebd263893d2a"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("711c711d-f31b-4920-87bb-d739d796bbce"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("73bb254f-4ecc-41c0-89b0-ed7fdb96dc4b"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("73e9bdda-c8c8-4060-a7a5-9324fde3b9cc"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("75cc3b2e-2fec-4d66-8819-baeae06808ed"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("7918e625-9510-4985-a983-f028d6d65ec3"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("7951ddc3-8235-400d-81a3-3d5775a9fb40"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("83f97613-cdea-4d56-8fcf-49ffa107dca4"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("8455a439-d9e0-4b99-a7f3-10cb5d5148d4"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("856c3d2d-41d5-4f4d-8317-f8b96b258dbe"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("89b66a0f-75c0-4ca4-aa84-ee1b053883dd"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("8a6266a7-ea93-40ad-b6f8-0ca7cd07f9ae"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("8acc635c-012a-444e-9de3-4fe45159b214"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("91fa5b14-059a-4d34-ae92-a070a24b3b0a"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("94b24a98-3ada-4d18-ae04-a5188e18cb25"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("94c8f18d-9815-43c6-9af7-793dd07f3054"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("96c2534c-202e-4f60-b1fc-4f4f1a12367d"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("aa15101a-c1d1-4203-aff4-3f4221a0a1ec"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("ab4fb55a-ce51-40bf-95f1-c7335fe87c13"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("b3c3c2b5-203f-43e7-82bc-f079f03ac44c"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("c0e4f0ff-f17f-469a-b436-c70061d322e7"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("cac06979-4069-4be1-ae10-ae897d553f36"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("ccb0613d-95cb-4c7a-b6fa-44be740bdc53"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("d825eed0-b045-4424-916a-54a28373fee6"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("ddbeac85-647d-4c10-a0b5-46bef75c8f97"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("ea8629b5-1cec-4397-9617-9279098bb153"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("efda06fc-4044-4bb6-95ab-1c550ae84cbf"));

            migrationBuilder.DeleteData(
                table: "ProductoProveedor",
                keyColumn: "ProductoProveedorId",
                keyValue: new Guid("f646ff11-1789-44b7-ac2b-8f60f78af63b"));
        }
    }
}
