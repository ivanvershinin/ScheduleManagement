namespace ScheduleManagement.Logic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ScheduleManagement.Logic.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<ScheduleManagement.Logic.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ScheduleManagement.Logic.Context";
        }

        protected override void Seed(ScheduleManagement.Logic.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            School school1 = new School { Adress = "Кирпичная, 33", Number = 1001 };
            School school2 = new School { Adress = "Мясницкая, 11", Number = 1002 };
            School school3 = new School { Adress = "Шаболовская, 20", Number = 1003 };

            Cabinet cabinet1 = new Cabinet { Floor = 1, Number = 101, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 30, School = school1 };
            Cabinet cabinet2 = new Cabinet { Floor = 1, Number = 102, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 25, School = school1 };
            Cabinet cabinet3 = new Cabinet { Floor = 1, Number = 103, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school1 };
            Cabinet cabinet4 = new Cabinet { Floor = 1, Number = 104, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school1 };
            Cabinet cabinet5 = new Cabinet { Floor = 2, Number = 201, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school1 };
            Cabinet cabinet6 = new Cabinet { Floor = 2, Number = 202, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school1 };
            Cabinet cabinet7 = new Cabinet { Floor = 2, Number = 203, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school1 };
            Cabinet cabinet8 = new Cabinet { Floor = 2, Number = 204, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school1 };
            Cabinet cabinet9 = new Cabinet { Floor = 3, Number = 301, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school1 };
            Cabinet cabinet10 = new Cabinet { Floor = 3, Number = 302, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school1 };
            Cabinet cabinet11 = new Cabinet { Floor = 3, Number = 303, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school1 };
            Cabinet cabinet12 = new Cabinet { Floor = 3, Number = 304, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school1 };
            Cabinet cabinet13 = new Cabinet { Floor = 1, Number = 101, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 30, School = school2 };
            Cabinet cabinet14 = new Cabinet { Floor = 1, Number = 102, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 25, School = school2 };
            Cabinet cabinet15 = new Cabinet { Floor = 1, Number = 103, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school2 };
            Cabinet cabinet16 = new Cabinet { Floor = 1, Number = 104, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school2 };
            Cabinet cabinet17 = new Cabinet { Floor = 2, Number = 201, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school2 };
            Cabinet cabinet18 = new Cabinet { Floor = 2, Number = 202, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school2 };
            Cabinet cabinet19 = new Cabinet { Floor = 2, Number = 203, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school2 };
            Cabinet cabinet20 = new Cabinet { Floor = 2, Number = 204, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school2 };
            Cabinet cabinet21 = new Cabinet { Floor = 3, Number = 301, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school2 };
            Cabinet cabinet22 = new Cabinet { Floor = 3, Number = 302, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school2 };
            Cabinet cabinet23 = new Cabinet { Floor = 3, Number = 303, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school2 };
            Cabinet cabinet24 = new Cabinet { Floor = 3, Number = 304, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school2 };
            Cabinet cabinet25 = new Cabinet { Floor = 1, Number = 101, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 30, School = school3 };
            Cabinet cabinet26 = new Cabinet { Floor = 1, Number = 102, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 25, School = school3 };
            Cabinet cabinet27 = new Cabinet { Floor = 1, Number = 103, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school3 };
            Cabinet cabinet28 = new Cabinet { Floor = 1, Number = 104, HasComputers = false, HasWhiteBoard = false, PlacesAmount = 15, School = school3 };
            Cabinet cabinet29 = new Cabinet { Floor = 2, Number = 201, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school3 };
            Cabinet cabinet30 = new Cabinet { Floor = 2, Number = 202, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school3 };
            Cabinet cabinet31 = new Cabinet { Floor = 2, Number = 203, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school3 };
            Cabinet cabinet32 = new Cabinet { Floor = 2, Number = 204, HasComputers = false, HasWhiteBoard = true, PlacesAmount = 35, School = school3 };
            Cabinet cabinet33 = new Cabinet { Floor = 3, Number = 301, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school3 };
            Cabinet cabinet34 = new Cabinet { Floor = 3, Number = 302, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school3 };
            Cabinet cabinet35 = new Cabinet { Floor = 3, Number = 303, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school3 };
            Cabinet cabinet36 = new Cabinet { Floor = 3, Number = 304, HasComputers = true, HasWhiteBoard = true, PlacesAmount = 20, School = school3 };

            context.Schools.AddOrUpdate(school1);
            context.Schools.AddOrUpdate(school2);
            context.Schools.AddOrUpdate(school3);

            context.Cabinets.AddOrUpdate(cabinet1);
            context.Cabinets.AddOrUpdate(cabinet2);
            context.Cabinets.AddOrUpdate(cabinet3);
            context.Cabinets.AddOrUpdate(cabinet4);
            context.Cabinets.AddOrUpdate(cabinet5);
            context.Cabinets.AddOrUpdate(cabinet6);
            context.Cabinets.AddOrUpdate(cabinet7);
            context.Cabinets.AddOrUpdate(cabinet8);
            context.Cabinets.AddOrUpdate(cabinet9);
            context.Cabinets.AddOrUpdate(cabinet10);
            context.Cabinets.AddOrUpdate(cabinet11);
            context.Cabinets.AddOrUpdate(cabinet12);
            context.Cabinets.AddOrUpdate(cabinet13);
            context.Cabinets.AddOrUpdate(cabinet14);
            context.Cabinets.AddOrUpdate(cabinet15);
            context.Cabinets.AddOrUpdate(cabinet16);
            context.Cabinets.AddOrUpdate(cabinet17);
            context.Cabinets.AddOrUpdate(cabinet18);
            context.Cabinets.AddOrUpdate(cabinet19);
            context.Cabinets.AddOrUpdate(cabinet20);
            context.Cabinets.AddOrUpdate(cabinet21);
            context.Cabinets.AddOrUpdate(cabinet22);
            context.Cabinets.AddOrUpdate(cabinet23);
            context.Cabinets.AddOrUpdate(cabinet24);
            context.Cabinets.AddOrUpdate(cabinet25);
            context.Cabinets.AddOrUpdate(cabinet26);
            context.Cabinets.AddOrUpdate(cabinet27);
            context.Cabinets.AddOrUpdate(cabinet28);
            context.Cabinets.AddOrUpdate(cabinet29);
            context.Cabinets.AddOrUpdate(cabinet30);
            context.Cabinets.AddOrUpdate(cabinet31);
            context.Cabinets.AddOrUpdate(cabinet32);
            context.Cabinets.AddOrUpdate(cabinet33);
            context.Cabinets.AddOrUpdate(cabinet34);
            context.Cabinets.AddOrUpdate(cabinet35);
            context.Cabinets.AddOrUpdate(cabinet36);
        
        }
    }
}
