using first_app.users;
using FluentMigrator;

namespace first_app.Data.Migrations
{
    [Migration(210202023)]


    public class TestMigrate:Migration
    {
        public override void Up()
        {
            Execute.Script(@"./Data/scripts/data.sql");


        }
        public override void Down()
        {
            throw new NotImplementedException();
        }



    }
}
