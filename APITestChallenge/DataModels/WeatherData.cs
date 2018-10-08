using System.Collections.Generic;

namespace APITestChallenge.DataModels
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class WeatherMultipleCities
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public double Pressure { get; set; }
        public double SeaLevel { get; set; }
        public double GrndLevel { get; set; }
        public double Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
        public int Today { get; set; }
    }

    public class Sys
    {
        public double Type { get; set; }
        public double Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public double Sunrise { get; set; }
        public double Sunset { get; set; }
    }

    public class WeatherData
    {
        public Coord Coord { get; set; }
        public IList<WeatherMultipleCities> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public double Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public double Dt { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}