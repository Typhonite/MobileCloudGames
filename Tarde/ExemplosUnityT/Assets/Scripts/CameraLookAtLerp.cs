using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtLerp : MonoBehaviour {

    public Transform target;
    public float speed = 0.5f;

    void Update()
    {
        Quaternion rotacaoAtual = transform.rotation;
        transform.LookAt(target);
        Quaternion novaRotacao = transform.rotation;
        transform.rotation = Quaternion.Lerp(rotacaoAtual, novaRotacao, speed * Time.deltaTime);
    }
}
