using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCtrl : MonoBehaviour {
    public float Scroll_Speed = 2f;

    Material mt;

	// Use this for initialization
	void Start () {
        mt = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        float newOffsetX = mt.mainTextureOffset.x + Scroll_Speed * Time.deltaTime;

        Vector2 newOffset = new Vector2(newOffsetX,0);
        mt.mainTextureOffset = newOffset;
	}
}
