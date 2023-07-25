using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDataIntoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var idPredeal = Guid.NewGuid();
            var idBrizei = Guid.NewGuid();
            migrationBuilder.InsertData(
            table: "Offices",
            columns: new[] { "ID", "Name" },
            values: new object[,]
            {
                { idPredeal, "Predeal" },
                { idBrizei, "Brizei" },
            });
            var PredealGF = Guid.NewGuid();
            var PredealFl1 = Guid.NewGuid();
            var PredealFl2 = Guid.NewGuid();
            var BrizeiFl1 = Guid.NewGuid();
            var BrizeiFl2 = Guid.NewGuid();
            migrationBuilder.InsertData(
            table: "Floors",
            columns: new[] { "ID", "Name", "OfficeID" },
            values: new object[,]
            {
                { PredealGF, "Ground Floor", idPredeal },
                { PredealFl1, "Floor 1", idPredeal  },
                { PredealFl2, "Floor 2", idPredeal  },
                { BrizeiFl1, "Floor 1", idBrizei  },
                { BrizeiFl2, "Floor 2", idBrizei },
            });

            migrationBuilder.InsertData(
            table: "Desks",
            columns: new[] { "ID", "Name", "FloorID" },
            values: new object[,]
            {
                { Guid.NewGuid(), "PP1", PredealGF },  // desk ground floor Predeal
                { Guid.NewGuid(), "PP2", PredealGF }, // desk GF Predeal
                { Guid.NewGuid(), "PP3", PredealGF }, // desk GF Predeal
                { Guid.NewGuid(), "PP4", PredealGF }, // desk GF Predeal
                { Guid.NewGuid(), "PP5", PredealGF },// desk GF Predeal
                { Guid.NewGuid(), "PE11", PredealFl1 },// desk Fl1 Predeal
                { Guid.NewGuid(), "PE12", PredealFl1 },// desk Fl1 Predeal
                { Guid.NewGuid(), "PE13", PredealFl1 },// desk Fl1 Predeal
                { Guid.NewGuid(), "PE14", PredealFl1 },// desk Fl1 Predeal
                { Guid.NewGuid(), "PE21", PredealFl2 },// desk Fl2 Predeal
                { Guid.NewGuid(), "PE22", PredealFl2 },// desk Fl2 Predeal
                { Guid.NewGuid(), "PE23", PredealFl2 },// desk Fl2 Predeal
                { Guid.NewGuid(), "PE24", PredealFl2 },// desk Fl2 Predeal
                { Guid.NewGuid(), "BE13", BrizeiFl1 },// desk Fl1 Brizei
                { Guid.NewGuid(), "BE14", BrizeiFl1 },// desk Fl1 Brizei
                { Guid.NewGuid(), "BE21", BrizeiFl2 },// desk Fl2 Brizei
                { Guid.NewGuid(), "BE22", BrizeiFl2 },// desk Fl2 Brizei
                { Guid.NewGuid(), "BE23", BrizeiFl2 },// desk Fl2 Brizei
                { Guid.NewGuid(), "BE24", BrizeiFl2 },// desk Fl2 Brizei
            });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
