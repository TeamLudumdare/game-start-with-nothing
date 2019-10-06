using System;
using System.Collections.Generic;

[Serializable]
public class RoundLogData
{
    public List<PlayerData> playersRead;
    public List<ActionLogData> actions;
    public string _id;
}
