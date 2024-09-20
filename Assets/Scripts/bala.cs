using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad = 20f; // velocidad de la bala
    void Start()
    {
        Destroy(gameObject, 3); // destruimos el objeto 3 sec despues de llamarlo(rendimiento)
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * velocidad; // movimiento de la bala nada mas ser creada
    }
}
