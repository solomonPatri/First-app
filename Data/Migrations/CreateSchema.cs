using FluentMigrator;

namespace first_app.Data.Migrations
{

    [Migration(110202023)]

    public class CreateSchema:Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {

            Create.Table("users")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("username").AsString(130).NotNullable()
                .WithColumn("password").AsString(130).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Height").AsDouble().NotNullable()
                .WithColumn("Country").AsString(130).NotNullable()
                .WithColumn("Job").AsString(130).NotNullable();


         }






    }
}
