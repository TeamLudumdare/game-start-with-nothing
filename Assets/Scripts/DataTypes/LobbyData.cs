using System;
using System.Collections.Generic;

[Serializable]
public class LobbyData
{
    public int players;
    public string _id;
    public List<PlayerData> playersData;
    public PlayerData host;
}
