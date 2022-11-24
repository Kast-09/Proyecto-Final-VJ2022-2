using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManagerController : MonoBehaviour
{
    public Text scoreText;
    // public Text livesText;
    public Text bulletText;
    private int score;
    // private int lives;
    public int bullets;
    void Start()
    {
        score = 0;
        // lives = 3;
        bullets = 5;

        PrintScoreInScreen();
        //PrintLivesInScreen();
        PrintBulletsInScreen();
        LoadGame();

    }
    public void SaveGame()
    {
        var filePath = Application.persistentDataPath + "/save.data";

        FileStream file;

        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else
            file = File.Create(filePath);

        GameDataController data = new GameDataController();
        data.Score = score;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadGame()
    {
        var filePath = Application.persistentDataPath + "/save.data";

        FileStream file;

        if(File.Exists(filePath))
        {
            file = File.OpenRead(filePath);
        }  
        else{
            Debug.LogError("No se enontró el archivo");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameDataController data = (GameDataController) bf.Deserialize(file);
        file.Close();

        score = data.Score;
        PrintScoreInScreen();
    }
    public int Score()
    {
        return score;
    }
    // public int Lives()
    // {
    //     return lives;
    // }
    public void GanarPuntos(int puntos)
    {
        score += puntos;
        PrintScoreInScreen();
    }
    // public void PerderVida()
    // {
    //     lives -= 1;
    //     PrintLivesInScreen();
    // }
    public int Bullets()
    {
        return bullets;
    }
    // public void restarBalas(int total)
    // {
    //     bullets -= total;
    //     PrintBulletsInScreen();

    // }
    public void restarBalas()
    {
        bullets -= 1;
        PrintBulletsInScreen();

    }
    private void PrintScoreInScreen()
    {
        scoreText.text = "Puntaje: " + score; 
    }
    // private void PrintLivesInScreen()
    // {
    //     livesText.text = "Vida: " + lives; 
    // }
    private void PrintBulletsInScreen()
    {
        bulletText.text = "Balas: " + bullets;
    }
}
