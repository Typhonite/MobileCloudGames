using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch toque = Input.GetTouch(0);

            // Como recuperar a posicao da tela
            Debug.Log("Posicao: " + toque.position);

            switch (toque.phase)
            {
                case TouchPhase.Began: // inicio do toque (primeiro quadro)
                    break;
                case TouchPhase.Moved: // caso tenha ocorrido do "deslizar" pela tela
                    break;
                case TouchPhase.Stationary: // caso o toque não tenha de deslocado
                    break;
                case TouchPhase.Ended: // fim do toque (primeiro quadro sem toque)
                    break;
                case TouchPhase.Canceled: // cancelado pelo sistema (excesso de toques)
                    break;
                default:
                    break;
            }

            // diferenca da posicao entre os toques (ultimoQuadro - quadroAtual)
            Debug.Log("Diferenca entre as posicoes: " + toque.deltaPosition);

            // quantidade de toques sucessivos
            Debug.Log("Quantos toques foram dados: " + toque.tapCount);



            // Recuperando varios toques ao mesmo tempo (Ex: zoom)
            Touch[] meuToques = Input.touches;


            foreach (Touch t in meuToques)
            {
                Debug.Log("Touch: " + t.fingerId + ", position: " + t.position);
            }

        }
    }
}
