namespace Projekt_Komunikacja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdresModels",
                c => new
                    {
                        Adres_ID = c.Int(nullable: false, identity: true),
                        KodPocztowy = c.String(),
                        Ulica = c.String(),
                        Lat = c.Single(nullable: false),
                        Long = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Adres_ID);
            
            CreateTable(
                "dbo.KontaktModels",
                c => new
                    {
                        Kontakt_ID = c.Int(nullable: false, identity: true),
                        NrTelefonu = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Kontakt_ID);
            
            CreateTable(
                "dbo.PlacesModels",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        JestPrzystosowane = c.Boolean(nullable: false),
                        Adres_ID_Adres_ID = c.Int(nullable: false),
                        Kontakt_ID_Kontakt_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlaceID)
                .ForeignKey("dbo.AdresModels", t => t.Adres_ID_Adres_ID, cascadeDelete: true)
                .ForeignKey("dbo.KontaktModels", t => t.Kontakt_ID_Kontakt_ID, cascadeDelete: true)
                .Index(t => t.Adres_ID_Adres_ID)
                .Index(t => t.Kontakt_ID_Kontakt_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlacesModels", "Kontakt_ID_Kontakt_ID", "dbo.KontaktModels");
            DropForeignKey("dbo.PlacesModels", "Adres_ID_Adres_ID", "dbo.AdresModels");
            DropIndex("dbo.PlacesModels", new[] { "Kontakt_ID_Kontakt_ID" });
            DropIndex("dbo.PlacesModels", new[] { "Adres_ID_Adres_ID" });
            DropTable("dbo.PlacesModels");
            DropTable("dbo.KontaktModels");
            DropTable("dbo.AdresModels");
        }
    }
}
