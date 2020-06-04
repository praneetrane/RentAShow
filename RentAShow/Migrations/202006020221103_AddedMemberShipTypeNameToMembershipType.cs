namespace RentAShow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMemberShipTypeNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "MemberShipTypeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "MemberShipTypeName");
        }
    }
}
