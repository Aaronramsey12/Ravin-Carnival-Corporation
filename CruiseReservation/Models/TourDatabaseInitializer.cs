using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CruiseReservation.Models
{
    public class TourDatabaseInitializer : DropCreateDatabaseAlways<TourContext>
    {
        protected override void Seed(TourContext context)
        {
            GetCruises().ForEach(c => context.Cruises.Add(c));
            GetTours().ForEach(t => context.Tours.Add(t));
            Getcabin().ForEach(b => context.Cabin.Add(b));
        }

        private static List<Cabin> Getcabin()
        {
            var Cabins = new List<Cabin>
            {
                new Cabin
                {
                    CabinID = 1,
                    CabinType = "Interior/Inside",
                    Description = "Inside cabins are the smallest on the ship and are the least expensive cabins. Located in the interior of the ship, these cabins do not have windows, although you might be able to look at the view on the cabin’s television. Some cruise lines mount cameras on the ship and offer a view from the bow on one of the ship’s television channels. While small, your cabin will contain everything you need for your cruise. Typical furnishings include beds, bathroom with shower, safe, television and limited storage. Depending on the category, inside cabins sleep two to four people.",
                    ImagePath = "interior-stateroom-layout.jpg",
                    ImageDesc = "Interior.jpg",
                    CabinPrice = 300.00
                },
                new Cabin
                {
                    CabinID = 2,
                    CabinType = "Balcony",
                    Description ="Balcony cabins feature a private balcony off your cabin. These cabins are the next level up in price from the oceanview cabins and are usually a little larger. You’ll be able to enjoy the changing scenery from your balcony and can enjoy a peaceful room service breakfast or dinner on the balcony. Balcony cabins might have a slightly different floor plan than inside or oceanview cabins.",
                    ImagePath = "balcony-stateroom-layout.jpg",
                     ImageDesc = "breathtaking-view-from-balcony-stateroom.jpg",
                    CabinPrice = 400.00
                },
                new Cabin
                {
                    CabinID = 3,
                    CabinType = "Oceanview",
                    Description="Oceanview cabins aren’t usually much larger than inside cabins, but what you’ll be paying for is a view. Oceanview cabins contain all of the features of inside cabins, but also include a porthole, picture window or floor-to-ceiling windows, depending on the category and deck level. Oceanview cabins are a good choice for those people who don’t want to book an expensive balcony cabin, but want the advantage of natural light and the ability to see the view from the cabin.",
                    ImagePath = "ocean-view-stateroom-layout.jpg",
                     ImageDesc = "ocean-view-stateroom-with-view.jpg",
                    CabinPrice = 500.00
                },
                new Cabin
                {
                    CabinID = 4,
                    CabinType = "Suite",
                    Description = "Suites range from basic two-room suites to large, luxurious multi-roomed spaces with your own hot tub. Suites are the most expensive accommodations on the ship, but feature many amenities for the money. In additional to the extra space, suites feature extra-large balconies complete with lounge chairs. Suite residents are often eligible for certain perks. You might be given access to a private lounge or pool or be given special access to specialty restaurants if you book a suite.Sponsored links",
                    ImagePath = "deluxe-bathroom-whirlpool-tub.jpg",
                     ImageDesc = "suite-stateroom.jpg",
                    CabinPrice = 600.00
                },
            };
            return Cabins;
        }

        private static List<Cruise> GetCruises()
        {
            var Cruises = new List<Cruise>
            {
                new Cruise
                {
                    CruiseID = 1,
                    CruiseName = "Princess Cruise"
                },
                new Cruise
                {
                    CruiseID = 2,
                    CruiseName = "Cunard Line"
                },

            };
            return Cruises;
        }

        private static List<Tour> GetTours()
        {
            var Tours = new List<Tour>
            {
                new Tour
                {
                    TourID = 1,
                    TourName = "ALASKA CRUISETOURS (CONNOISSEUR)",
                    Decription = "7 days Voyage With 5-8 Nights on land and Escorted by a Tour Director. " + "Most meals on land included " + "Princess Alaska rail service with At least two nights at Denali and Includes Fairbanks or Anchorage", 
                    ImagePath = "alaska.jpg",
                    UnitPrice = 3441.15,
                    CruiseID = 2
                },
                new Tour
                {
                    TourID = 2,
                    TourName = "CARIBBEAN CRUISE (EASTERN CARIBBEAN)",
                    Decription = "Enjoy top rated white-sand beaches and laid-back vibe " + "A shoppers paradise! Spectacular duty-free shopping districts and Visits Princess Cays on most itineraries" + "Sea turtles, stingrays & butterfly farms",
                    ImagePath = "caribbean.jpg",
                    UnitPrice = 656.60,
                    CruiseID = 1
                },
                new Tour
                {
                    TourID = 3,
                    TourName = "EUROPENA CRUISES (MEDITERRANEAN 7 GREEK ISLES)",
                    Decription = "Explore Rome and Athens, where two great civilizations sprang forth. Take a gondola through the canals of magical Venice, or soak in the spectacular views of whitewashed villages and ancient windmills from a seaside café on the isle of Mykonos. Relive the Renaissance in Florence, stroll the storied ruins of Ephesus, or visit the magnificent shrines of Istanbul. Cruises to the Mediterranean & Greek Isles will captivate you with timeless beauty.",
                    ImagePath = "Europe CRUISE.jpg",
                    UnitPrice = 1078.15,
                    CruiseID = 2
                },
                new Tour
                {
                    TourID = 4,
                    TourName = "HAWAIIAN CRUISES (Hawaiian Island)",
                    Decription = "Our 15-day Hawaiian Island cruises offer an intoxicating mix of island adventure and carefree cruising. You'll venture to four dazzling islands — including a full day and late evening in Honolulu to see the sights and experience its famed nightlife. And there’s so much to do while you’re at sea, like enjoying live entertainment, world-class cuisine, island-inspired activities and endless ocean views — plus it's all included in your cruise fare! Discover why the Travel Channel named us Best Cruises to see Hawaii.",
                    ImagePath = "hawaii-waterfall.jpg",
                    UnitPrice = 2098.60,
                    CruiseID = 1
                },
                new Tour
                {
                    TourID = 5,
                    TourName = "JAPANN CRUISES (SHIRETOKO PENINSULA)",
                    Decription = "Embark on a magical tour that leads you through the wilds of Japan's northernmost island, Hokkaido, where a variety of whales make their home and the verdant coastline is nothing short of spectacular.",
                    ImagePath = "3-7CW-Japan-640.jpg",
                    UnitPrice = 3659.15,
                    CruiseID = 1
                },
                new Tour
                {
                    TourID = 6,
                    TourName = "Panama Canal - Ocean to Ocean",
                    Decription = "A dream more than 400 years in the making, the Panama Canal opened in 1914 and this epic man-made marvel changed the world in the process. There's no better way to discover this colossal wonder than on a Panama Canal cruise. Sail between two mighty oceans or sail a partial transit roundtrip from Ft. Lauderdale, and discover why Condé Nast Traveler named it among its top Where To Go attractions. Expert narration will enlighten you as your ship passes through the locks, and you'll dine on authentic Panamanian cuisine. Ashore there is everything from Costa Rican rainforests to Old World cities like Cartagena that recall the Age of Exploration. Don't miss your chance to cruise the Panama Canal during its 100th anniversary celebration!",
                    ImagePath = "Panama Canal.jpg",
                    UnitPrice = 2286.15,
                    CruiseID = 1
                },
            };
            return Tours;
        }
    }
}