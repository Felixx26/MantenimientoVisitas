namespace MantenimientoVisitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        AreaID = c.Int(nullable: false, identity: true),
                        NombreArea = c.String(),
                        Estado = c.Boolean(nullable: false),
                        VisitaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaID);
            
            CreateTable(
                "dbo.Visitas",
                c => new
                    {
                        VisitaID = c.Int(nullable: false, identity: true),
                        AreaID = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        HoraEntrada = c.DateTime(nullable: false),
                        HoraSalida = c.DateTime(nullable: false),
                        PersonaID = c.Int(nullable: false),
                        Motivo = c.String(),
                    })
                .PrimaryKey(t => t.VisitaID)
                .ForeignKey("dbo.Areas", t => t.AreaID, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.PersonaID, cascadeDelete: true)
                .Index(t => t.AreaID)
                .Index(t => t.PersonaID);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.PersonaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitas", "PersonaID", "dbo.Personas");
            DropForeignKey("dbo.Visitas", "AreaID", "dbo.Areas");
            DropIndex("dbo.Visitas", new[] { "PersonaID" });
            DropIndex("dbo.Visitas", new[] { "AreaID" });
            DropTable("dbo.Personas");
            DropTable("dbo.Visitas");
            DropTable("dbo.Areas");
        }
    }
}
