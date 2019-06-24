namespace WebAppVet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevo9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropIndex("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropPrimaryKey("dbo.Turns");
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        Id_billing = c.Int(nullable: false, identity: true),
                        service = c.Int(nullable: false),
                        Id_turn = c.Int(nullable: false),
                        precio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_billing);
            
            AddColumn("dbo.Turns", "patient_Id_patient", c => c.Int());
            AddColumn("dbo.Turns", "patient_Id_client", c => c.Int());
            AlterColumn("dbo.Turns", "Id_turn", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Turns", "Id_turn");
            CreateIndex("dbo.Turns", "Id_doctor");
            CreateIndex("dbo.Turns", "Id_room");
            CreateIndex("dbo.Turns", new[] { "patient_Id_patient", "patient_Id_client" });
            AddForeignKey("dbo.Turns", "Id_doctor", "dbo.Doctors", "Id_doctor", cascadeDelete: true);
            AddForeignKey("dbo.Turns", new[] { "patient_Id_patient", "patient_Id_client" }, "dbo.Patients", new[] { "Id_patient", "Id_client" });
            AddForeignKey("dbo.Turns", "Id_room", "dbo.Rooms", "Id_room", cascadeDelete: true);
            DropColumn("dbo.Patients", "Turn_Id_turn");
            DropColumn("dbo.Patients", "Turn_Id_patient");
            DropColumn("dbo.Patients", "Turn_Id_doctor");
            DropColumn("dbo.Patients", "Turn_Id_room");
            DropColumn("dbo.Doctors", "Turn_Id_turn");
            DropColumn("dbo.Doctors", "Turn_Id_patient");
            DropColumn("dbo.Doctors", "Turn_Id_doctor");
            DropColumn("dbo.Doctors", "Turn_Id_room");
            DropColumn("dbo.Rooms", "Turn_Id_turn");
            DropColumn("dbo.Rooms", "Turn_Id_patient");
            DropColumn("dbo.Rooms", "Turn_Id_doctor");
            DropColumn("dbo.Rooms", "Turn_Id_room");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Turn_Id_room", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_doctor", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_patient", c => c.Int());
            AddColumn("dbo.Rooms", "Turn_Id_turn", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_room", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_doctor", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_patient", c => c.Int());
            AddColumn("dbo.Doctors", "Turn_Id_turn", c => c.Int());
            AddColumn("dbo.Patients", "Turn_Id_room", c => c.Int());
            AddColumn("dbo.Patients", "Turn_Id_doctor", c => c.Int());
            AddColumn("dbo.Patients", "Turn_Id_patient", c => c.Int());
            AddColumn("dbo.Patients", "Turn_Id_turn", c => c.Int());
            DropForeignKey("dbo.Turns", "Id_room", "dbo.Rooms");
            DropForeignKey("dbo.Turns", new[] { "patient_Id_patient", "patient_Id_client" }, "dbo.Patients");
            DropForeignKey("dbo.Turns", "Id_doctor", "dbo.Doctors");
            DropIndex("dbo.Turns", new[] { "patient_Id_patient", "patient_Id_client" });
            DropIndex("dbo.Turns", new[] { "Id_room" });
            DropIndex("dbo.Turns", new[] { "Id_doctor" });
            DropPrimaryKey("dbo.Turns");
            AlterColumn("dbo.Turns", "Id_turn", c => c.Int(nullable: false));
            DropColumn("dbo.Turns", "patient_Id_client");
            DropColumn("dbo.Turns", "patient_Id_patient");
            DropTable("dbo.Billings");
            AddPrimaryKey("dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
            CreateIndex("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            CreateIndex("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            CreateIndex("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            AddForeignKey("dbo.Rooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
            AddForeignKey("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
            AddForeignKey("dbo.Doctors", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns", new[] { "Id_turn", "Id_patient", "Id_doctor", "Id_room" });
        }
    }
}
