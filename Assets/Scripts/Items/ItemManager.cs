using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moncrow.Singleton;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI uiTextCoins;
    public TextMeshProUGUI uiTextGreenCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.coins = 0;
        coins.greenCoins = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.coins += amount;
        UpdateUI();
    }

    public void AddGreenCoins(int amount = 1)
    {
        coins.greenCoins += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIInGameManager.UpdateTextCoins(coins.coins.ToString());
        //UIInGameManager.UpdateTextreenCoins(coins.greenCoins.ToString());
    }
}
