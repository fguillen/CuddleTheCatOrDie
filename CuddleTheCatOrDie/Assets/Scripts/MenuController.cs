using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        print("Quiting game");
        Application.Quit();
    }
}
