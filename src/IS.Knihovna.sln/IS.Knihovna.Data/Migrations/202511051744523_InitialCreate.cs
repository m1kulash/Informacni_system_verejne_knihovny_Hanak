namespace IS.Knihovna.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autors",
                c => new
                    {
                        AutorID = c.Int(nullable: false, identity: true),
                        Jmeno = c.String(),
                        Prijmeni = c.String(),
                    })
                .PrimaryKey(t => t.AutorID);
            
            CreateTable(
                "dbo.Tituls",
                c => new
                    {
                        TitulID = c.Int(nullable: false, identity: true),
                        Nazev = c.String(),
                        ISBN = c.String(),
                        RokVydani = c.Short(),
                        Nosic = c.String(),
                        StrucnyObsah = c.String(),
                        VydavatelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TitulID)
                .ForeignKey("dbo.Vydavatels", t => t.VydavatelID, cascadeDelete: true)
                .Index(t => t.VydavatelID);
            
            CreateTable(
                "dbo.Exemplars",
                c => new
                    {
                        ExemplarID = c.Int(nullable: false, identity: true),
                        TitulID = c.Int(nullable: false),
                        InventarniCislo = c.String(),
                        Stav = c.String(),
                    })
                .PrimaryKey(t => t.ExemplarID)
                .ForeignKey("dbo.Tituls", t => t.TitulID, cascadeDelete: true)
                .Index(t => t.TitulID);
            
            CreateTable(
                "dbo.Vydavatels",
                c => new
                    {
                        VydavatelID = c.Int(nullable: false, identity: true),
                        Nazev = c.String(),
                    })
                .PrimaryKey(t => t.VydavatelID);
            
            CreateTable(
                "dbo.Zanrs",
                c => new
                    {
                        ZanrID = c.Int(nullable: false, identity: true),
                        Nazev = c.String(),
                    })
                .PrimaryKey(t => t.ZanrID);
            
            CreateTable(
                "dbo.Ctenars",
                c => new
                    {
                        CtenarID = c.Int(nullable: false, identity: true),
                        CisloPrukazky = c.String(),
                        Jmeno = c.String(),
                        Prijmeni = c.String(),
                        DatumNarozeni = c.DateTime(),
                        Pohlavi = c.String(),
                        Vzdelani = c.String(),
                        Aktivni = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CtenarID);
            
            CreateTable(
                "dbo.Rezervaces",
                c => new
                    {
                        RezervaceID = c.Int(nullable: false, identity: true),
                        TitulID = c.Int(nullable: false),
                        CtenarID = c.Int(nullable: false),
                        DatumVytvoreni = c.DateTime(nullable: false),
                        Poradi = c.Int(nullable: false),
                        Stav = c.String(),
                        ExpiraceVydeje = c.DateTime(),
                    })
                .PrimaryKey(t => t.RezervaceID)
                .ForeignKey("dbo.Ctenars", t => t.CtenarID, cascadeDelete: true)
                .ForeignKey("dbo.Tituls", t => t.TitulID, cascadeDelete: true)
                .Index(t => t.TitulID)
                .Index(t => t.CtenarID);
            
            CreateTable(
                "dbo.Vypujckas",
                c => new
                    {
                        VypujckaID = c.Int(nullable: false, identity: true),
                        ExemplarID = c.Int(nullable: false),
                        CtenarID = c.Int(nullable: false),
                        DatumVypujceni = c.DateTime(nullable: false),
                        DatumVraceniPlan = c.DateTime(nullable: false),
                        DatumVraceniSkut = c.DateTime(),
                        Stav = c.String(),
                    })
                .PrimaryKey(t => t.VypujckaID)
                .ForeignKey("dbo.Ctenars", t => t.CtenarID, cascadeDelete: true)
                .ForeignKey("dbo.Exemplars", t => t.ExemplarID, cascadeDelete: true)
                .Index(t => t.ExemplarID)
                .Index(t => t.CtenarID);
            
            CreateTable(
                "dbo.Upominkas",
                c => new
                    {
                        UpominkaID = c.Int(nullable: false),
                        VypujckaID = c.Int(nullable: false),
                        Castka = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duvod = c.String(),
                        DatumVystaveni = c.DateTime(nullable: false),
                        Uhradeno = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UpominkaID)
                .ForeignKey("dbo.Vypujckas", t => t.UpominkaID)
                .Index(t => t.UpominkaID);
            
            CreateTable(
                "dbo.Platbas",
                c => new
                    {
                        PlatbaID = c.Int(nullable: false, identity: true),
                        UpominkaID = c.Int(nullable: false),
                        DatumPlatby = c.DateTime(nullable: false),
                        Castka = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zpusob = c.String(),
                    })
                .PrimaryKey(t => t.PlatbaID)
                .ForeignKey("dbo.Upominkas", t => t.UpominkaID, cascadeDelete: true)
                .Index(t => t.UpominkaID);
            
            CreateTable(
                "dbo.TitulAutor",
                c => new
                    {
                        TitulID = c.Int(nullable: false),
                        AutorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TitulID, t.AutorID })
                .ForeignKey("dbo.Tituls", t => t.TitulID, cascadeDelete: true)
                .ForeignKey("dbo.Autors", t => t.AutorID, cascadeDelete: true)
                .Index(t => t.TitulID)
                .Index(t => t.AutorID);
            
            CreateTable(
                "dbo.TitulZanr",
                c => new
                    {
                        TitulID = c.Int(nullable: false),
                        ZanrID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TitulID, t.ZanrID })
                .ForeignKey("dbo.Tituls", t => t.TitulID, cascadeDelete: true)
                .ForeignKey("dbo.Zanrs", t => t.ZanrID, cascadeDelete: true)
                .Index(t => t.TitulID)
                .Index(t => t.ZanrID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Upominkas", "UpominkaID", "dbo.Vypujckas");
            DropForeignKey("dbo.Platbas", "UpominkaID", "dbo.Upominkas");
            DropForeignKey("dbo.Vypujckas", "ExemplarID", "dbo.Exemplars");
            DropForeignKey("dbo.Vypujckas", "CtenarID", "dbo.Ctenars");
            DropForeignKey("dbo.Rezervaces", "TitulID", "dbo.Tituls");
            DropForeignKey("dbo.Rezervaces", "CtenarID", "dbo.Ctenars");
            DropForeignKey("dbo.TitulZanr", "ZanrID", "dbo.Zanrs");
            DropForeignKey("dbo.TitulZanr", "TitulID", "dbo.Tituls");
            DropForeignKey("dbo.Tituls", "VydavatelID", "dbo.Vydavatels");
            DropForeignKey("dbo.Exemplars", "TitulID", "dbo.Tituls");
            DropForeignKey("dbo.TitulAutor", "AutorID", "dbo.Autors");
            DropForeignKey("dbo.TitulAutor", "TitulID", "dbo.Tituls");
            DropIndex("dbo.TitulZanr", new[] { "ZanrID" });
            DropIndex("dbo.TitulZanr", new[] { "TitulID" });
            DropIndex("dbo.TitulAutor", new[] { "AutorID" });
            DropIndex("dbo.TitulAutor", new[] { "TitulID" });
            DropIndex("dbo.Platbas", new[] { "UpominkaID" });
            DropIndex("dbo.Upominkas", new[] { "UpominkaID" });
            DropIndex("dbo.Vypujckas", new[] { "CtenarID" });
            DropIndex("dbo.Vypujckas", new[] { "ExemplarID" });
            DropIndex("dbo.Rezervaces", new[] { "CtenarID" });
            DropIndex("dbo.Rezervaces", new[] { "TitulID" });
            DropIndex("dbo.Exemplars", new[] { "TitulID" });
            DropIndex("dbo.Tituls", new[] { "VydavatelID" });
            DropTable("dbo.TitulZanr");
            DropTable("dbo.TitulAutor");
            DropTable("dbo.Platbas");
            DropTable("dbo.Upominkas");
            DropTable("dbo.Vypujckas");
            DropTable("dbo.Rezervaces");
            DropTable("dbo.Ctenars");
            DropTable("dbo.Zanrs");
            DropTable("dbo.Vydavatels");
            DropTable("dbo.Exemplars");
            DropTable("dbo.Tituls");
            DropTable("dbo.Autors");
        }
    }
}
