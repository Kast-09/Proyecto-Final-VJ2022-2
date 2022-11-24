using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocity = 10, fuerzaSalto, jumpForce = 5, velocityEscalar = 5, velocityPlanear = 2;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CORRER = 1;
    const int ANIMATION_SALTAR = 2;
    const int ANIMATION_ATACAR = 3;
    const int ANIMATION_BLOQUEO = 4;
    const int ANIMATION_DESLIZAR = 5;
    const int ANIMATION_DEAD = 7;

    bool atacar = false;
    bool bloqueo = false;

    Vector3 lastCheckPointPosition;

    public GameObject bullet;

    float vida = 100;


    //doble salto
    int vecesSalto = 0;

    int band = 0;
    int band2 = 0;

    float time = 0.0f;
    float time2 = 0.0f;
    float time3 = 500000.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (vida <= 0)
        {
            if(band == 0)
            {
                time2 = time + 2f;
                ChangeAnimation(ANIMATION_DEAD);
                Time.timeScale = 1f;
                band++;
            }
            if(time >= time2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (band2 >= 1)
        {
            ChangeAnimation(ANIMATION_DEAD);
            if (time >= time3)
            {
                SceneManager.LoadScene(5);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))//salto doble
        {
            if (vecesSalto < 2)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                ChangeAnimation(ANIMATION_SALTAR);
                vecesSalto += 1;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(velocity * 2, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CORRER);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CORRER);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(-velocity * 2, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(ANIMATION_CORRER);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            ChangeAnimation(ANIMATION_CORRER);
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            atacar = true;
            ChangeAnimation(ANIMATION_ATACAR);
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.gravityScale = 10;
            if (sr.flipX == true)
                rb.velocity = new Vector2(-velocity, rb.velocity.y);
            else
                rb.velocity = new Vector2(velocity, rb.velocity.y);
            ChangeAnimation(ANIMATION_DESLIZAR);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            ChangeAnimation(ANIMATION_BLOQUEO);
            bloqueo = true;
        }
        else
        {
            bloqueo = false;
            rb.gravityScale = 1;
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(ANIMATION_QUIETO);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        vecesSalto = 0;
        if (collision.gameObject.tag == "Vida")
        {
            BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
            float vidaAux = 0;
            vidaAux = vida + 30;
            if(vidaAux >= 100) barraDeVida.vidaActual = 100;
            else barraDeVida.vidaActual += 30;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Estatua")
        {
            if (atacar)
            {
                ChangeAnimation(ANIMATION_DEAD);
                Time.timeScale = 1f;
                Destroy(collision.gameObject);
                atacar = false;
                time3 = 0f;
                time3 = time + 2f;
                band2++;
            }
        }
        if (collision.gameObject.tag == "Darkhole")
        {
            if (lastCheckPointPosition != null)
            {
                transform.position = lastCheckPointPosition;
                BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
                barraDeVida.vidaActual -= 20;
                vida -= 20;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemigo");
            if (atacar)
            {
                Destroy(collision.gameObject);
                atacar = false;
            }
            else
            {
                if (!bloqueo)
                {
                    BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
                    barraDeVida.vidaActual -= 5;
                    vida -= 5;
                }
            }
        }
        if (collision.gameObject.tag == "Enemy2")
        {
            Debug.Log("Enemigo");
            if (atacar)
            {
                Destroy(collision.gameObject);
                atacar = false;
            }
            else
            {
                if (!bloqueo)
                {
                    BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
                    barraDeVida.vidaActual -= 7;
                    vida -= 7;
                }
            }
        }
        if (collision.gameObject.tag == "Enemy3")
        {
            Debug.Log("Enemigo");
            if (atacar)
            {
                Destroy(collision.gameObject);
                atacar = false;
            }
            else
            {
                if (!bloqueo)
                {
                    BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
                    barraDeVida.vidaActual -= 10; 
                    vida -= 10;
                }
            }
        }
        if (collision.gameObject.tag == "EnemyBoss")
        {
            BarraDeVida barraDeVida = GetComponent<BarraDeVida>();
            barraDeVida.vidaActual -= 20;
            vida -= 20;
        }
        atacar = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastCheckPointPosition = transform.position;
        if (collision.gameObject.tag == "Change")
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.tag == "Change2")
        {
            SceneManager.LoadScene(4);
        }
        atacar = false;
    }

    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
