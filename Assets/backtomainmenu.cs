using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtomainmenu : MonoBehaviour
{
   
    public GameObject EndingScorePanel;
    public float LoadMainMenuDelay = 2f;
    private void Start()
    {
        if (EndingScorePanel != null)
        {
            EndingScorePanel.SetActive(false);
        }
    }



    public void LoadMainMenu()
    {
        if (EndingScorePanel != null)
        {
            EndingScorePanel.SetActive(true);
        }
        Invoke("MainMenu", LoadMainMenuDelay);

    }
    void MainMenu()

    {
        SceneManager.LoadScene("MainMenu");
    }
    

}
