using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NotesInfo
{
    public float timing; //出現するタイミング(秒)
}

[System.Serializable]
public class NotesPattern
{
    public string patternName;//技名
    public List<NotesInfo> notes = new List<NotesInfo>();
}

[System.Serializable]
public class PatternCategory {
    public string categoryName;
    public List<NotesPattern> patterns = new List<NotesPattern>();
}