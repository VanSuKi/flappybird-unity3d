using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public GameObject gameOverTxt;
    public Text scoringTxt;
    public Text countDownTxt;
    public bool gameOver = false;
    public static GameMaster instance;
    public float scrollSpeed = -1.5f;
    public float countdown;
    private bool isPause = true;

    // Use this for initialization

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start () {
        Time.timeScale = 0;
        countDownTxt.enabled = true;
        
    }
    
	void Update () {
        if (isPause) {
            countdown -= Time.unscaledDeltaTime;
            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            countDownTxt.text = string.Format("{0:0}", countdown);
            if (countdown <= 0) {
                Time.timeScale = 1;
                isPause = false;
                countDownTxt.enabled = false;
            }
        }
		if(gameOver==true && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))) {
            RestartGame();
            
        }

    }

    public void BirdDied() {
        gameOverTxt.SetActive(true);
        gameOver = true;
    }

    public void RestartGame() {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

    public void Scoring() {
        if (gameOver) return;
        Player.scores += 1;
        scoringTxt.text = "SCORE: " + Player.scores.ToString();
    }
}
