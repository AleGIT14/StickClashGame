using System;

public class Ranking
{
    public string name { get; set; }
    public int totalPoints { get; set; }

    public Ranking(string name, int totalPoints)
    {
        this.name = name;
        this.totalPoints = totalPoints;
    }

}
