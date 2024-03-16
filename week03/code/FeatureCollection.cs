using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.Versioning;

public class FeatureCollection {
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public Feature[] features { get; set; } 
    
}
public class Feature {
    public Properties properties { get; set; }
}
public class Properties {
    public string place { get; set; }
    public decimal mag { get; set; }
    public long time { get; set; }
}
