using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{

    public int CoinsCollected = 0;

    public Text ScoreDisplay;

    public string NextSceneName = "";

    public string Respown = "";

    public string coinscene = "";

    public void LoadScene()
    {

        SaveGame();

        if (NextSceneName == "")
            return;
           
        SceneManager.LoadScene(NextSceneName);
    }

    public void Restartlevel()
    {
        SceneManager.LoadScene(Respown);

    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CoinsCollected", CoinsCollected);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        CoinsCollected = PlayerPrefs.GetInt("SavedCoinsCollected");
    }
  

    public void Start()
    {
            LoadGame();      
    }

    private void Update()
    {
        if (ScoreDisplay == null)
            return;

        ScoreDisplay.text = CoinsCollected.ToString();


    }
    public void IDie(GameObject obj)
    {
        
            if (obj.CompareTag("Player"))
            {
                 Debug.Log("player died");
                SceneManager.LoadScene(Respown);
            }



            Debug.Log(obj.name + " died");  
        

    }

   public void AddScore(int score)
    {
        CoinsCollected += score;
        Debug.Log("coins collected " + CoinsCollected);

    }
}
