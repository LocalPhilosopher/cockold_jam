using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//example info class
// public class HeroInfo
// {
//     public string name;
//     public IntInfo Level;
//     public IntInfo IsBought;
//     public IntInfo EquipIndex;
//     public IntInfo BoughtLevel;
//     public IntInfo BalloonFirstShowed;
//     public IntInfo AdWatched;
//     public IntInfo TimerOn;
//     public IntInfo ForceToShowProposal;
//     public IntInfo AdViewsCount;
//     
//     public HeroInfo(string name)
//     {
//         this.name = name;
//         Level = new IntInfo(name + "Level", 1); 
//         IsBought = new IntInfo(name + "Bought", 0); 
//         EquipIndex = new IntInfo(name + "EquipIndex", -1);
//         BoughtLevel = new IntInfo(name + "BoughtLevel", -1);      
//         BalloonFirstShowed = new IntInfo(name + "BalloonFirstShowed", 0);
//         AdWatched = new IntInfo(name + "AdWatched", 0);
//         TimerOn = new IntInfo(name + "TimerOn", 0); 
//         ForceToShowProposal = new IntInfo("G_"+name + "ForceToShowProposal", 0);
//         AdViewsCount = new IntInfo(name + "AdViewsCount", 2);
//     }
// }


public class LevelInfo
{
    public  IntInfo score;
    public IntInfo grade;
    public LevelInfo(int index)
    {
        grade = new IntInfo("Level_Grade_" + index, -1);
        score = new IntInfo("Level_Score_" + index, 0);
        // score = new IntInfo()
        // this.index = index;
    }
}

public class TrainInfo
{
    public string trainName;
    public IntInfo IsBought;
    public IntInfo RewardCount;
    public TrainInfo(string name)
    {
        trainName = name;
        IsBought = new IntInfo(name + "Bought", 0); 
        RewardCount = new IntInfo(name + "RewardCount", 0); 
        // trainName = new StringInfo("Train_Name", );
    }
}
public static class PlayerInfo
{
    
    public static IntInfo Money = new IntInfo("G_Money", 0);
    public static StringInfo CurrentTrain = new StringInfo("G_CurrentTrain", "");
    public static IntInfo DiesCount = new IntInfo("DiesCount", 0);
    public static List<LevelInfo> Levels = new List<LevelInfo>();
    public static IntInfo SmashRoadSigns = new IntInfo("G_SmashRoadSigns", 0);
    public static IntInfo SmashPlayers = new IntInfo("G_SmashPlayers", 0);
    public static IntInfo CurrentLevel = new IntInfo("G_CurrentLevel", 0);
    public static IntInfo StatWithLevelScreen = new IntInfo("StatWithLevelScreen", 0);
    public static IntInfo TutorComplete = new IntInfo("TutorialCompleted", 0);
    public static Dictionary<string, TrainInfo> Trains = new Dictionary<string, TrainInfo>();
    public static IntInfo MoneyPopupTime = new IntInfo("NewPopupTime", 0);
    public static IntInfo SoundOn = new IntInfo("SoundOn", 1);
    public static bool LevelFinished => PlayerInfo.Levels[PlayerInfo.CurrentLevel.Value].grade.Value != -1;
}
