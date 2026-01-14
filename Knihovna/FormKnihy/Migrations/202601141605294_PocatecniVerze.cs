namespace FormKnihy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PocatecniVerze : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ctenars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jmeno = c.String(nullable: false),
                        Prijmeni = c.String(nullable: false),
                        DatumNarozeni = c.DateTime(nullable: false),
                        Pohlavi = c.String(),
                        Vzdelani = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Knihas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazev = c.String(nullable: false),
                        Autor = c.String(),
                        Zanr = c.String(),
                        Vydavatel = c.String(),
                        RokVydani = c.Int(nullable: false),
                        Nosic = c.String(),
                        Obsah = c.String(),
                        JeVyrazena = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Knihas");
            DropTable("dbo.Ctenars");
        }
    }
}
