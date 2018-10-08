using System.Collections.Generic;

namespace APITestChallenge.DataModels
{
    public class List
    {
        public int Id { get; set; }
        public int Dt { get; set; }
        public string Name { get; set; }
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public object Rain { get; set; }
        public object Snow { get; set; }
        public Clouds Clouds { get; set; }
        public IList<WeatherMultipleCities> Weather { get; set; }
    }

    public class CitiesInRectangleZone

    {
        public int Cod { get; set; }
        public double Calctime { get; set; }
        public int Cnt { get; set; }
        public IList<List> List { get; set; }
    }
}