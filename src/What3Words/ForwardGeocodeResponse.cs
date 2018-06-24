namespace What3Words
{

    public class ForwardGeocodeResponse
    {
        public Crs crs { get; set; }
        public string words { get; set; }
        public Bounds bounds { get; set; }
        public Geometry geometry { get; set; }
        public string language { get; set; }
        public string map { get; set; }
        public Status status { get; set; }
        public string thanks { get; set; }
    }

    public class Crs
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string href { get; set; }
        public string type { get; set; }
    }

    public class Bounds
    {
        public Southwest southwest { get; set; }
        public Northeast northeast { get; set; }
    }

    public class Southwest
    {
        public float lng { get; set; }
        public float lat { get; set; }
    }

    public class Northeast
    {
        public float lng { get; set; }
        public float lat { get; set; }
    }

    public class Geometry
    {
        public float lng { get; set; }
        public float lat { get; set; }
    }

    public class Status
    {
        public int code { get; set; }
        public string message { get; set; }
    }

}
