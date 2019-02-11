using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider_Script : MonoBehaviour {

    private LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D colider) 
    {
        levelManager.LoadLevel("Lose");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
