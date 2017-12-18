using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score = 0;
    public Text text;
    public Transform block;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Score:" + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
    }

}
