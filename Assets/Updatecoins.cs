using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Updatecoins : MonoBehaviour
{
    public gamemanager gamemanager;
    public TMP_Text Text;

    private void Start()
    {
        gamemanager = GameObject.FindObjectOfType<gamemanager>();
    }

    void Update()
    {
        if (gamemanager == null || Text == null ) 
                return;

        Text.text = gamemanager.CoinsCollected.ToString();
    }
}
