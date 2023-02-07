﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace SE_ASG
{
    class Run
    {
        static void Main(string[] args)
        {
            // This file is for the codes to run the main stuff
            IUser userInterface = new Guest();
            IUser guest = new Guest();
            Hotel hotel = new Hotel();
            string answer;

            // Creating hotels
            List<Hotel> hotels = new List<Hotel>
            {
                new Hotel { hotelID = 1, hotelType = "luxury", avaliableRooms = 0, allowVoucher = true, hotelAddress = "Q street" },
                new Hotel { hotelID = 2, hotelType = "themed", avaliableRooms = 0, allowVoucher = true, hotelAddress = "W street" },
                new Hotel { hotelID = 3, hotelType = "family-friendly", avaliableRooms = 0, allowVoucher = true, hotelAddress = "E street" },
                new Hotel { hotelID = 4, hotelType = "city", avaliableRooms = 0, allowVoucher = false, hotelAddress = "R street" },
                new Hotel { hotelID = 5, hotelType = "budget hotel", avaliableRooms = 0, allowVoucher = false, hotelAddress = "T street" }
            };

            // creating a guest
            List<Guest> guests = new List<Guest>
            {
                new Guest { personalID = 1, email = "user1", number = "64323224", balance = 10, password = "pass1234"}
            };

            // Creating rooms for each hotel
            foreach (Hotel h in hotels)
            {
                Room newRoom = new Room { roomNumber = 1, roomType = "Big", roomCost = 5, maxGuest = 2, availability = true };
                h.AddRoom(newRoom);
            }


            // Running of the program
            while (true)
            {
                Console.WriteLine("\nWhat do you want to do (1 - 2): \n1) Login  \n2) Register");
                answer = Console.ReadLine();

                if (answer == "1")
                {
                    guest = guest.Login(guests);

                    // changed login to return true (need change in class diagram). Might need to change login to return a guest so that we can use it to create resevations and stuff
                    if (guest != null)
                    {
                        while (true)
                        {
                            // probably need to check for user type as well
                            Console.WriteLine("\nPlease choose an option (1 - 3): \n1) Browse  \n2) View Reservations\n3) Cancel Reservations\n4) Logout");
                            answer = Console.ReadLine();
                            if (answer == "1")
                            {
                                guest.Browse(hotels);
                            }
                            else if (answer == "2")
                            {
                                guest.ViewBookings();
                            }
                            else if (answer == "3")
                            {
                                guest.CancelReservation();
                            }
                            else if (answer == "4")
                            {
                                guest = null;
                                break;
                            }

                        }

                    }
                    else { Console.WriteLine("Login Error"); }
                }

                else if (answer == "2")
                {

                }
            }         

        }
    }
}