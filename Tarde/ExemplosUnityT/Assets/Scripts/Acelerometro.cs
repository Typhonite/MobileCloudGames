using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        float x = Input.acceleration.x;
        float z = -Input.acceleration.z;

        transform.Translate(x, 0, z);
	}
}
