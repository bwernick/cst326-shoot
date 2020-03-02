using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bullet;
    public float speed = 5;
  
    // Start is called before the first frame update
    void Start()
    {
      bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * speed; 
        Debug.Log("Wwweeeeee");
        
        if(bullet.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy_1")
        {
            //kill enemy
            Destroy(other.gameObject);
            //destroy bullet
            Destroy(gameObject);
            PlayerScore.playerScore += 10;
            Debug.Log("Enemy_1 killed");
        }

        if (other.gameObject.tag == "Enemy_2")
        {
            //kill enemy
            Destroy(other.gameObject);
            //destroy bullet
            Destroy(gameObject);
            PlayerScore.playerScore += 20;

        }

        if (other.gameObject.tag == "Enemy_3")
        {
            //kill enemy
            Destroy(other.gameObject);
            //destroy bullet
            Destroy(gameObject);
            PlayerScore.playerScore += 30;

        }

        if (other.gameObject.tag == "Enemy_4")
        {
            //kill enemy
            Destroy(other.gameObject);
            //destroy bullet
            Destroy(gameObject);
            PlayerScore.playerScore += 40;

        }

        if (other.gameObject.tag == "Base")
        {
            //destroy bullet
            Destroy(gameObject);
            //lower base health
            other.gameObject.GetComponent<Base>().health -= 0.5f;
        }
    }
}
