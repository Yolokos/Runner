using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour {

    public Transform[] backgrounds;
    private float parallaxScales;
    public float smoothing;


    private Vector3 previousCameraPosition;
	// Use this for initialization
	void Start () {
        previousCameraPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
