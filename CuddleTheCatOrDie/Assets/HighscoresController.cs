using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class HighscoresController : MonoBehaviour
{
    List<int> highscores;
    [SerializeField] TextMeshProUGUI highscoreListText;

    // Start is called before the first frame update
    void Awake()
    {
        LoadHighscores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadHighscores()
    {
        highscores = DeserializeHighscores();

        string highscoresText = "";

        foreach (var highscore in highscores)
        {
            if(highscoresText != "")
            {
                highscoresText += "\n";
            }

            highscoresText += highscore + " cats cuddled";    
        }

        if(highscoresText == "")
        {
            highscoresText += "Not any highscore yet!";
        }

        highscoreListText.text = highscoresText;
    }

    void SaveHighscores()
    {
        PlayerPrefs.SetString("highscores", SerializeHighscores(highscores));
    }

    List<int> DeserializeHighscores()
    {
        List<int> result = new List<int>();

        string highscoresString = PlayerPrefs.GetString("highscores");

        // return empty List if no highscores found
        if(highscoresString == "")
        {
            return result;
        }

        string[] highscoresStrings = highscoresString.Split(',');

        foreach(string highscoreString in highscoresStrings)
        {
            result.Add(Int32.Parse(highscoreString));
        }

        return result;
    }

    string SerializeHighscores(List<int> highscores)
    {
        return string.Join(",", highscores);
    }

    List<int> GetHighscores()
    {
        return highscores;
    }
}
