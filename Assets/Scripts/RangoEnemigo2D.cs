using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo2D : MonoBehaviour
{
    public Animator ani;
    public EnemyController enemigo;

    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_ATACAR = 1;
    const int ANIMATION_CAMINAR = 2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ChangeAnimation(ANIMATION_ATACAR);
            enemigo.atacando = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void ChangeAnimation(int animation)
    {
        ani.SetInteger("Estado", animation);
    }
}
