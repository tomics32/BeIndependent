namespace Projekt_Komunikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baza : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlacesModels", "Photo", c => c.String(maxLength: 1024));
            AlterColumn("dbo.AdresModels", "Lat", c => c.String());
            AlterColumn("dbo.AdresModels", "Long", c => c.String());
            AlterColumn("dbo.KontaktModels", "NrTelefonu", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KontaktModels", "NrTelefonu", c => c.Int(nullable: false));
            AlterColumn("dbo.AdresModels", "Long", c => c.Single(nullable: false));
            AlterColumn("dbo.AdresModels", "Lat", c => c.Single(nullable: false));
            DropColumn("dbo.PlacesModels", "Photo");
        }
    }
}
