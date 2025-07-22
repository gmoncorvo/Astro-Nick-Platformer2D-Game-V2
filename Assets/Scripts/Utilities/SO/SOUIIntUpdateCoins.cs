using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdateCoins : MonoBehaviour
{
    public SOInt coins;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        
    }

    private void Update()
    {
        uiTextValue.text = coins.coins.ToString();
    }

}
