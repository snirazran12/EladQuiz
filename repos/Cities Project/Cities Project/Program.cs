using System;
using System.Collections.Generic;

namespace Cities_Project
{
    class Program
    {
        public static List<City> citiesList;
        public static void Main(string[] args)
        {
            citiesList = new List<City>();
            mainMenu();
        }

        public static void mainMenu()
        {
        Console.WriteLine("Type 1 for creating a city, \n 2 for creating a street, \n 3 for showing all cities, \n, 4 for showing all streets in a city");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                addCityToList();    
                break;
                case 2:
                addStreetToCity();
                break;
                case 3:
                showCities();
                break;
                showCityStreets();
                break;
            }
        }

        public static void addCityToList()
        {
            Console.WriteLine("Enter city name");
            string cityName = Console.ReadLine();
            City city = new City(cityName);
            citiesList.Add(city);
            Console.WriteLine("City Added Successefully");
            mainMenu();
        }

        public static void addStreetToCity()
        {
        Street street = null;
        Console.WriteLine("Enter street name");
        string streetName = Console.ReadLine();
        Console.WriteLine("Enter city Id");
        int cityId = int.Parse(Console.ReadLine());
            if (doesCityIdExist(cityId))
            {
                street = new Street(streetName, cityId);
            }
            else 
            {
             Console.WriteLine("Could not find such city. Type 1 for entering the values again, or 2 to mainMenu");
             int userInput = int.Parse(Console.ReadLine());
             if(userInput == 1)
                {
                    addStreetToCity();
                }
             else if(userInput == 2)
                {
                    mainMenu();
                }
            }
        }
        public static bool doesCityIdExist(int cityId)
        {
            foreach (City city in citiesList)
            {
                if (city.getCityId() == cityId)
                {
                    return true;
                }
            }
            return false;
        }

        public static void showCities()
        {
            foreach(City city in citiesList)
            {
                Console.WriteLine("name: "+ city.getCityName() + ", id:" + city.getCityId());
            }
            mainMenu();
        }

        public static void showCityStreets()
        {
            Console.WriteLine("Enter city Id");
            int cityId = int.Parse(Console.ReadLine());
                foreach(City city in citiesList)
                {
                if(city.getCityId() == cityId)
                {
                Console.WriteLine("name: " + city.getCityName() + ", id:" + city.getCityId());
                //invoke a method from city class, that will print the streets names 
                }
                mainMenu();
                }
           
        }
    }
}
