using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nave : MonoBehaviour
{
    public float empujeFuerza = 100f;
    public float rotacion1 = 200f;
    public score score;
    public Rigidbody2D rb;
    public GameObject bala;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // pulsamos la barra espaciadora para disparar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bala, transform.position, transform.localRotation); // creamos un bala con direccion a la que apunta la nave
        }
        float empuje = Input.GetAxis("Vertical") * Time.deltaTime;
        float rotacion2 = Input.GetAxis("Horizontal") * Time.deltaTime;
        Vector3 direccionEmpuje = transform.right;
        rb.AddForce(empujeFuerza * empuje * direccionEmpuje);
        transform.Rotate(Vector3.forward, rotacion1 * rotacion2);
        // espacio infinito
        if (transform.position.y > 5.7f)
        {
            transform.position = new Vector3(transform.position.x, -5.7f);
        }
        if (transform.position.y < -5.7f)
        {
            transform.position = new Vector3(transform.position.x, 5.7f);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y);
        }
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("meteorito"))
        {
            score.puntaje = 0;
            collision.gameObject.GetComponent<meteorito>().morir(false);
        }
        if (collision.gameObject.CompareTag("meteorito2"))
        {
            score.puntaje = 0;
            collision.gameObject.GetComponent<meteorito2>().morir(false);
        }

    }
}
