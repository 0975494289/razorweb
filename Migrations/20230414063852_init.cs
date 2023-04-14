using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bogus;
using entity.models;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            //Insert data (có thể sử dụng vòng lặp để add cho nhanh)
            // migrationBuilder.InsertData(
            //     table: "articles",
            //     columns: new [] {"Title","Created","Content"},
            //     values: new object[]{"Bai viet 1",new DateTime(2021,8,20),"Noi dung bai viet 1"}
            // );
            // migrationBuilder.InsertData(
            //     table: "articles",
            //     columns: new [] {"Title","Created","Content"},
            //     values: new object[]{"Bai viet 2",new DateTime(2021,9,20),"Noi dung bai viet 2"}
            // );

            //Tự động tạo ra dữ liệu fake bằng Bogus (cài đặt trên nuget)
            Randomizer.Seed = new Random(8675309);
            var fakerArticle = new Faker<Article>();
            fakerArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(5, 5)); //Phát sinh ra các Title là câu văn có độ dài là 5 từ và +- 5 từ
            fakerArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2021, 7, 30))); //Phát sinh ra ngày tạo trong khoảng thời gian từ 01/01/2021 đến 01/01/2022;
            fakerArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 3)); //Phát sinh ra nội dung bao gồm các đoạn văn từ 1 đến 3 đoạn.

            for (int i = 1; i <= 150; i++) //Tạo ra 150 bài viết
            {
                Article article = fakerArticle.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new[] { "Title", "Created", "Content" },
                    values: new object[] { article.Title, article.Created, article.Content }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
