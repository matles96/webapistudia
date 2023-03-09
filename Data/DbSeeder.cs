using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjektV3.Data.Models;

namespace ProjektV3.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any()) CreateUsers(dbContext);
            if (!dbContext.Doctors.Any()) CreateDoctors(dbContext);
            if (!dbContext.WorkingHours.Any()) CreateWorkingHours(dbContext);
            if (!dbContext.Registrations.Any()) CreateRegistrations(dbContext);
        }

        private static void CreateUsers(ApplicationDbContext context)
        {
            
            var patient_1 = new ApplicationUser() {
                //Id = 1000,
                Name = "NieUzywajcieTegoPacjeta",
                LastName = "xD",
                PESEL = "11111111111",
                Password = "password",
                PhoneNumber = "SerioBoNieWiem",
                //UserName = "user_1",
                //Email = "user_1@gmail.com"
            };

            var patient_2 = new ApplicationUser()
            {
                //Id = 1001,
                Name = "Wojtek",
                LastName = "Nowak",
                PESEL = "22222222222",
                Password = "password",
                PhoneNumber = "111",
                //UserName = "user_2",
                //Email = "user_2@gmail.com"
            };

            var patient_3 = new ApplicationUser()
            {
                //Id = 1002,
                Name = "Kasia",
                LastName = "Kowalski",
                PESEL = "33333333333",
                Password = "password",
                PhoneNumber = "111",
                //UserName = "user_3",
                //Email = "user_3@gmail.com"
            };

            var patient_4 = new ApplicationUser()
            {
                //Id = 1003,
                Name = "Monika",
                LastName = "Nowak",
                PESEL = "44444444444",
                Password = "password",
                PhoneNumber = "111",
                //UserName = "user_4",
                //Email = "user_4@gmail.com",
            };



            context.Users.AddRange(patient_1, patient_2, patient_3, patient_4);
            context.SaveChanges();
        }

        private static void CreateDoctors(ApplicationDbContext context)
        {
            var entity_1 = new Doctor()
            {
                //Id = 1000,
                Name = "Patryk",
                LastName = "Wieczorek",
                PhoneNumber = "111"
            };

            var entity_2 = new Doctor()
            {
                //Id = 1001,
                Name = "Andrzej",
                LastName = "Nowak",
                PhoneNumber = "111"
            };

            var entity_3 = new Doctor()
            {
                //Id = 1002,
                Name = "Krystyna",
                LastName = "Kowalska",
                PhoneNumber = "111"
            };

            var entity_4 = new Doctor()
            {
                //Id = 1003,
                Name = "Karolina",
                LastName = "Wieczorek",
                PhoneNumber = "111"
            };

            context.Doctors.AddRange(entity_1, entity_2, entity_3, entity_4);
            context.SaveChanges();
        }

        private static void CreateWorkingHours(ApplicationDbContext context)
        {
            var entity_1 = new WorkingHour()
            {
                //Id = 1000,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Monday,
                StartWorkingHours = new DateTime(2019, 11, 18, 08, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 18, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_2= new WorkingHour()
            {
                //Id = 1001,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Tuesday,
                StartWorkingHours = new DateTime(2019, 11, 19, 08, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 19, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_3 = new WorkingHour()
            {
                //Id = 1002,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Wednesday,
                StartWorkingHours = new DateTime(2019, 11, 20, 08, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 20, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_4 = new WorkingHour()
            {
                //Id = 1003,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Thursday,
                StartWorkingHours = new DateTime(2019, 11, 21, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 21, 18, 00, 00),
                RoomNumber = 1
            };
            //////////////////////
            var entity_5 = new WorkingHour()
            {
                //Id = 1004,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Monday,
                StartWorkingHours = new DateTime(2019, 11, 18, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 18, 18, 00, 00),
                RoomNumber = 1
            };
            var entity_6 = new WorkingHour()
            {
                //Id = 1005,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Tuesday,
                StartWorkingHours = new DateTime(2019, 11, 19, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 19, 18, 00, 00),
                RoomNumber = 1
            };
            var entity_7 = new WorkingHour()
            {
                //Id = 1006,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Wednesday,
                StartWorkingHours = new DateTime(2019, 11, 20, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 20, 18, 00, 00),
                RoomNumber = 1
            };
            var entity_8 = new WorkingHour()
            {
                //Id = 1007,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Thursday,
                StartWorkingHours = new DateTime(2019, 11, 21, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 21, 18, 00, 00),
                RoomNumber = 1
            };
            ////////////////
            var entity_9 = new WorkingHour()
            {
                //Id = 1008,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Monday,
                StartWorkingHours = new DateTime(2019, 11, 18, 12, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 18, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_10 = new WorkingHour()
            {
                //Id = 1009,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Tuesday,
                StartWorkingHours = new DateTime(2019, 11, 19, 12, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 19, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_11 = new WorkingHour()
            {
                //Id = 1010,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Wednesday,
                StartWorkingHours = new DateTime(2019, 11, 20, 08, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 20, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_12 = new WorkingHour()
            {
                //Id = 1011,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Thursday,
                StartWorkingHours = new DateTime(2019, 11, 21, 12, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 21, 18, 00, 00),
                RoomNumber = 1
            };
            //////////////
            var entity_13 = new WorkingHour()
            {
                //Id = 1012,
                IdDoctor = context.Doctors.Where(u => u.Name == "Karolina").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Tuesday,
                StartWorkingHours = new DateTime(2019, 11, 19, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 19, 18, 00, 00),
                RoomNumber = 1
            };
            var entity_14 = new WorkingHour()
            {
                //Id = 1013,
                IdDoctor = context.Doctors.Where(u => u.Name == "Karolina").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Wednesday,
                StartWorkingHours = new DateTime(2019, 11, 20, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 20, 18, 00, 00),
                RoomNumber = 1
            };
            var entity_15 = new WorkingHour()
            {
                //Id = 1014,
                IdDoctor = context.Doctors.Where(u => u.Name == "Karolina").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Thursday,
                StartWorkingHours = new DateTime(2019, 11, 21, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 21, 20, 00, 00),
                RoomNumber = 1
            };
            var entity_16 = new WorkingHour()
            {
                //Id = 1015,
                IdDoctor = context.Doctors.Where(u => u.Name == "Karolina").FirstOrDefault().Id,
                DayOfTheWeek = EDayOfTheWeek.Friday,
                StartWorkingHours = new DateTime(2019, 11, 22, 10, 00, 00),
                EndWorkingHours = new DateTime(2019, 11, 22, 18, 00, 00),
                RoomNumber = 1
            };
            context.WorkingHours.AddRange(entity_1, entity_2, entity_3, entity_4, entity_5, entity_6, entity_7, entity_8, entity_8, entity_9, entity_10, entity_11, entity_12, entity_13, entity_14, entity_15, entity_16);
            context.SaveChanges();
        }

        private static void CreateRegistrations(ApplicationDbContext context)
        {
            /*
            var entity_1 = new Registration()
            {
                //Id = 1000,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Adam").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 18, 13, 00, 00),
                RoomNumber = 1
            }; */
            var entity_2 = new Registration()
            {
                //Id = 1001,
                IdDoctor = context.Doctors.Where(u => u.Name == "Patryk").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Wojtek").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 19, 13, 00, 00),
                RoomNumber = 1
            };
            var entity_3 = new Registration()
            {
                //Id = 1002,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Wojtek").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 20, 11, 00, 00),
                RoomNumber = 1
            };
            /*
            var entity_4 = new Registration()
            {
                //Id = 1003,
                IdDoctor = context.Doctors.Where(u => u.Name == "Andrzej").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Adam").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 21, 15, 00, 00),
                RoomNumber = 1
            }; */
            var entity_5 = new Registration()
            {
                //Id = 1004,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Kasia").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 20, 14, 00, 00),
                RoomNumber = 1
            };
            var entity_6 = new Registration()
            {
                //Id = 1005,
                IdDoctor = context.Doctors.Where(u => u.Name == "Krystyna").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Kasia").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 21, 16, 00, 00),
                RoomNumber = 1
            };
            var entity_7 = new Registration()
            {
                //Id = 1006,
                IdDoctor = context.Doctors.Where(u => u.Name == "Karolina").FirstOrDefault().Id,
                IdPatient = context.Users.Where(u => u.Name == "Monika").FirstOrDefault().Id,
                Hour = new DateTime(2019, 11, 22, 14, 00, 00),
                RoomNumber = 1
            };
            context.Registrations.AddRange(entity_2, entity_3, entity_5, entity_6, entity_7);
            context.SaveChanges();
        }
    }
}
