using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextShow : MonoBehaviour
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
        if(auxCorutine != null)
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
                SdialogoInicial.SetValue("VINDEX, LA LEYENDA DE S", 0);
                break;
            case 1:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La historia cuenta las aventuras de “S” y “L”, dos gemelos guerreros que viajaban " +
                    "por todo el mundo, de pueblo en pueblo ayudando a todas" +
                    " las personas que lo necesitasen.\n" +
                    "Sus acciones fueron tales que las voces de todas las personas y pueblos que recibieron su ayuda sonaban " +
                    "por todo el reino, se decía que no importase el problema que tuvieran, con ellos aún había esperanza.", 0);
                break;
            case 2:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“S”, el gemelo mayor, un joven confiable de carácter carismático y fuerzas que " +
                    "parecían inagotables, adoraba mucho a su hermana “L”. Cuando se enteró que su hermana planeaba viajar " +
                    "por el mundo, no dudó en acompañarla. Era la voz de los gemelos al momento de ofrecer ayuda y se ganó " +
                    "el apodo del “escudo” del dúo nómada. ", 0);
                break;
            case 3:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“L”, la gemela menor, una joven intuitiva sin expresión que no solía dialogar mucho, " +
                    "contaba con una alta capacidad intelectual y conocimientos en medicina, alquimia y combate real. " +
                    "Quería y admiraba mucho a su hermano mayor por su carácter valiente y alto sentido de la justicia. " +
                    "Era la encargada de buscar la solución al problema y era conocida por ser la “espada” del dúo nómada. ", 0);
                break;
            case 4:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Llamaron la atención de grandes guerreros buscando desafiarles, existía el rumor que " +
                    "la fuerza de ambos era tal que no importase con qué o cuantos se enfrentasen, si luchaban juntos eran " +
                    "prácticamente invencibles.  ", 0);
                break;
            case 5:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Y claro también se hicieron conocidos en pequeñas tribus de monstruos con cierta " +
                    "capacidad de raciocinio, ya que sus acciones limitaban la caza de humanos. Debido a esto, evitaban " +
                    "interactuar en la superficie y solo vivían ocultos bajo tierra comiéndose unos a otros, disminuyendo " +
                    "en gran medida la cantidad de su especie.", 0);
                break;
            case 6:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“IMPOTENCIA”, LA CAÍDA DE LOS GEMELOS", 0);
                break;
            case 7:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("A solo 3 años de iniciado su viaje ya se habían hecho una reputación en el reino, " +
                    "sabían que no podían estar por mucho tiempo en un pueblo, así que solo se limitaban a ayudar e irse. " +
                    "Se habían oído rumores de varias desapariciones cerca de un pantano, los gemelos habían fijado su " +
                    "próximo destino.", 0);
                break;
            case 8:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Varios días después divisaron un pueblo en ruinas cerca de la ubicación del pantano. " +
                    "En medio del pueblo notaron la presencia de una niña, se notaba que no había comido en días, se acercaron " +
                    "y le ofrecieron algo de comida.  ", 0);
                break;
            case 9:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Luego de comer la niña agradeció el gesto mientras lloraba de felicidad, suplicó a " +
                    "los gemelos que ayudaran a su madre enferma. Ambos se miraron y aceptaron. Cuando se dirigían a la casa " +
                    "de la niña, la intuición de “L” le decía que algo no andaba bien, pero al ver la cara de la pequeña " +
                    "decidió ignorar ese sentimiento. ", 0);
                break;
            case 10:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Al entrar en la casa, ambos hermanos no tardaron en percibir el olor a sangre fresca " +
                    "y desesperación, notaron que en la cama había una joven amarrada de pies y manos, tenía la boca amordazada " +
                    "y se movía bruscamente, como si quisiera huir. ", 0);
                break;
            case 11:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“L”, fue inmediatamente a revisarla, aquella mujer estaba llena de agujeros en el cuerpo, " +
                    "similares a mordidas ocasionadas por alguna bestia. Cuando le quitó la tela de la boca, la mujer con " +
                    "desesperación gritó: ¡ESA NI…ESA NIÑA ES UN MONSTRUO!", 0);
                break;
            case 12:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“L”, que sabía que algo no andaba bien, giró inmediatamente y empuñó su arma. “S”, algo " +
                    "confundido, hizo lo mismo al ver el accionar de su hermana.", 0);
                break;
            case 13:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Aquella niña, vestida con harapos y el cabello cubriéndole la cara, estaba parada en medio" +
                    " de la habitación sin decir nada, comenzó a expulsar sangre de su boca, con sus dos manos se tomó la boca y " +
                    "rasgó la comisura de sus labios formando una sonrisa de oreja a oreja. ", 0);
                break;
            case 14:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Ambos hermanos quedaron sorprendidos por ese hecho y sin previo aviso, la niña se abalanzó " +
                    "contra los gemelos, el encuentro se definió en unos pocos segundos.", 0);
                break;
            case 15:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Todo terminó en un profundo silencio, solo se escuchaba el sonido de un líquido " +
                    "derramándose. Ambos gemelos habían terminado con un agujero en sus estómagos.", 0);
                break;
            case 16:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La niña se acercó rápidamente " +
                    "a ellos, le arrancó ambos brazos a “S” y le arrebató los dos ojos a “L”, y así los dos gemelos cayeron al " +
                    "suelo. “S”, que tenía una gran resistencia pudo observar como esa cosa cubierta de sangre arrastraba el " +
                    "cuerpo de su hermana en dirección a la puerta, y tras unos segundos desapareció. ", 0);
                break;
            case 17:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Antes de caer inconsciente, con lágrimas de impotencia y sangre en sus ojos, recordó " +
                    "que su hermana había preparado una medicina experimental con efectos de regeneración.", 0);
                break;
            case 18:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("No le importaron los " +
                    "efectos que tuviera esa medicina, había jurado vengar la muerte de su hermana. Se levantó utilizando las " +
                    "pocas fuerzas que le quedaban y con un cuchillo en la boca cortó las cuerdas que ataban a la mujer, quien " +
                    "se había quedado atónita del susto. A duras penas pudo explicarle la situación y, tras unos segundos cayó " +
                    "al suelo.", 0);
                break;
            case 19:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Antes de caer inconsciente, con lágrimas de impotencia y sangre en sus ojos, recordó " +
                    "que su hermana había preparado una medicina experimental con efectos de regeneración. No le importaron los " +
                    "efectos que tuviera esa medicina, había jurado vengar la muerte de su hermana.", 0);
                break;
            case 20:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se levantó utilizando las " +
                    "pocas fuerzas que le quedaban y con un cuchillo en la boca cortó las cuerdas que ataban a la mujer, quien " +
                    "se había quedado atónita del susto. A duras penas pudo explicarle la situación y, tras unos segundos cayó " +
                    "al suelo.", 0);
                break;
            case 21:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“¿CUÁL ES TU OBJETIVO?”, LA DETERMINACIÓN DE “S”", 0);
                break;
            case 22:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“S” despertó gritando el nombre de su hermana, estaba acostado en una cama y vestía " +
                    "otras ropas.  Inmediatamente notó la presencia de una persona a su lado durmiendo sobre la cama apoyada de " +
                    "sus brazos. ", 0);
                break;
            case 23:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se preguntó qué había pasado, dónde estaba su hermana. Y todo lo sucedido volvió de " +
                    "golpe a su memoria. No pudo contener las lágrimas, la frustración al no poder proteger a “L”, revisó su " +
                    "cuerpo y notó que el agujero en su estómago y sus brazos se habían regenerado.", 0);
                break;
            case 24:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La persona que estaba a su lado despertó, era una anciana mayor, llamaba mucho la " +
                    "atención por la gran cantidad de cicatrices que tenía en todo su cuerpo. Sus ojos se iluminaron al ver " +
                    "que “S” había despertado.", 0);
                break;
            case 25:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“S” le preguntó quién era, a lo que la anciana con una sonrisa en el rostro respondió: " +
                    "“Han pasado más de 50 años desde que me salvaste”. “S”, confundido por sus palabras le preguntó “¿50 años? " +
                    "¿Quién eres?”.", 0);
                break;
            case 26:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La anciana le explicó con detalle lo ocurrido, resulta ser que aquella anciana mayor " +
                    "era la joven que “S” había salvado antes de caer inconsciente, de ahí las cicatrices en todo su cuerpo. " +
                    "Además, desde ese hecho habían pasado más de 50 años, período de tiempo en el que “S” había tardado en " +
                    "sanar y despertar.", 0);
                break;
            case 27:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“Ja, así que este era el efecto secundario que mencionaste, “L””, dijo “S” mientras " +
                    "lloraba por la ausencia de su hermana. “¿Qué haré ahora?”. La anciana, tomó las manos de “S”, y con una " +
                    "sonrisa le dijo: “¿Ya lo olvidaste? Me lo dijiste antes de desmayarte” “Tienes un objetivo ¿cierto?”. La " +
                    "anciana agarró un pañuelo y limpió las lágrimas e “S”.", 0);
                break;
            case 28:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("(Todo estaba claro, no importase el tiempo que haya pasado, esa cosa que me arrebató " +
                    "a “L” debe estar por ahí. La medicina evitó que envejezca durante todo este tiempo, debe haber alguna razón " +
                    "para ello).", 0);
                break;
            case 29:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("“Muchas gracias”, le dijo “S” a la anciana. Intentó ponerse de pie, aunque cayó " +
                    "inmediatamente. “Aun no recuperas tus fuerzas, tomará un tiempo, no te preocupes yo te ayudaré”, le dijo " +
                    "la anciana, dando a entender que “S” no estaba solo.", 0);
                break;
            case 30:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Y así pasaron 10 meses, “S” había recuperado sus fuerzas, tal vez hayan sido los " +
                    "efectos de esa medicina, o quien sabe, la determinación de vengar a su hermana, pero sus capacidades " +
                    "eran mucho mayores a comparación de hace 50 años. ", 0);
                break;
            case 31:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se puso la armadura que le había dejado la anciana, tomó la espada y algunos " +
                    "medicamentos. “Es hora, debo irme Kin”, dijo “S” con una sonrisa, mientras se alejaba de la casa con " +
                    "una resolución inquebrantable.", 0);
                break;
            case 32:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Una leve brisa hacía sonar las ramas de los árboles, haciendo que sus hojas caigan " +
                    "alrededor de la vieja casa, la figura de “S” había desaparecido.  Atrás de la deteriorada vivienda " +
                    "destacaba la figura de una pequeña estatua hecha a mano donde se podía ver una gran variedad de flores. ", 0);
                break;
            case 33:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("En la parte baja del monumento se mostraba una bella oración, “Aquí descansa el alma " +
                    "de Kin, la joven que nunca se rindió, la mujer que nunca me abandonó”. ", 0);
                break;
            case 34:
                StartGame();
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
}
