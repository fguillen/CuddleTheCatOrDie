using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPageController : MonoBehaviour
{
    [SerializeField] Toggle toggleShowInstructions;

    // Start is called before the first frame update
    void Start()
    {
        toggleShowInstructions.isOn = GetShowInstructions();
        toggleShowInstructions.onValueChanged.AddListener((_) => SetShowInstructions());
    }

    public void DeleteHighscores()
    {
        PlayerPrefs.DeleteKey("highscores");
    }

    void SetShowInstructions()
    {
        if(toggleShowInstructions.isOn)
        {
            PlayerPrefs.DeleteKey("instructionsShown");
        } else 
        {
            PlayerPrefs.SetInt("instructionsShown", 1);
        }
    }

    bool GetShowInstructions()
    {
        return (PlayerPrefs.GetInt("instructionsShown") != 1);
    }
}
