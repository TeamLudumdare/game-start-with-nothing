using System;

[Serializable]
public class ActionData
{
    public PlayerData playerOrigin;
    public PlayerData playerTarget;
    public bool targetAll;
    public ItemData item;
    public String actionType;
    public string _id;
}
