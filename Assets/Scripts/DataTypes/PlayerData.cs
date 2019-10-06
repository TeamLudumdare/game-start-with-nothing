using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
    public int lifePoints;
    public string _id;
    public string name;
    public bool alive;
    public List<ItemData> items;
}
