using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPLay = false;
    private Ball ball;
	
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
		
	void Update () {
        if (!autoPLay)
        {
            moveWithMouse();
        }
        else
        {
            autoPlay();
        }
        
	}

    void moveWithMouse()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.75f, 15.25f);
        this.transform.position = paddlePos;
    }

    void autoPlay()
    {
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.75f, 15.25f);
        this.transform.position = paddlePos;
    }
}
