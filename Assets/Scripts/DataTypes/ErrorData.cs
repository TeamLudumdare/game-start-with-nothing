using System;
using System.Collections.Generic;

[Serializable]
public class ErrorData
{
    public int players;
    public string _id;
    public PlayerData[] playersData;
    public PlayerData host;
}
