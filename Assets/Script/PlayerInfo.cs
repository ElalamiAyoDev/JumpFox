using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo playerInfo;

    public int playerHealth = 3;
    public int nbCoins = 0;
    public Image[] hearts;
    public Text coinText;
    public Text scoreText;

    private void Awake()
    {
        playerInfo = this;
    }

    public void setHealth(int health)
    {
        playerHealth += health;
        if(playerHealth >= 3)
            playerHealth = 3;
        if(playerHealth <= 0)
        {
            playerHealth = 0;
            CheckpointMgr.checkpointMgr.Respawn();
        }
        SetHealthBar();
    }

    public void getCoins()
    {
        nbCoins++;
        coinText.text = nbCoins.ToString();
    }

    public void SetHealthBar()
    {
        foreach (Image heart in hearts)
        {
            heart.enabled = false;
        }

        for (int i = 0; i < playerHealth; i++)
        {
            hearts[i].enabled = true;
        }
    }

    public void ShowFinalScore(int nbKilledMobs)
    {
        int finalScore = nbCoins + playerHealth * 10 + nbKilledMobs * 20;
        print(finalScore);
        scoreText.text = "Score = " + finalScore;
    }
}
