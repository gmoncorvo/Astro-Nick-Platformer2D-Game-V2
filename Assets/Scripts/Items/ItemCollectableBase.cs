using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
   
    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
       gameObject.SetActive(false);
       OnCollected();
    }

        protected virtual void OnCollected()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
