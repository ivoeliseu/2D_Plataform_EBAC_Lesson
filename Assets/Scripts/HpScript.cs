using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    public Action OnKill;
    public int _currentLife;

    public int startHp = 1;
    public bool destroyOnKill = false;
    public float delayToKill = 2f;

    private bool _isDead = false;

    [SerializeField] private FlashColor _flashColor;


    private void Awake()
    {
        Init();
        if (_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startHp;

    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;


        if (_currentLife <= 0)
        {
            Kill();
        }

        if (_flashColor != null)
        {
            _flashColor.Flash();
        }
    }

    private void Kill()
    {
        _isDead = true;
        if (destroyOnKill)
        {
            Destroy(gameObject);
            Destroy(gameObject, delayToKill);
        }

        OnKill.Invoke();
    }
}
