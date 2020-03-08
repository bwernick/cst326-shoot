﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Start Game");
            SceneManager.LoadScene("Game");
        }

    }
}
