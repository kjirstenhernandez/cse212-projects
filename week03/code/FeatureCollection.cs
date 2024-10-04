public class FeatureCollection
{

    public Feature[] Features { get; set; }

}
public class Feature {
    public string Id { get; set; }
    public Description Properties { get; set; }
}

public class Description {
    public long Time { get; set; }
    public float Mag { get; set; }
    public string Place {get; set; }
    public string Title { get; set; }

}