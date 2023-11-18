using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{

    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        gameObject.SetActive(false); 
    }
    

}
