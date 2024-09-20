using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public int puntaje = 0;
    public bool pausa = false;
    void Start()
    {
        
    }
    void Update()
    {
        puntaje = Mathf.Clamp(puntaje,0, 100000); // limitamos el puntaje para que no sea negativo
        if (!pausa)
        {
            GetComponent<TextMeshProUGUI>().text = new string("score: " + puntaje.ToString()); // mostramos el puntaje
        }
        else {
            GetComponent<TextMeshProUGUI>().text = new string("PAUSA");
        } // cuando esta pausado muestra pausa en pantalla
        // escape para parar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Time.timeScale = 1.0f; // dejamos que el tiempo siga su curso normal
                pausa = false;
            }
            else
            {
                Time.timeScale = 0.0f; // paramos el tiempo
                pausa=true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
