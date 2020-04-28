using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScritp : MonoBehaviour
{
    public int shots;
    public int hits;

    public void Restart()
    {
        SceneManager.LoadScene("Map2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }



}

