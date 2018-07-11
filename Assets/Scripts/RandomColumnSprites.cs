using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColumnSprites : MonoBehaviour {
    public GameObject columnSprite;
    public GameObject columnXY;
    
    
    private float lastColumn;
    private GameObject insColumn;
	// Use this for initialization
	void Start () {
        //insColumn = (GameObject)Instantiate(columnSprite, new Vector3(transform.position.x, Random.Range(-2f, -6f), 0), Quaternion.identity);
        RandomSpawn();
        insColumn.transform.parent = gameObject.transform;
    }
	
	void Update () {
        if(gameObject.transform.GetChild(0).position.x < -20) {
            Destroy(gameObject.transform.GetChild(0).transform.gameObject);
        }

        lastColumn = insColumn.transform.position.x;
        //Debug.Log(lastColumn);
        if ((transform.position.x - lastColumn) > Random.Range(7f, 14f)) {
            RandomSpawn();
            insColumn.transform.parent = gameObject.transform;
        }

    }
    void RandomSpawn() {
        int draw = Random.Range(1, 4);
        switch (draw) {
            case 1:
                insColumn = (GameObject)Instantiate(columnSprite, new Vector3(transform.position.x, Random.Range(-2.5f, -5f), 0), Quaternion.identity);
                break;
            case 2:
                insColumn = (GameObject)Instantiate(columnSprite, new Vector3(transform.position.x, Random.Range(5f, 7f), 0), Quaternion.Euler(new Vector3(0,0,180)));
                insColumn.GetComponent<BoxCollider2D>().offset = new Vector2(-1f, 7f);
                break;
            case 3:
                insColumn = (GameObject)Instantiate(columnXY, new Vector3(transform.position.x, Random.Range(0, -2f), 0), Quaternion.identity);
                break;
        }
    }

    
}
