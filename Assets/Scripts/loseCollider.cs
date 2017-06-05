using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseCollider : MonoBehaviour {

    private levelManager levelmanager;   

    private void Start()
    {
        levelmanager = GameObject.FindObjectOfType<levelManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Brick.breakableCount = 0;
        levelmanager.LoadLevel("Lose");
    }
}
