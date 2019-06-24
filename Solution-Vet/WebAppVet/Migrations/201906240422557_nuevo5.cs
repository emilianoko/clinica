namespace WebAppVet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevo5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turns", "servicio", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Turns", "servicio");
        }
    }
}
