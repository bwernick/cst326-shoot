using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameOver.isPlayerDead = false;
            Time.timeScale = 1;
            //reset score just in case
            PlayerScore.playerScore = 0;
            //not working for some reason
            PlayerPrefs.SetInt("High Score", PlayerScore.highScore);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
