namespace What3Words
{
    public class What3WordsResponse
    {
        public Crs Crs { get; set; }
        public string Words { get; set; }
        public Bounds Bounds { get; set; }
        public Geometry Geometry { get; set; }
        public string Language { get; set; }
        public string Map { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            var wordArray = Words.Split('.');
            return $"{wordArray[0]}.{wordArray[1]}.{wordArray[2]}";
        }
    }

    public class Crs
    {
        public string Type { get; set; }
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Href { get; set; }
        public string Type { get; set; }
    }

    public class Bounds
    {
        public Southwest Southwest { get; set; }
        public Northeast Northeast { get; set; }
    }

    public class Southwest
    {
        public double Lng { get; set; }
        public double Lat { get; set; }
    }

    public class Northeast
    {
        public double Lng { get; set; }
        public double Lat { get; set; }
    }

    public class Geometry
    {
        public double Lng { get; set; }
        public double Lat { get; set; }
    }

    public class Status
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
