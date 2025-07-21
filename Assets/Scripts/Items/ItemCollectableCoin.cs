using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddCoins();
    }
}
