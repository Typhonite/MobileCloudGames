using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAccelerometer : MonoBehaviour
{
    private Quaternion localRotation; // controle local da rotacao
    public float velocidade = 1.0f;

    // Use this for initialization
    void Start()
    {
        // ajustando a rotacao inicial do objeto com o controle local
        localRotation = transform.rotation;
    }


    void Update()
    {
        // velocidade considerando o deltaTime
        float velocidadeAtual = Time.deltaTime * velocidade;

        // primeiro atualize o controle interno de acordo com o input do acelerometro
        localRotation.y += Input.acceleration.x * velocidadeAtual;
        //localRotation.x += Input.acceleration.y * velocidadeAtual;

        // rotacionar o objeto conforme o novo angulo
        transform.rotation = localRotation;
    }
}
