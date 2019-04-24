using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScale : MonoBehaviour {
    public float scale = 1f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(scale, scale, scale);
    }
    public void sizeAdjust(float size)
    {
        scale = size;
    }
}
