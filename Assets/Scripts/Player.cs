using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public Transform shottingOffset;
    private Transform player;
    public float speed, maxBound, minBound;

    public float fireRate;
    private float nextFire;

    Animator anim;

    void Start()
    {
        player = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        //Prevent player from leaving screen bounds
        if (player.position.x < minBound && h < 0)
        {
            h = 0;
        }
        if (player.position.x > maxBound && h > 0)
        {
            h = 0;
        }

        //player movement
        player.position += Vector3.right * h * speed;

        //shooting & attempt at limiting fire rate
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shottingOffset.position, shottingOffset.rotation);
            Debug.Log("Bang!");
            anim.SetTrigger("shoot");
        }

    }
}
