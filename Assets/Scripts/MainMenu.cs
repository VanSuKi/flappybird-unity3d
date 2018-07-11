using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) { StartGame(); }    
    }

    public void StartGame() {

        SceneManager.LoadScene("Main");
    }

    public void OnApplicationQuit() {
        Application.Quit();
    }
}
