﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buildlease.Migrations
{
    public partial class ExceptionLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerializedException = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.Id);
                });

            migrationBuilder.Sql(@"
                CREATE TRIGGER ExceptionLogAutogeneratedId
                    ON ExceptionLog
                    INSTEAD OF INSERT 
                AS
                    DECLARE @WithoutId TABLE (
                        Id int,
                        DateTime datetime2,
                        Message nvarchar(max), 
                        StackTrace nvarchar(max),
                        SerializedException nvarchar(max)
                    );

                    INSERT INTO @WithoutId
                    SELECT *
                    FROM INSERTED;

                    DECLARE @NextId INT = (
                        SELECT IIF(MAX(Id) IS NOT NULL, MAX(Id), 0) + 1
                        FROM ExceptionLog
                    );

                    WHILE EXISTS(SELECT * FROM @WithoutId)
                    BEGIN
                        INSERT INTO ExceptionLog
                        SELECT TOP(1) 
                            @NextId, DateTime, Message, StackTrace, SerializedException
                        FROM @WithoutId;

                        DELETE TOP(1)
                        FROM @WithoutId;

                        SET @NextId = @NextId + 1;
                    END
                ;
            ");
        }
    }
}