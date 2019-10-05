using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class LobbyData
{
    public int players;
    public string id;
    public List<PlayerData> playersData;
    public PlayerData host;
}
