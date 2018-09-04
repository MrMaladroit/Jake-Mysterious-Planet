﻿using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.instance.Kill();
        }
    }

}