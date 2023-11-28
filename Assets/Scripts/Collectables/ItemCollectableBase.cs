using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particle;
    public float hideItemTimer = 2f;
    public GameObject graphicItem;
    public CircleCollider2D _itemCollider;

    private void Awake()
    {
        //if (particle != null) particle.transform.SetParent(null);
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
        if (graphicItem != null) 
        {
            graphicItem.SetActive(false);
            _itemCollider.enabled = false;
        }
        PlayParticle();
        Invoke(nameof(HideObject), hideItemTimer);
        
    }



    protected virtual void PlayParticle()
    {
        if (particle != null) particle.Play();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    

}
