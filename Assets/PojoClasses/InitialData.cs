using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialData
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    
}
public class Result
{
    public string option { get; set; }
    public string value { get; set; }
    public string image { get; set; }
}