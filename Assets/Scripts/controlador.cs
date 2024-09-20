using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    public GameObject controladorPrefab;
    public bool espera = true;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(i < 4 && espera)
        {
            espera = false;
            StartCoroutine(esperar(2f));
        }
    }
    
    IEnumerator esperar(float duration)
    {
        yield return new WaitForSeconds(duration);
        Instantiate(controladorPrefab);
        espera = true;
        i++;
    }

}
