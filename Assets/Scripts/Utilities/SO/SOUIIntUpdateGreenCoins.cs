using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdateGreenCoins : MonoBehaviour
{
    public SOInt coins;
    public TextMeshProUGUI uiTextValue;

    private void Start()
    {
        
    }

    private void Update()
    {        
        uiTextValue.text = coins.greenCoins.ToString();
    }

}
