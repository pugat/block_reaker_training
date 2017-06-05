using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    public Rigidbody2D rb;
    public AudioSource sg;
    private bool hasStarted = false;
	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;       
    }
	
	// Update is called once per frame
	void Update () {
        //Lock ball to the paddle until click.
        if (!hasStarted)
        {           
            this.transform.position = paddle.transform.position + paddleToBallVector;
            if (Input.GetMouseButtonDown(0))
            {
                sg = GetComponent<AudioSource>();
                sg.Play();
                hasStarted = true;
                rb = GetComponent<Rigidbody2D>();                
                rb.velocity = new Vector2(2f, 10f);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.4f),Random.Range(0f,0.4f));
        sg = GetComponent<AudioSource>();
        if (hasStarted) {
            sg.Play();
            rb = GetComponent<Rigidbody2D>();
            rb.velocity += tweak;
        }
        
    }
}
