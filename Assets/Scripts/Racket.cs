using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour {

    public float speed = 150;

    void FixedUpdate()
    {
        //Get horizontal input
        float h = Input.GetAxisRaw("Horizontal");
        //Set velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
}
