using Microsoft.EntityFrameworkCore.Migrations;

namespace Buildlease.Migrations
{
    public partial class EmailValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER UserEmailValidation
                    ON Users
                    INSTEAD OF INSERT 
                AS
                    IF EXISTS(SELECT * FROM INSERTED WHERE Id NOT LIKE '%_@__%.__%')
                        THROW 50001, 'Id is not valid email', 1;

                    INSERT INTO Users
                    SELECT *
                    FROM INSERTED;
                ;
            ");
        }
    }
}
