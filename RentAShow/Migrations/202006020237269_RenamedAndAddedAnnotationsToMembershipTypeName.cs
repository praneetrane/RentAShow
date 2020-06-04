namespace RentAShow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamedAndAddedAnnotationsToMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.MemberShipTypes", "MemberShipTypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberShipTypes", "MemberShipTypeName", c => c.String());
            DropColumn("dbo.MemberShipTypes", "Name");
        }
    }
}
