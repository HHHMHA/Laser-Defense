using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        SetupSingleton();
    }

    private void SetupSingleton() {
        if ( FindObjectsOfType<MusicPlayer>().Length == 1 )
            DontDestroyOnLoad( gameObject );
        else
            Destroy( gameObject );
    }
}
