using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerPrizeDecide 
{
    // Start is called before the first frame update
    public string code { get; set; }
    public string prize { get; set; }
    public string value { get; set; }
    public Game game { get; set; }
}
public class Game
{
    public int id { get; set; }
    public string name { get; set; }
    public string telegramUrl { get; set; }
    public int bot { get; set; }
    public int distributor { get; set; }
}