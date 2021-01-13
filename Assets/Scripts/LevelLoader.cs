using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    private void Awake() {
        DontDestroyOnLoad( gameObject );
    }

    public void LoadGameOverScene() {
        LoadScene( "Game Over", 1f );
    }    
    
    public void LoadStartMenuScene() {
        SceneManager.LoadScene( 0 );
    }

    public void LoadGameScene() {
        SceneManager.LoadScene( "Game" );
    }

    private void LoadScene( String sceneName, float delaySeconds ) {
        StartCoroutine( LoadSceneWithDelay() );
        IEnumerator LoadSceneWithDelay() {
            yield return new WaitForSeconds( delaySeconds );
            SceneManager.LoadScene( sceneName );
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}
