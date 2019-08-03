using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform center;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(center.position, Vector3.up, 200 * Time.deltaTime);
	}
}
