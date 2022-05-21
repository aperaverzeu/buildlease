using Microsoft.EntityFrameworkCore.Migrations;

namespace Buildlease.Migrations
{
    public partial class ProductAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create table ProductDescriptionAudit(
                    Id int identity (1, 1) not null,
                    OldProductDescriptionId int,
                    NewProductDescriptionId int,
                    Operation char(10),
                    OldProductId int,
                    NewProductId int,
                    OldLanguageId int,
                    NewLanguageId int,
                    OldDescription nvarchar(max),
                    NewDescription nvarchar(max),
                    IsReverted bit default 0,
                    Timestamp datetime2,
                );
            ");

            migrationBuilder.Sql(@"
                create trigger ProductDescriptionInsertAuditTrigger
                    on ProductDescription
                    after insert
                as begin
                    insert ProductDescriptionAudit
                        (Operation, NewProductDescriptionId, NewProductId, NewLanguageId, NewDescription, Timestamp)
                        select 'insert', Id, ProductId, LanguageId, Description, getdate()
                        from inserted i;
                end;
            ");

            migrationBuilder.Sql(@"
                create trigger ProductDescriptionUpdateAuditTrigger
                    on ProductDescription
                    after update
                as begin
                    insert ProductDescriptionAudit
                        (Operation,
                         OldProductDescriptionId, OldProductId, OldLanguageId, OldDescription,
                         NewProductDescriptionId, NewProductId, NewLanguageId, NewDescription, Timestamp)
                        select 'update',
                                        d.Id, d.ProductId, d.LanguageId, d.Description,
                                        i.Id, i.ProductId, i.LanguageId, i.Description,
                                        getdate()
                        from deleted d, inserted i;
                end;
            ");

            migrationBuilder.Sql(@"
                create trigger ProductDescriptionDeleteAuditTrigger
                    on ProductDescription
                    after delete
                as begin
                    insert ProductDescriptionAudit
                        (Operation, OldProductDescriptionId, OldProductId, OldLanguageId, OldDescription, Timestamp)
                        select 'delete', Id, ProductId, LanguageId, Description, getdate()
                        from deleted d;
                end;
            ");

            migrationBuilder.Sql(@"
                create table ProductAudit(
                    Id int identity (1, 1) not null,
                    Operation char(10),
                    OldProductId int,
                    NewProductId int,
                    OldCategoryId int,
                    NewCategoryId int,
                    OldName nvarchar(max),
                    NewName nvarchar(max),
                    OldImagePath nvarchar(max),
                    NewImagePath nvarchar(max),
                    OldTotalCount int,
                    NewTotalCount int,
                    OldPrice decimal,
                    NewPrice decimal,
                    IsReverted bit default 0,
                    Timestamp datetime2,
                );
            ");

            migrationBuilder.Sql(@"
                create trigger ProductInsertAuditTrigger
                    on Product
                    after insert
                as begin
                    insert ProductAudit
                        (Operation, NewProductId, NewCategoryId, NewName, NewImagePath, NewTotalCount, NewPrice, Timestamp)
                        select 'insert', Id, CategoryId, Name, ImagePath, TotalCount, Price, getdate()
                        from inserted i;
                end;
            ");

            migrationBuilder.Sql(@"
                create trigger ProductUpdateAuditTrigger
                    on Product
                    after update
                as begin
                    insert ProductAudit
                        (Operation, OldProductId, OldCategoryId, OldName, OldImagePath, OldTotalCount, OldPrice,
                                    NewProductId, NewCategoryId, NewName, NewImagePath, NewTotalCount, NewPrice,
                         Timestamp)
                        select 'update',
                               d.Id, d.CategoryId, d.Name, d.ImagePath, d.TotalCount, d.Price,
                               i.Id, i.CategoryId, i.Name, i.ImagePath, i.TotalCount, i.Price,
                               getdate()
                        from deleted d, inserted i;
                end;
            ");

            migrationBuilder.Sql(@"
                create trigger ProductDeleteAuditTrigger
                    on Product
                    after delete
                as begin
                    insert ProductAudit
                        (Operation, OldProductId, OldCategoryId, OldName, OldImagePath, OldTotalCount, OldPrice, Timestamp)
                        select 'delete', Id, CategoryId, Name, ImagePath, TotalCount, Price, getdate()
                        from deleted d;
                end;
            ");

            migrationBuilder.Sql(@"
                create trigger ProductAttributeReindexTrigger
                    on Attribute
                    after insert, delete
                as begin
                    declare @random float;
                    set  @random = (select rand());
                    if (@random < 0.10)
                        DBCC DBREINDEX ('ProductAttribute', IX_ProductAttribute_AttributeId);
                end;
            ");
        }
    }
}
