using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public string Name;
    public int Score;
}

public class ListData
{
    public List<UserData> Users;
}
