using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Animator anim = other.gameObject.GetComponent<Animator>();
            anim.SetTrigger("death");
            Destroy(other.gameObject, anim.GetCurrentAnimatorStateInfo(0).length + 0.2f);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
            //Time.timeScale = 0;
        }
        else if(other.tag == "Base")
        {
            //destroy bullet
            Destroy(gameObject);
            //lower base health
            other.gameObject.GetComponent<Base>().health -= 0.5f;
        }
    }
}
