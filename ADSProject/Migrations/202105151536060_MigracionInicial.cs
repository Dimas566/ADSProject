namespace ADSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 3),
                        nombre = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        email = c.String(),
                        nombres = c.String(),
                        apellidos = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Estudiante");
            DropTable("dbo.Carrera");
        }
    }
}
