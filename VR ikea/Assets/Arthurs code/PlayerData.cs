using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    public int level;
    public float[] HighScores;

    public PlayerData(TestPlayer player) {
        level = player.level;
        HighScores = player.highScores;
    }

}

