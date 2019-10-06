using System;
using System.Collections.Generic;

[Serializable]
public class RoundLogData
{
    public List<PlayerData> playersRead;
    public List<ActionData> actions;
    public string _id;
}
