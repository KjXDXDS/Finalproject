using JetBrains.Annotations;
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

    public string coinscene = "";

    public void LoadScene()
    {

        SaveGame();

        if (NextSceneName == "")
            return;
           
        SceneManager.LoadScene(NextSceneName);
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
    //private void Update()
    //{
    //    if (ScoreDisplay == null)
    //        return;

    //    ScoreDisplay.text = CoinsCollected.ToString();
    //}

    public void Start()
    {
            LoadGame();      
    }


    public void IDie(GameObject obj)
    {
        
            if (obj.CompareTag("Player"))
            {
            Debug.Log("plaayer died");
                SceneManager.LoadScene(coinscene);
            }



            Debug.Log(obj.name + " died");  
        

    }

   
}
