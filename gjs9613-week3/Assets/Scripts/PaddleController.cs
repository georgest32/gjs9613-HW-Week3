using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameObject paddleRight;
    public GameObject paddleLeft;
    public GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            paddleLeft.transform.Rotate(new Vector3(0,0,45));
        }
        
        if (Input.GetKey(KeyCode.J))
        {
            paddleRight.transform.Rotate(new Vector3(0,0,45));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 250);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        }
    }
}
