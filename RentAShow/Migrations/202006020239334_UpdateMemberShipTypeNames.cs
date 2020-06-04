namespace RentAShow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes Set Name='Pay As You Go' Where Id=1");
            Sql("Update MemberShipTypes Set Name='Monthly' Where Id=2");
            Sql("Update MemberShipTypes Set Name='Quarterly' Where Id=3");
            Sql("Update MemberShipTypes Set Name='Annual' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
