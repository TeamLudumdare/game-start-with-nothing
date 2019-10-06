using System;
using System.Collections.Generic;

[Serializable]
public class MatchData
{
    public List<PlayerData> players;
    public String room;
    public List<RoundData> rounds;
    public string _id;
}
