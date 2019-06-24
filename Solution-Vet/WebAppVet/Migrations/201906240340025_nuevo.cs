namespace WebAppVet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id_client = c.Int(nullable: false),
                        Id_patient = c.Int(nullable: false),
                        FullName = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Patient_Id_patient = c.Int(),
                        Patient_Id_client = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id_client, t.Id_patient })
                .ForeignKey("dbo.Patients", t => new { t.Patient_Id_patient, t.Patient_Id_client })
                .Index(t => new { t.Patient_Id_patient, t.Patient_Id_client });
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id_patient = c.Int(nullable: false),
                        Id_client = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Owner_Id_client = c.Int(nullable: false),
                        Owner_Id_patient = c.Int(nullable: false),
                        Client_Id_client = c.Int(),
                        Client_Id_patient = c.Int(),
                        Turn_Id_turn = c.Int(),
                        Turn_Id_patient = c.Int(),
                        Turn_Id_doctor = c.Int(),
                        Turn_Id_room = c.Int(),
                    })
                .PrimaryKey(t => new { t.Id_patient, t.Id_client })
                .ForeignKey("dbo.Clients", t => new { t.Owner_Id_client, t.Owner_Id_patient }, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => new { t.Client_Id_client, t.Client_Id_patient })
                .ForeignKey("dbo.Turns", t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room })
                .Index(t => new { t.Owner_Id_client, t.Owner_Id_patient })
                .Index(t => new { t.Client_Id_client, t.Client_Id_patient })
                .Index(t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room });
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id_doctor = c.Int(nullable: false),
                        Id_turn = c.Int(nullable: false),
                        name = c.String(nullable: false),
                        specialization = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_doctor, t.Id_turn });
            
            CreateTable(
                "dbo.Turns",
                c => new
                    {
                        Id_turn = c.Int(nullable: false),
                        Id_patient = c.Int(nullable: false),
                        Id_doctor = c.Int(nullable: false),
                        Id_room = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id_turn, t.Id_patient, t.Id_doctor, t.Id_room });
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id_room = c.Int(nullable: false),
                        Id_turn = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.Id_room, t.Id_turn });
            
            CreateTable(
                "dbo.TurnRooms",
                c => new
                    {
                        Turn_Id_turn = c.Int(nullable: false),
                        Turn_Id_patient = c.Int(nullable: false),
                        Turn_Id_doctor = c.Int(nullable: false),
                        Turn_Id_room = c.Int(nullable: false),
                        Rooms_Id_room = c.Int(nullable: false),
                        Rooms_Id_turn = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room, t.Rooms_Id_room, t.Rooms_Id_turn })
                .ForeignKey("dbo.Turns", t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room }, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => new { t.Rooms_Id_room, t.Rooms_Id_turn }, cascadeDelete: true)
                .Index(t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room })
                .Index(t => new { t.Rooms_Id_room, t.Rooms_Id_turn });
            
            CreateTable(
                "dbo.DoctorTurns",
                c => new
                    {
                        Doctor_Id_doctor = c.Int(nullable: false),
                        Doctor_Id_turn = c.Int(nullable: false),
                        Turn_Id_turn = c.Int(nullable: false),
                        Turn_Id_patient = c.Int(nullable: false),
                        Turn_Id_doctor = c.Int(nullable: false),
                        Turn_Id_room = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Doctor_Id_doctor, t.Doctor_Id_turn, t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room })
                .ForeignKey("dbo.Doctors", t => new { t.Doctor_Id_doctor, t.Doctor_Id_turn }, cascadeDelete: true)
                .ForeignKey("dbo.Turns", t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room }, cascadeDelete: true)
                .Index(t => new { t.Doctor_Id_doctor, t.Doctor_Id_turn })
                .Index(t => new { t.Turn_Id_turn, t.Turn_Id_patient, t.Turn_Id_doctor, t.Turn_Id_room });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" }, "dbo.Doctors");
            DropForeignKey("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" }, "dbo.Rooms");
            DropForeignKey("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" }, "dbo.Turns");
            DropForeignKey("dbo.Patients", new[] { "Client_Id_client", "Client_Id_patient" }, "dbo.Clients");
            DropForeignKey("dbo.Patients", new[] { "Owner_Id_client", "Owner_Id_patient" }, "dbo.Clients");
            DropForeignKey("dbo.Clients", new[] { "Patient_Id_patient", "Patient_Id_client" }, "dbo.Patients");
            DropIndex("dbo.DoctorTurns", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.DoctorTurns", new[] { "Doctor_Id_doctor", "Doctor_Id_turn" });
            DropIndex("dbo.TurnRooms", new[] { "Rooms_Id_room", "Rooms_Id_turn" });
            DropIndex("dbo.TurnRooms", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.Patients", new[] { "Turn_Id_turn", "Turn_Id_patient", "Turn_Id_doctor", "Turn_Id_room" });
            DropIndex("dbo.Patients", new[] { "Client_Id_client", "Client_Id_patient" });
            DropIndex("dbo.Patients", new[] { "Owner_Id_client", "Owner_Id_patient" });
            DropIndex("dbo.Clients", new[] { "Patient_Id_patient", "Patient_Id_client" });
            DropTable("dbo.DoctorTurns");
            DropTable("dbo.TurnRooms");
            DropTable("dbo.Rooms");
            DropTable("dbo.Turns");
            DropTable("dbo.Doctors");
            DropTable("dbo.Patients");
            DropTable("dbo.Clients");
        }
    }
}
