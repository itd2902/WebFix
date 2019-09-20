namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateimagecategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CATEGORY", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CATEGORY", "Image");
        }
    }
}
