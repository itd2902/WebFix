namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_filed_gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER", "Gender", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.USER", "Gender");
        }
    }
}
