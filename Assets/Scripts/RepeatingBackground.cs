using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    
    // Use this for initialization
    void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
        
        //Debug.Log(groundHorizontalLength);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < -groundHorizontalLength) {
            RepositionBackgroud();
            
        }
        
        //Debug.Log(transform.position);
    }

    void RepositionBackgroud() {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2, 0);
        transform.position = (Vector2)transform.position + groundOffset;
        
    }
    
}
