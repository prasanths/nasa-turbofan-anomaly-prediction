namespace AnomalyPredictor.Options{

public class ApiSettings{
    public const string Apis = "Apis";
    public Anomaly Anomaly {get; set;}
}

public class Anomaly{
    public string BaseUrl {get; set;}
}}
