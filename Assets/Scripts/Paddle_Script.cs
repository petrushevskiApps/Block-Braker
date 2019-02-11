using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Script : MonoBehaviour {

    // Use this for initialization
    public bool autoPlay = false;

    private Ball_Script ball;

    Vector3 paddlePosition;

    void Start ()
    {
        paddlePosition = new Vector3(0f, this.transform.position.y, 0f);
        ball = GameObject.FindObjectOfType<Ball_Script>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!autoPlay) MoveWithMouse();
        else
        {
            AutoPlay();
        }
    }
    void AutoPlay()
    {
        // mouse_position = Input.mousePosition.x / Screen.width * 16;
        
        Vector3 ballPosition = ball.transform.position;
        paddlePosition.x = Mathf.Clamp(ballPosition.x, -12.5f, 12.5f);
        this.transform.position = paddlePosition;
    }
    void MoveWithMouse()
    {
        float mouse_position = Input.mousePosition.x / Screen.width * 25;
        paddlePosition.x = Mathf.Clamp(mouse_position - 12.5f, -11.5f, 11.5f);
        this.transform.position = paddlePosition;
    }
}
