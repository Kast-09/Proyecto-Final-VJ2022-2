using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator animator;
    public int direccion;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool atacando;

    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_ATACAR = 1;
    const int ANIMATION_CAMINAR = 2;

    public float rango_vision;
    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

    public GameObject enemigo1;
    public GameObject enemigo2;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    public void Comportamientos()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_vision && !atacando)
        {
            ChangeAnimation(ANIMATION_QUIETO);
            //animator.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    //animator.SetBool("walk", false);
                    ChangeAnimation(ANIMATION_QUIETO);
                    break;

                case 1:
                    direccion = Random.Range(0, 2);
                    rutina++;
                    break;

                case 2:
                    switch (direccion)
                    {
                        case 0:
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;

                        case 1:
                            transform.rotation = Quaternion.Euler(0, 180, 0);
                            transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                            break;
                    }
                    ChangeAnimation(ANIMATION_CAMINAR);
                    //animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > rango_ataque && !atacando)
            {
                if(transform.position.x < target.transform.position.x)
                {
                    ChangeAnimation(ANIMATION_CAMINAR);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);

                    if (time >= 5)
                    {
                        time = 0f;
                        var enemigoPosition = transform.position + new Vector3(3, -1, 0);
                        var gb = Instantiate(enemigo1, enemigoPosition, Quaternion.identity) as GameObject;
                    }
                }
                else
                {
                    ChangeAnimation(ANIMATION_CAMINAR);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    if (time >= 5)
                    {
                        time = 0f;
                        var enemigoPosition = transform.position + new Vector3(-3, -1, 0);
                        var gb = Instantiate(enemigo2, enemigoPosition, Quaternion.identity) as GameObject;
                    }
                }
            }
            else
            {
                if (!atacando)
                {
                    if(transform.position.x < target.transform.position.x)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    ChangeAnimation(ANIMATION_QUIETO);
                }
            }
        }
    }

    public void Final_Ani()
    {
        ChangeAnimation(ANIMATION_QUIETO);
        atacando = false;
        time = 0f;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Comportamientos();
    }

    private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
