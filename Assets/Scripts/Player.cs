using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rigidSprite;
    public float jumpVelocity;
    private float force = 200f;
    private bool isDead = false;
    private Animator anim;
    public bool isImmortal = false;

    public static int scores;
    public int startScore = 0;
   
	// Use this for initialization
	void Start () {
        scores = startScore;
        if (isImmortal) {
            Collider2D col = transform.GetComponent<Collider2D>();
            col.enabled = false;
        }
        rigidSprite = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //rigidSprite.gravityScale = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector2.right * movementSpeed * Time.deltaTime, Space.World);
        if (!isDead) {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                rigidSprite.velocity = new Vector2(0, jumpVelocity);
                rigidSprite.AddForce(new Vector2(0, force));
                anim.SetTrigger("Flap");
            }
        }

    }

    void OnCollisionEnter2D() {
        isDead = true;
        anim.SetTrigger("Die");
        GameMaster.instance.BirdDied();
        rigidSprite.velocity = Vector2.zero;
    }
    
}
