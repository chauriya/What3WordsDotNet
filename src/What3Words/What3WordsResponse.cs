namespace What3Words
{
    public class What3WordsResponse
    {
        public string Country { get; set; }
        public Square Square { get; set; }
        public string NearestPlace { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Words { get; set; }
        public string Language { get; set; }
        public string Map { get; set; }

        public override string ToString()
        {
            var wordArray = Words.Split('.');
            return $"{wordArray[0]}.{wordArray[1]}.{wordArray[2]}";
        }
    }

    public class Square
    {
        public Southwest Southwest { get; set; }
        public Northeast Northeast { get; set; }
    }

    public class Southwest
    {
        public float Lng { get; set; }
        public float Lat { get; set; }
    }

    public class Northeast
    {
        public float Lng { get; set; }
        public float Lat { get; set; }
    }

    public class Coordinates
    {
        public double Lng { get; set; }
        public double Lat { get; set; }
    }
}
