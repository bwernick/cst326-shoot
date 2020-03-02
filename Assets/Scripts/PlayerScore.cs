using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public static int playerScore;
    public static int highScore;
    private Text scoreText;
    private Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Transform child1 = transform.Find("Score");
        scoreText = child1.GetComponent<Text>();

        Transform child2 = transform.Find("High_Score");
        highScoreText = child2.GetComponent<Text>();

        //check & get saved high score, 0 as default value
        //Not working for some reason
        highScore = PlayerPrefs.GetInt("High Score", 0);
        playerScore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }

        scoreText.text = string.Format("Score\n{0:D4}", playerScore);
        highScoreText.text = string.Format("High Score\n{0:D4}", highScore);
    }
}
