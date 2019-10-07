using System;
using System.Collections.Generic;

[Serializable]
public class TurnData
{
    public int turn;
    public PlayerData player;
    public ActionData[] actions;
    public string _id;
}
