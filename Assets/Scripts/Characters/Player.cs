using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System;

public class Player : MonoBehaviour
{
    public SOPlayerSetup playerSetup;
    public HpScript healthBase;
    public Rigidbody2D rb;
    public Animator animator;

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
        animator.SetTrigger(playerSetup.triggerDeath);
    }
    void Update()
    {
        PlayerJump();
        PlayerMoviment();
    }
    private void PlayerMoviment()
    {
        // Inputs de movimenta��o

        if (Input.GetKey(playerSetup.moveLeftInput))
        {
            animator.SetBool(playerSetup.boolRun, true);
            if (rb.transform.localScale.x != -1)
            {
                rb.transform.DOScaleX(-1f, playerSetup.swipeSideDuration);
            }

            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? -playerSetup.runningVelocity : -playerSetup.moveVelocity, rb.velocity.y);
        }
        else if (Input.GetKey(playerSetup.moveRightInput))
        {
            animator.SetBool(playerSetup.boolRun, true);
            if (rb.transform.localScale.x != 1)
            {
                rb.transform.DOScaleX(1f, playerSetup.swipeSideDuration);
            }

            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? playerSetup.runningVelocity : playerSetup.moveVelocity, rb.velocity.y);
        }
        else
        {
            animator.SetBool(playerSetup.boolRun, false);
        }

        // Se verificar que Input de correr est� pressionado, muda a velocidade da anima��o
        if (Input.GetKey(playerSetup.runningInput))
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
            rb.velocity -= playerSetup.friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += playerSetup.friction;
        }
    }

    // Fun��o que faz o jogador pular
    private void PlayerJump()
    {
        if (Input.GetKeyDown(playerSetup.jumpInput))
        {
            if (playerSetup.landed)
            {
                if (rb.transform.localScale.x != 1)
                {
                    rb.transform.DOScaleX(-1f, playerSetup.swipeSideDuration);
                }
                playerSetup.landed = false;
                animator.SetBool(playerSetup.boolJump, true);
                rb.velocity = Vector2.up * playerSetup.jumpForce;
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
        if (playerSetup.landed) return;
        if (collision.transform.tag == playerSetup.groundTag)
        {
            // Debug.Log("Player colidiu com o terreno");
            // DOTween.Kill(rb.transform);
            // OnLandingAnimation();
            animator.SetBool(playerSetup.boolJump, false);
            playerSetup.landed = true;
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }

    
}
