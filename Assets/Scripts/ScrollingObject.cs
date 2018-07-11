﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameMaster.instance.scrollSpeed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameMaster.instance.gameOver == true) {
            rb2d.velocity = Vector2.zero;
        }
	}
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.GetComponent<Player>() != null) {
            
            GameMaster.instance.Scoring();
        }
    }
}