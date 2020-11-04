using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField] private float scrollSpeed = 0.2f;
    [SerializeField] Material material;
    Vector2 offset;

    void Start() {
        material = GetComponent<Renderer>().material;
        offset = new Vector2( 0f, scrollSpeed );
    }

    // Update is called once per frame
    void Update() {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
