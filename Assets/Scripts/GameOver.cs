using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead = false;
    private Text gameOver;
    private bool creditsCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDead)
        {
            //prevents repeated calls which can cause errors
            if (!creditsCalled)
            {
                Invoke("GameOverFunc", 0f);
                creditsCalled = true;
            }
        }
    }

    void GameOverFunc()
    {
        //effectivly pause game
        //Time.timeScale = 0;
        //display game over text
        gameOver.enabled = true;
        PlayerScore.playerScore = 0;

        Invoke("DelayedCredits", 2f);
    }

    void DelayedCredits()
    {
        isPlayerDead = false;
        gameOver.enabled = !gameOver.enabled;
        SceneManager.LoadScene("Credits");
    }
}
