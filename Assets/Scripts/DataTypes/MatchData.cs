using System;
using System.Collections.Generic;

[Serializable]
public class MatchData
{
    public PlayerData[] players;
    public String room;
    public RoundData[] rounds;
    public string _id;
}
