using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual = 100;
    public float vidaMaxima = 100;

    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }
}
