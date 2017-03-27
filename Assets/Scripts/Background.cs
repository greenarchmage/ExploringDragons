using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
  
	// Use this for initialization
	void Start () {
        // scales the background to the size of the game
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        transform.localScale = new Vector3(horzExtent*2, vertExtent*2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
