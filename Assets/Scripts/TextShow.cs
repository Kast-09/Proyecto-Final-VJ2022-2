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
                SdialogoInicial.SetValue("La historia cuenta las aventuras de �S� y �L�, dos gemelos guerreros que viajaban " +
                    "por todo el mundo, de pueblo en pueblo ayudando a todas" +
                    " las personas que lo necesitasen.\n" +
                    "Sus acciones fueron tales que las voces de todas las personas y pueblos que recibieron su ayuda sonaban " +
                    "por todo el reino, se dec�a que no importase el problema que tuvieran, con ellos a�n hab�a esperanza.", 0);
                break;
            case 2:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�S�, el gemelo mayor, un joven confiable de car�cter carism�tico y fuerzas que " +
                    "parec�an inagotables, adoraba mucho a su hermana �L�. Cuando se enter� que su hermana planeaba viajar " +
                    "por el mundo, no dud� en acompa�arla. Era la voz de los gemelos al momento de ofrecer ayuda y se gan� " +
                    "el apodo del �escudo� del d�o n�mada. ", 0);
                break;
            case 3:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�L�, la gemela menor, una joven intuitiva sin expresi�n que no sol�a dialogar mucho, " +
                    "contaba con una alta capacidad intelectual y conocimientos en medicina, alquimia y combate real. " +
                    "Quer�a y admiraba mucho a su hermano mayor por su car�cter valiente y alto sentido de la justicia. " +
                    "Era la encargada de buscar la soluci�n al problema y era conocida por ser la �espada� del d�o n�mada. ", 0);
                break;
            case 4:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Llamaron la atenci�n de grandes guerreros buscando desafiarles, exist�a el rumor que " +
                    "la fuerza de ambos era tal que no importase con qu� o cuantos se enfrentasen, si luchaban juntos eran " +
                    "pr�cticamente invencibles.  ", 0);
                break;
            case 5:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Y claro tambi�n se hicieron conocidos en peque�as tribus de monstruos con cierta " +
                    "capacidad de raciocinio, ya que sus acciones limitaban la caza de humanos. Debido a esto, evitaban " +
                    "interactuar en la superficie y solo viv�an ocultos bajo tierra comi�ndose unos a otros, disminuyendo " +
                    "en gran medida la cantidad de su especie.", 0);
                break;
            case 6:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�IMPOTENCIA�, LA CA�DA DE LOS GEMELOS", 0);
                break;
            case 7:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("A solo 3 a�os de iniciado su viaje ya se hab�an hecho una reputaci�n en el reino, " +
                    "sab�an que no pod�an estar por mucho tiempo en un pueblo, as� que solo se limitaban a ayudar e irse. " +
                    "Se hab�an o�do rumores de varias desapariciones cerca de un pantano, los gemelos hab�an fijado su " +
                    "pr�ximo destino.", 0);
                break;
            case 8:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Varios d�as despu�s divisaron un pueblo en ruinas cerca de la ubicaci�n del pantano. " +
                    "En medio del pueblo notaron la presencia de una ni�a, se notaba que no hab�a comido en d�as, se acercaron " +
                    "y le ofrecieron algo de comida.  ", 0);
                break;
            case 9:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Luego de comer la ni�a agradeci� el gesto mientras lloraba de felicidad, suplic� a " +
                    "los gemelos que ayudaran a su madre enferma. Ambos se miraron y aceptaron. Cuando se dirig�an a la casa " +
                    "de la ni�a, la intuici�n de �L� le dec�a que algo no andaba bien, pero al ver la cara de la peque�a " +
                    "decidi� ignorar ese sentimiento. ", 0);
                break;
            case 10:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Al entrar en la casa, ambos hermanos no tardaron en percibir el olor a sangre fresca " +
                    "y desesperaci�n, notaron que en la cama hab�a una joven amarrada de pies y manos, ten�a la boca amordazada " +
                    "y se mov�a bruscamente, como si quisiera huir. ", 0);
                break;
            case 11:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�L�, fue inmediatamente a revisarla, aquella mujer estaba llena de agujeros en el cuerpo, " +
                    "similares a mordidas ocasionadas por alguna bestia. Cuando le quit� la tela de la boca, la mujer con " +
                    "desesperaci�n grit�: �ESA NI�ESA NI�A ES UN MONSTRUO!", 0);
                break;
            case 12:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�L�, que sab�a que algo no andaba bien, gir� inmediatamente y empu�� su arma. �S�, algo " +
                    "confundido, hizo lo mismo al ver el accionar de su hermana.", 0);
                break;
            case 13:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Aquella ni�a, vestida con harapos y el cabello cubri�ndole la cara, estaba parada en medio" +
                    " de la habitaci�n sin decir nada, comenz� a expulsar sangre de su boca, con sus dos manos se tom� la boca y " +
                    "rasg� la comisura de sus labios formando una sonrisa de oreja a oreja. ", 0);
                break;
            case 14:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Ambos hermanos quedaron sorprendidos por ese hecho y sin previo aviso, la ni�a se abalanz� " +
                    "contra los gemelos, el encuentro se defini� en unos pocos segundos.", 0);
                break;
            case 15:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Todo termin� en un profundo silencio, solo se escuchaba el sonido de un l�quido " +
                    "derram�ndose. Ambos gemelos hab�an terminado con un agujero en sus est�magos.", 0);
                break;
            case 16:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La ni�a se acerc� r�pidamente " +
                    "a ellos, le arranc� ambos brazos a �S� y le arrebat� los dos ojos a �L�, y as� los dos gemelos cayeron al " +
                    "suelo. �S�, que ten�a una gran resistencia pudo observar como esa cosa cubierta de sangre arrastraba el " +
                    "cuerpo de su hermana en direcci�n a la puerta, y tras unos segundos desapareci�. ", 0);
                break;
            case 17:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Antes de caer inconsciente, con l�grimas de impotencia y sangre en sus ojos, record� " +
                    "que su hermana hab�a preparado una medicina experimental con efectos de regeneraci�n.", 0);
                break;
            case 18:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("No le importaron los " +
                    "efectos que tuviera esa medicina, hab�a jurado vengar la muerte de su hermana. Se levant� utilizando las " +
                    "pocas fuerzas que le quedaban y con un cuchillo en la boca cort� las cuerdas que ataban a la mujer, quien " +
                    "se hab�a quedado at�nita del susto. A duras penas pudo explicarle la situaci�n y, tras unos segundos cay� " +
                    "al suelo.", 0);
                break;
            case 19:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Antes de caer inconsciente, con l�grimas de impotencia y sangre en sus ojos, record� " +
                    "que su hermana hab�a preparado una medicina experimental con efectos de regeneraci�n. No le importaron los " +
                    "efectos que tuviera esa medicina, hab�a jurado vengar la muerte de su hermana.", 0);
                break;
            case 20:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se levant� utilizando las " +
                    "pocas fuerzas que le quedaban y con un cuchillo en la boca cort� las cuerdas que ataban a la mujer, quien " +
                    "se hab�a quedado at�nita del susto. A duras penas pudo explicarle la situaci�n y, tras unos segundos cay� " +
                    "al suelo.", 0);
                break;
            case 21:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("��CU�L ES TU OBJETIVO?�, LA DETERMINACI�N DE �S�", 0);
                break;
            case 22:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�S� despert� gritando el nombre de su hermana, estaba acostado en una cama y vest�a " +
                    "otras ropas.  Inmediatamente not� la presencia de una persona a su lado durmiendo sobre la cama apoyada de " +
                    "sus brazos. ", 0);
                break;
            case 23:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se pregunt� qu� hab�a pasado, d�nde estaba su hermana. Y todo lo sucedido volvi� de " +
                    "golpe a su memoria. No pudo contener las l�grimas, la frustraci�n al no poder proteger a �L�, revis� su " +
                    "cuerpo y not� que el agujero en su est�mago y sus brazos se hab�an regenerado.", 0);
                break;
            case 24:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La persona que estaba a su lado despert�, era una anciana mayor, llamaba mucho la " +
                    "atenci�n por la gran cantidad de cicatrices que ten�a en todo su cuerpo. Sus ojos se iluminaron al ver " +
                    "que �S� hab�a despertado.", 0);
                break;
            case 25:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�S� le pregunt� qui�n era, a lo que la anciana con una sonrisa en el rostro respondi�: " +
                    "�Han pasado m�s de 50 a�os desde que me salvaste�. �S�, confundido por sus palabras le pregunt� ��50 a�os? " +
                    "�Qui�n eres?�.", 0);
                break;
            case 26:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("La anciana le explic� con detalle lo ocurrido, resulta ser que aquella anciana mayor " +
                    "era la joven que �S� hab�a salvado antes de caer inconsciente, de ah� las cicatrices en todo su cuerpo. " +
                    "Adem�s, desde ese hecho hab�an pasado m�s de 50 a�os, per�odo de tiempo en el que �S� hab�a tardado en " +
                    "sanar y despertar.", 0);
                break;
            case 27:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�Ja, as� que este era el efecto secundario que mencionaste, �L��, dijo �S� mientras " +
                    "lloraba por la ausencia de su hermana. ��Qu� har� ahora?�. La anciana, tom� las manos de �S�, y con una " +
                    "sonrisa le dijo: ��Ya lo olvidaste? Me lo dijiste antes de desmayarte� �Tienes un objetivo �cierto?�. La " +
                    "anciana agarr� un pa�uelo y limpi� las l�grimas e �S�.", 0);
                break;
            case 28:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("(Todo estaba claro, no importase el tiempo que haya pasado, esa cosa que me arrebat� " +
                    "a �L� debe estar por ah�. La medicina evit� que envejezca durante todo este tiempo, debe haber alguna raz�n " +
                    "para ello).", 0);
                break;
            case 29:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("�Muchas gracias�, le dijo �S� a la anciana. Intent� ponerse de pie, aunque cay� " +
                    "inmediatamente. �Aun no recuperas tus fuerzas, tomar� un tiempo, no te preocupes yo te ayudar�, le dijo " +
                    "la anciana, dando a entender que �S� no estaba solo.", 0);
                break;
            case 30:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Y as� pasaron 10 meses, �S� hab�a recuperado sus fuerzas, tal vez hayan sido los " +
                    "efectos de esa medicina, o quien sabe, la determinaci�n de vengar a su hermana, pero sus capacidades " +
                    "eran mucho mayores a comparaci�n de hace 50 a�os. ", 0);
                break;
            case 31:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Se puso la armadura que le hab�a dejado la anciana, tom� la espada y algunos " +
                    "medicamentos. �Es hora, debo irme Kin�, dijo �S� con una sonrisa, mientras se alejaba de la casa con " +
                    "una resoluci�n inquebrantable.", 0);
                break;
            case 32:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("Una leve brisa hac�a sonar las ramas de los �rboles, haciendo que sus hojas caigan " +
                    "alrededor de la vieja casa, la figura de �S� hab�a desaparecido.  Atr�s de la deteriorada vivienda " +
                    "destacaba la figura de una peque�a estatua hecha a mano donde se pod�a ver una gran variedad de flores. ", 0);
                break;
            case 33:
                SdialogoInicial = new string[1];
                SdialogoInicial.SetValue("En la parte baja del monumento se mostraba una bella oraci�n, �Aqu� descansa el alma " +
                    "de Kin, la joven que nunca se rindi�, la mujer que nunca me abandon�. ", 0);
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
