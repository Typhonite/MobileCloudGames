using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool estaApertado = false;

	public virtual void OnPointerDown(PointerEventData ped)
    {
        estaApertado = true;
        Debug.Log("Tap: (position: " + ped.position +")");
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        estaApertado = false;
        Debug.Log("DisTap");
    }

    void Update()
    {
        if (estaApertado)
            Debug.Log("Apertado");
    }

}
