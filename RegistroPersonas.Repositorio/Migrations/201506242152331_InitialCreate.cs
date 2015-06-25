namespace RegistroPersonas.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fotoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreFiti = c.String(),
                        ubicacion = c.String(),
                        Descripcion = c.String(),
                        persona_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personas", t => t.persona_Id)
                .Index(t => t.persona_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Identificacion = c.Int(nullable: false),
                        Nombres = c.String(nullable: false, maxLength: 20),
                        Apellidos = c.String(nullable: false, maxLength: 20),
                        Sexo = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Profesion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fotoes", "persona_Id", "dbo.Personas");
            DropIndex("dbo.Fotoes", new[] { "persona_Id" });
            DropTable("dbo.Personas");
            DropTable("dbo.Fotoes");
        }
    }
}
