using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoController : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 20;
    float realVelocity;

    public void SetRightDirection()
    {
        realVelocity = velocity;
    }
    public void SetLeftDirection()
    {
        realVelocity = -velocity;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);//con este m�todo eliminamos el objeto creado despues de 5 segundos
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(realVelocity, 0);//con esto se modifica la velocidad, la primera es la velocidad en x y lo segundo en y

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);//con esto destruye al objeto creado -> con esta condici�n hacemos que cunado choque contra cualquier objeto se destruya el objeto
        if (collision.gameObject.tag == "Enemy")//aqu� le indicamos que cuando colisiona con un enemigo debe hacer...
        {
            Destroy(collision.gameObject);//en este caso destruye el objeto al que colisiono
        }
    }
}
