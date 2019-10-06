using System;
using System.Collections.Generic;

[Serializable]
public class LobbyData
{
    public int players;
    public List<PlayerData> playersData;
    public PlayerData host;
    public string _id;
}
