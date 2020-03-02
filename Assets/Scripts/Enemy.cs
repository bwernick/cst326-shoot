using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform EnemyHolder;
    public float speed;
    public GameObject shot;
    public Text WinText;
    public float fireRate;

    void Start()
    {
        WinText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        EnemyHolder = GetComponent<Transform>();
    }

    void MoveEnemy()
    {
        //move all enemies
        EnemyHolder.position += Vector3.right * speed;

        //loop through child objects
        foreach(Transform enemy in EnemyHolder)
        {
            if(enemy.position.x <= -10.5 || enemy.position.x >= 10.5)
            {
                //reverse movement
                speed = -speed;
                //move down at end of left/right movement
                EnemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            //enemy bullets randomly fire
            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            //game over condition when enemies reach bases
            if (enemy.position.y <= 0.5)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        //less than 4 left, go faster
        if (EnemyHolder.childCount <= 4)
        {
            CancelInvoke();
            //slightly faster
            InvokeRepeating("MoveEnemy", 0.1f, 0.28f);
        }


        //one left, go fast
        if (EnemyHolder.childCount == 1)
        {
            CancelInvoke();
            //fastest
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        //none left, you win
        if (EnemyHolder.childCount == 0)
        {
            WinText.enabled = true;
        }

    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
    }
}
