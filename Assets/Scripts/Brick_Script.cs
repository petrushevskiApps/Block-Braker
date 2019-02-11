using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick_Script : MonoBehaviour {

    public AudioClip crack;
    public static int brickCount;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    bool isBreakable;

    private int maxHits;
    public int timesHit;
	// Use this for initialization
	void Start ()
    {

        isBreakable = (this.tag == "Brakeable");
        if(isBreakable)
        {
            brickCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 5f);
        if(isBreakable)
        {
            HandleHits();
        }
    }
    void HandleHits()
    {
        

        timesHit++;
        if (timesHit >= hitSprites.Length + 1)
        {
            brickCount--;
            print(brickCount);
            Destroy(gameObject);
            if (brickCount == 0) SimulateWin();
            
        }
        else
        {
            LoadSprites();
        }
    }
    private void LoadSprites()
    {
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit-1];
    }

    void SimulateWin()
    {
        print(brickCount);
        brickCount = 0;
        levelManager.LoadNextLevel();
    }
    // Update is called once per frame
    void Update ()
    {
        
        
	}
}
