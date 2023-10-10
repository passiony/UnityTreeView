using System;

[Serializable]
public class TreeData
{
    public string Name;
    public SubData[] Childs;
}

[Serializable]
public class SubData
{
    public string Title;
    public string Content;
    public string Logo;
    public string Url;
}


