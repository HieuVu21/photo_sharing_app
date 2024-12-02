using System;
using System.Collections.Generic;

public class GameData
{
    public bool isNewLoad;
    public int highScore;
    public float MusicVolume;
    public float SFXVolume;
    public List<ScoreEntry> scores = new List<ScoreEntry>(); // Bổ sung danh sách scores
    public List<int> list = new List<int>();
}

[System.Serializable]
public class ScoreEntry
{
    public int score;
    public string time;
    public string dateTimeString;

    public ScoreEntry(int score, string time, string dateTimeString)
    {
        this.score = score;
        this.time = time;
        this.dateTimeString = dateTimeString;
    }
}