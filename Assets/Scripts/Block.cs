using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy block
        Destroy(gameObject);
        score++;
    }
}
