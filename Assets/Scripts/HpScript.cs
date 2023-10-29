using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    public int startHp = 1;
    public bool destroyOnKill = false;
    private int _currentLife;
    private bool _isDead = false;
    

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = 1;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0 ) 
        {
            Kill();
        }
    }

    private void Kill()
    {
        _isDead = true;
        if(destroyOnKill)
        {
            Destroy(gameObject);
        }
    }
}
