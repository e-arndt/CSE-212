public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
    public Geometry Geometry { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }
}

public class Geometry
{
    public List<double> Coordinates { get; set; }
}