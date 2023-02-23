using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class UITestScript : MonoBehaviour
{
    public TMP_InputField testInput;
    public TMP_Text testText;
    public TestPlayer player;
    public PlayerData playerData;

    public void TestInputSave() {
        testText.text = testInput.text;
    }
    public void SaveTest() {
        player.level = Int32.Parse(testText.text);
        SaveLoadSystem.SavePlayer(player);
    }
    public void Load() {
        player.level = SaveLoadSystem.loadPLayer().level;
        testText.text = player.level.ToString();
    }
}
