using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableGreenCoin : ItemCollectableBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddGreenCoins();
    }
}
