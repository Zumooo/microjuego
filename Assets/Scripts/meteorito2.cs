using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  meteorito2 : meteorito
{
    //clase hija de meteorito todo funciona igual menos la manera en que desaparece
    float rot;
    void Start()
    {
        rot = Random.Range(-50, 50); // rotacion aleatoria del trozo de meteorito
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - vel * Time.deltaTime, 0); // movimiento vertical hacia abajo
        transform.Rotate(0, 0, 3*rot * Time.deltaTime); // rotacion
        // mira si se sale de la pantalla y restamos puntacion 
        if (transform.position.y < -6.3)
        {
            score.GetComponent<score>().puntaje -= 1;
            morir(false);
        }
    }
    public override void morir(bool b)
    {
        Destroy(this.gameObject);
    }
}
