using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public Text text;
    public float TimeLeft;
    
    void Start()
    {
        text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        text.text = "TIME LEFT : " + Mathf.Round(TimeLeft);
        if (TimeLeft <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("TimeUp");
        }
    }
}
