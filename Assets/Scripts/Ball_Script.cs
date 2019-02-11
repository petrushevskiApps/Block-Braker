using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour {

    private Paddle_Script paddle;
    private Vector3 paddleToBallVector;
    bool is_started = false;
    AudioSource audio;
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 1;
        paddle = GameObject.FindObjectOfType<Paddle_Script>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 tweak = new Vector2(Random.Range(-0.1f, 0.4f), Random.Range(-0.1f, 0.4f));
        if (is_started)
        {
            //print(tweak);
            //GetComponent<Rigidbody2D>().velocity += tweak;
            audio.Play();
        }
    }
    // Update is called once per frame
    void Update ()
    {
        if (!is_started)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                is_started = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
        

	}
}
