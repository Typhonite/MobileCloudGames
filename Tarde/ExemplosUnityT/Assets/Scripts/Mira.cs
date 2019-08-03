using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    Vector3 posInWorld;
    Vector3 posInScreen;
    public Transform target;
    public Camera cam;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //transform.Translate(Vector3.right * Time.deltaTime);
        posInWorld = cam.WorldToScreenPoint(target.position);
        posInWorld.x = Mathf.Clamp(posInWorld.x, 22.8f, Screen.width);
        posInWorld.y = Mathf.Clamp(posInWorld.y, 20.0f, Screen.height);

        posInScreen = cam.ScreenToWorldPoint(posInWorld);
        target.position = posInScreen;
        print("Position in world coordinates is " + posInWorld);
    }
}
