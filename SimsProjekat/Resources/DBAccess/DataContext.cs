using Microsoft.EntityFrameworkCore;
using SimsProjekat.Domain.Models;
using SimsProjekat.Resources.Database;
using System.Collections.Generic;
using System;

namespace SimsProjekat.Resources.DBAccess
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; } 

        public DbSet<Guest> Guests { get; set; }    

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Hotel> Hotels {  get; set; }

        public DbSet<Owner> Owners {  get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(GlobalConfig.CnnVal("booking_data.db"));
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedAdmin(modelBuilder);
            SeedGuest(modelBuilder);
            SeedOwner(modelBuilder);
            SeedHotel(modelBuilder);
            SeedApartments(modelBuilder);
            SeedReservation(modelBuilder);
        }

        private static void SeedAdmin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Jmbg = "1234567890123", 
                Email = "admin1@gmail.com",
                Password = "admin1",
                FirstName = "Marko",
                LastName = "Markovic",
                PhoneNumber = "123456789",
                UserType = UserType.Admin,
                IsBlocked = false
            },
            new Admin
            {
                Jmbg = "4567890123456", 
                Email = "admin2@gmail.com",
                Password = "admin2",
                FirstName = "Pera",
                LastName = "Peric",
                PhoneNumber = "123456789",
                UserType = UserType.Admin,
                IsBlocked = false
            }
        );
        }

        private static void SeedGuest(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
            new Guest
            {
                Jmbg = "1111111111111",
                Email = "guest1@gmail.com",
                Password = "guest1",
                FirstName = "Mara",
                LastName = "Maric",
                PhoneNumber = "123456789",
                UserType = UserType.Guest,
                IsBlocked = false
            },
            new Guest
            {
                Jmbg = "2222222222222",
                Email = "guest2@gmail.com",
                Password = "guest2",
                FirstName = "Nikola",
                LastName = "Nikolic",
                PhoneNumber = "123456789",
                UserType = UserType.Guest,
                IsBlocked = false
            },
            new Guest
            {
                Jmbg = "3333333333333",
                Email = "guest3@gmail.com",
                Password = "guest3",
                FirstName = "Jovana",
                LastName = "Jovanic",
                PhoneNumber = "123456789",
                UserType = UserType.Guest,
                IsBlocked = false
            }
        );
        }

        private static void SeedOwner(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(
            new Owner
            {
                Jmbg = "4444444444444",
                Email = "owner1@gmail.com",
                Password = "owner1",
                FirstName = "Mara",
                LastName = "Maric",
                PhoneNumber = "123456789",
                UserType = UserType.Owner,
                IsBlocked = false
            },
            new Owner
            {
                Jmbg = "5555555555555",
                Email = "owner2@gmail.com",
                Password = "owner2",
                FirstName = "Nikola",
                LastName = "Nikolic",
                PhoneNumber = "123456789",
                UserType = UserType.Owner,
                IsBlocked = false
            },
            new Owner
            {
                Jmbg = "6666666666666",
                Email = "owner3@gmail.com",
                Password = "owner3",
                FirstName = "Jovana",
                LastName = "Jovanic",
                PhoneNumber = "123456789",
                UserType = UserType.Owner,
                IsBlocked = false
            }
        );
        }

        private static void SeedHotel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1, 
                Name = "Deluxe Hotel",
                ConstructionYear = 2000,
                Rating = 5,
                OwnerJmbg = "4444444444444",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 2,
                Name = "Hotel Moscow",
                ConstructionYear = 1995,
                Rating = 4,
                OwnerJmbg = "4444444444444",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 3,
                Name = "Hotel Paradise",
                ConstructionYear = 1990,
                Rating = 3,
                OwnerJmbg = "5555555555555",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 4,
                Name = "Hotel Belgrade",
                ConstructionYear = 1980,
                Rating = 4,
                OwnerJmbg = "4444444444444",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 5,
                Name = "Yugoslavia",
                ConstructionYear = 1960,
                Rating = 3,
                OwnerJmbg = "5555555555555",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 6,
                Name = "Hotel Sheraton",
                ConstructionYear = 2005,
                Rating = 5,
                OwnerJmbg = "4444444444444",
                Status = Status.Confirmed
            },
            new Hotel
            {
                Id = 7,
                Name = "Hilton",
                ConstructionYear = 1990,
                Rating = 5,
                OwnerJmbg = "4444444444444",
                Status = Status.Pending
            },
            new Hotel
            {
                Id = 8,
                Name = "Hotel Vojvodina",
                ConstructionYear = 1990,
                Rating = 2,
                OwnerJmbg = "4444444444444",
                Status = Status.Pending
            }
        );
        }

        private static void SeedApartments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>().HasData(
                new Apartment
                {
                    Id = 1,
                    Name = "Sample Apartment 1",
                    Description = "This is a sample description for apartment 1.",
                    RoomCount = 2,
                    MaxGuestNumber = 4,
                    HotelId = 1
                },
                new Apartment
                {
                    Id = 2,
                    Name = "Sample Apartment 2",
                    Description = "This is a sample description for apartment 2.",
                    RoomCount = 3,
                    MaxGuestNumber = 6,
                    HotelId = 1
                },
                new Apartment
                {
                    Id = 3,
                    Name = "Sample Apartment 3",
                    Description = "This is a sample description for apartment 3.",
                    RoomCount = 1,
                    MaxGuestNumber = 2,
                    HotelId = 2
                },
                new Apartment
                {
                    Id = 4,
                    Name = "Sample Apartment 4",
                    Description = "This is a sample description for apartment 4.",
                    RoomCount = 4,
                    MaxGuestNumber = 8,
                    HotelId = 2
                },
                new Apartment
                {
                    Id = 5,
                    Name = "Sample Apartment 5",
                    Description = "This is a sample description for apartment 5.",
                    RoomCount = 1,
                    MaxGuestNumber = 2,
                    HotelId = 3
                },
                new Apartment
                {
                    Id = 6,
                    Name = "Sample Apartment 6",
                    Description = "This is a sample description for apartment 6.",
                    RoomCount = 2,
                    MaxGuestNumber = 4,
                    HotelId = 3
                },
                new Apartment
                {
                    Id = 7,
                    Name = "Sample Apartment 7",
                    Description = "This is a sample description for apartment 7.",
                    RoomCount = 2,
                    MaxGuestNumber = 4,
                    HotelId = 1
                },
                new Apartment
                {
                    Id = 8,
                    Name = "Sample Apartment 8",
                    Description = "This is a sample description for apartment 8.",
                    RoomCount = 2,
                    MaxGuestNumber = 4,
                    HotelId = 3
                }
            ); 
        }
        private static void SeedReservation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    GuestJmbg = "1111111111111",
                    ApartmentId = 1,
                    ReservationDate = DateTime.Now,
                    Status = Status.Pending,
                    RejectionReason = ""
                },
                new Reservation
                {
                    Id = 2,
                    GuestJmbg = "2222222222222",
                    ApartmentId = 2, 
                    ReservationDate = DateTime.Now,
                    Status = Status.Pending,
                    RejectionReason = ""
                },
                new Reservation
                {
                    Id = 3,
                    GuestJmbg = "1111111111111",
                    ApartmentId = 3,
                    ReservationDate = DateTime.ParseExact("22.05.2024", "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = Status.Confirmed,
                    RejectionReason = ""
                },
                new Reservation
                {
                    Id = 4,
                    GuestJmbg = "2222222222222",
                    ApartmentId = 2,
                    ReservationDate = DateTime.ParseExact("23.04.2024", "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = Status.Pending,
                    RejectionReason = ""
                },
                new Reservation
                {
                    Id = 5,
                    GuestJmbg = "2222222222222",
                    ApartmentId = 1,
                    ReservationDate = DateTime.ParseExact("21.03.2024", "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = Status.Pending,
                    RejectionReason = ""
                }
         );
        }

    }
}
