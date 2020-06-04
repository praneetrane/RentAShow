namespace RentAShow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Name) Values('Comedy')");
            Sql("insert into Genres(Name) Values('Action')");
            Sql("insert into Genres(Name) Values('Family')");
            Sql("insert into Genres(Name) Values('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
