using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEditor.ShaderData;

public class TextShow2 : MonoBehaviour
{
    public GameObject panel;

    public string[] SdialogoInicial;

    public Text txDialogo;
    public bool isDialogActive;

    Coroutine auxCorutine;

    int cont = 0;

    public void AbrirCajaDialogo(int valor)
    {
        if (isDialogActive)
        {
            CerrarDialogo();
            StartCoroutine(esperaSolapacionDialogo(valor));
        }
        else
        {
            isDialogActive = false;
            auxCorutine = StartCoroutine(mostrarDialogo(valor));
        }
    }

    IEnumerator mostrarDialogo(int valor, float time = 0.02f)
    {
        panel.SetActive(true);
        string[] dialogo;
        dialogo = SdialogoInicial;

        int total = dialogo.Length;
        string res = "";
        isDialogActive = true;
        yield return null;
        for (int i = 0; i < total; i++)
        {
            res = "";
            if (isDialogActive)
            {
                for (int s = 0; s < dialogo[i].Length; s++)
                {
                    if (isDialogActive)
                    {
                        res = string.Concat(res, dialogo[i][s]);
                        txDialogo.text = res;
                        yield return new WaitForSeconds(time);
                    }
                    else yield break;
                }
                yield return new WaitForSeconds(0.4f);
            }
            else yield break;
        }
        //yield return new WaitForSeconds(0.4f);
    }

    IEnumerator esperaSolapacionDialogo(int valor)
    {
        yield return new WaitForEndOfFrame();
        auxCorutine = StartCoroutine(mostrarDialogo(valor));
    }

    public void CerrarDialogo()
    {
        isDialogActive = false;
        if (auxCorutine != null)
        {
            Debug.Log("DETENER");
            StopCoroutine(auxCorutine);
            auxCorutine = null;
        }

        txDialogo.text = "";
        //panel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        setText(cont);
        AbrirCajaDialogo(cont);
        cont++;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void setText(int aux)
    {
        switch (aux)
        {
            case 0:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Leves sonidos de goteos emitían un eco en todo lo profundo de la cueva acompañados " +
                    "de una leve respiración arrítmica.", 0);
                break;
            case 1:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("En el fondo de aquella tenebrosa mazmorra destacaba la figura de un joven vestido " +
                    "con una armadura hecha pedazos, en sus pies, una brillante espada cubierta de sangre daba señales de " +
                    "que en aquel sombrío y oscuro lugar se había producido un evento sangriento sin precedentes. ", 0);
                break;
            case 2:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Aquel joven que apenas podía mantenerse de pie tenía mantenía una sonrisa en su " +
                    "rostro, no le importaba en nada la gran cantidad de sangre que estaba derramando de su ya perdido " +
                    "brazo izquierdo, estaba cegado por la satisfacción de haber cumplido su venganza.", 0);
                break;
            case 3:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Pero lo que más llamaba la atención era el objeto que colgaba de su mano derecha, " +
                    "era su trofeo, la cabeza del monstruo que había arruinado su vida.", 0);
                break;
            case 4:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Sin embargo, el sentimiento de satisfacción desapareció con un repentino temblor " +
                    "en la cueva, “S” miró hacia abajo y vio que el suelo se estaba rompiendo, quiso correr, pero se había " +
                    "quedado sin energías tras la batalla.", 0);
                break;
            case 5:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Varios pedazos del techo comenzaron a caer, resignado tras ver que iba a morir " +
                    "sepultado en aquella cueva, “S” se sentó en el suelo, tiró la cabeza del monstruo lejos de él. " +
                    "Con una sonrisa esperó pacientemente el momento de su muerte, cerró los ojos y no demoró en caer en un " +
                    "profundo sueño. ", 0);
                break;
            case 6:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("-\t”S”… “S”, hijo despierta ¿me puedes hacer un favor?, tu hermana ya se demoró " +
                    "bastante afuera, la comida ya está lista, ve por ella y vengan a comer.", 0);
                break;
            case 7:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("-	¡Mamá! \n-   ¿Ah ? ¿Pasa algo hijo ? \n-No, no pasa nada…. ahora mismo voy por “L”.", 0);
                break;
            case 8:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("-	“L”, vamos a casa, nuestra madre quiere que vayamos a comer. “L” volteó a ver a su " +
                    "hermano, le sonrió felizmente, se levantó y fue corriendo hacia el fondo del bosque.", 0);
                break;
            case 9:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("-	¡Hermano!, juguemos un poco, si me alcanzas e iré contigo. “S” sonrió al recordar" +
                    " que su hermana tenía ese lado travieso que no demostraba a personas, así que tras intercambiar risas " +
                    "decidió seguirle el juego. ", 0);
                break;
            case 10:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Luego de varios minutos por fin “S” alcanzó a “L”, ambos terminaron cansados y " +
                    "cayeron al suelo mientras recuperaban el aliento. - Lo conseguiste… por fin me… alcanzaste hermano. \n" +
                    "-   ¿Verdad ? ...aunque… me costó bastante. - Te quiero mucho… hermano, gracias… por vengarme. \n" +
                    "-   … ¿Qué ? ... ¿Qué dijiste ? ", 0);
                break;
            case 11:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“S” volteó a ver a su hermana, vio que lo estaba mirando fijamente con lágrimas " +
                    "en sus ojos. “L” sacó de su bolsillo un pedazo de tela y la sujetó con fuerza en el brazo izquierdo " +
                    "de “S”. \n- No pierdas nunca las ganas de vivir, hay mucha gente que necesita tu ayuda ahora que el " +
                    "mundo está libre de monstruos. ", 0);
                break;
            case 12:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("-	¿Pero qué dices? - Me alegró mucho jugar contigo por última vez, eres la persona " +
                    "más fuerte que he conocido.Nunca te rindas, vive hermano. -   ¡L!... ", 0);
                break;
            case 13:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Tras gritar el nombre de su hermana, “S” despertó acostado mirando al cielo. " +
                    "Se levantó rápidamente y vio que se encontraba en medio de la nada, a pesar de eso pudo ver claramente " +
                    "que al frente de él se encontraba la montaña donde estaba la mazmorra de los monstruos cuya entrada " +
                    "había sido sellada por el derrumbe.", 0);
                break;
            case 14:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Examinó su cuerpo y notó que la hemorragia se había detenido, y en su brazo " +
                    "izquierdo se apreciaba amarrado un trozo de tela. - Jajaja, ya entiendo…", 0);
                break;
            case 15:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Con mucha dificultad, “S” tomó su espada y, apoyándose de ella, comenzó a caminar " +
                    "lentamente de regreso al reino, después de todo, había mucho por hacer. \nFIN ", 0);
                break;
            case 16:
                Application.Quit();
                break;
        }
    }

    public void siguienteDialogo()
    {
        setText(cont);
        Debug.Log("CIERRAMOS MOSTRAR");
        CerrarDialogo();
        AbrirCajaDialogo(cont);
        cont++;
    }
    public void Terminar()
    {
        Application.Quit();
    }
}
