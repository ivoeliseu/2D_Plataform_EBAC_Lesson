using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int damage = 10;
    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";
    public HpScript healthBase;
    [SerializeField] 
    private BoxCollider2D _boxCollider2D;

    public float timeToDestroy = 1f;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }

        if (_boxCollider2D == null)
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }
    }

    private void OnEnemyKill()
    {
        _boxCollider2D.enabled = false;
        healthBase.OnKill -= OnEnemyKill;
        PlayKillAnimation();
        Destroy(gameObject, timeToDestroy);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HpScript>();
        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
    
    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
      
}
