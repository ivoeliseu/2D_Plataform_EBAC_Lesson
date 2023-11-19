using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System;

public class Player : MonoBehaviour
{
    public HpScript healthBase;
    public Rigidbody2D rb;
    
    [Header("Moviment Setup")]
    public SOFloat moveVelocity;
    public SOFloat runningVelocity;
    public SOFloat jumpForce;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    public Animator animator;
    public float swipeSideDuration = 0;
    public bool landed = false;
    public string lookingTag = "Ground";


    [Header("Controls Input")]
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode moveLeftInput = KeyCode.LeftArrow;
    public KeyCode moveRightInput = KeyCode.RightArrow;
    public KeyCode runningInput = KeyCode.LeftShift;


    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        if (healthBase == null)
        {
            healthBase = GetComponent<HpScript>();
        }
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(triggerDeath);
    }
    void Update()
    {
        PlayerJump();
        PlayerMoviment();
    }
    private void PlayerMoviment()
    {
        // Inputs de movimenta��o

        if (Input.GetKey(moveLeftInput))
        {
            animator.SetBool(boolRun, true);
            if (rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-1f, swipeSideDuration);
            }

            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? -runningVelocity.value : -moveVelocity.value, rb.velocity.y);
        }
        else if (Input.GetKey(moveRightInput))
        {
            animator.SetBool(boolRun, true);
            if (rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1f, swipeSideDuration);
            }

            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? +runningVelocity.value : moveVelocity.value, rb.velocity.y);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        // Se verificar que Input de correr est� pressionado, muda a velocidade da anima��o
        if (Input.GetKey(runningInput))
        {
            animator.speed = 2.5f;
        }
        else
        {
            animator.speed = 1f;
        }

        // Desacelera��o
        // No objeto dentro da Unity � necess�rio o objeto da plataforma ter um material de physics
        if (rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    // Fun��o que faz o jogador pular
    private void PlayerJump()
    {
        if (Input.GetKeyDown(jumpInput))
        {
            if (landed)
            {
                landed = false;
                animator.SetBool(boolJump, true);
                rb.velocity = Vector2.up * jumpForce.value;
                rb.transform.localScale = Vector2.one;
            }

            // DOTween.Kill(rb.transform);  *** ANTIGA CODIFICA��O DE ANIMA��O ***
            // landed = false; *** ANTIGA CODIFICA��O DE ANIMA��O ***
            // JumpingAnimation(); *** ANTIGA CODIFICA��O DE ANIMA��O ***
        }

    }

    /*  *** ANTIGA CODIFICA��O DE ANIMA��O ***
    
    // Anima��o chamada ao pular
    public void JumpingAnimation()
    {
        // Se estica ao pular
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    

    // Anima��o ao cair na plataforma
    public void OnLandingAnimation()
    {
        rb.transform.DOScaleY(landedScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(landedScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (landed) return;
        if (collision.transform.tag == lookingTag)
        {
            // Debug.Log("Player colidiu com o terreno");
            // DOTween.Kill(rb.transform);
            // OnLandingAnimation();
            animator.SetBool(boolJump, false);
            landed = true;
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    
}
