using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private void Awake() {
        DontDestroyOnLoad( gameObject );
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene( "Game Over" );
    }    
    
    public void LoadStartMenuScene() {
        SceneManager.LoadScene( 0 );
    }

    public void LoadGameScene() {
        SceneManager.LoadScene( "Game" );
    }

    public void QuitGame() {
        Application.Quit();
    }
}
