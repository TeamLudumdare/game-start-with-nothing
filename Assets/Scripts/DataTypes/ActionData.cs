using System;

[Serializable]
public class ActionData
{
    public PlayerData playerOrigin;
    public PlayerData playerTarget;
    public bool targetAll;
    public String actionType;
}
