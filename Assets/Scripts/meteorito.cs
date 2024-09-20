using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class meteorito : MonoBehaviour
{
    public GameObject score;
    public meteorito2 meteorito2;
    public float vel = 2f;
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8,8),7.5f,0);
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - vel*Time.deltaTime, 0);// movimiento vertical hacia abajo
        // mira si se sale de la pantalla y restamos puntacion 
        if (transform.position.y < -6.3)
        {
            score.GetComponent<score>().puntaje -= 1;
            morir(false);
        }
    }
    //detecta si hay colision con la bala
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            Destroy(collision.gameObject);
            score.GetComponent<score>().puntaje += 1;
            morir(true);
        }

    }
    // funcion que actua cuando el meteorito "muere"
    public virtual void morir(bool b)
    {
        //Probabilidad de dividirse 50%
        if (b && Random.Range(0,2) == 1)
        {
            dividirse();
        }
        //Object pooling para los meteoritos
        transform.position = new Vector3(0, 1000, 0);
        StartCoroutine(esperar(Random.Range(2.5f, 6f)));
    }
    // crea dos trozos de meteorito
    public void dividirse()
    {
        Instantiate(meteorito2, new Vector3(transform.position.x, transform.position.y, 0),Quaternion.identity).score = score;
        Instantiate(meteorito2, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity).score = score;
    }
    //espera para traer de vuelta nuevos meteoritos
    IEnumerator esperar(float duration)
    {
        yield return new WaitForSeconds(duration);
        transform.position = new Vector3(Random.Range(-8, 8), 7f, 0);
    }
}
