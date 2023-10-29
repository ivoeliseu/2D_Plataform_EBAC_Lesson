using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Movimente Setup")]
    public float moveVelocity = 15f;
    public float runningVelocity = 30f;
    public float jumpForce = 30f;

    [Header("Animation Setup")]
    public string lookingTag = "Ground";
    public float jumpScaleY = 3f;
    public float jumpScaleX = .75f;
    public float landedScaleY = .75f;
    public float landedScaleX = .3f;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;
   
    public bool landed = false;


    public Vector2 friction = new Vector2(.1f, 0);

    void Update()
    {
        PlayerJump();
        PlayerMoviment();
    }
    private void PlayerMoviment()
    {
        // Inputs de movimentação

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? -runningVelocity : -moveVelocity, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2((Input.GetKey(KeyCode.LeftShift)) ? +runningVelocity : moveVelocity, rb.velocity.y);
        }

        // Desaceleração
        // No objeto dentro da Unity é necessário o objeto da plataforma ter um material de physics
        if(rb.velocity.x > 0)
        {
            rb.velocity -= friction;
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity += friction;
        }
    }

    // Função que faz o jogador pular
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            rb.transform.localScale = Vector2.one;
            DOTween.Kill(rb.transform);
            landed = false;
            JumpingAnimation();
        }

    }

    // Animação chamada ao pular
    public void JumpingAnimation()
    {
        // Se estica ao pular
        rb.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    // Animação ao cair na plataforma
    public void OnLandingAnimation()
    {
        rb.transform.DOScaleY(landedScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rb.transform.DOScaleX(landedScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (landed) return;
        if (collision.transform.tag == lookingTag)
        {
            Debug.Log("Player colidiu com o terreno");
            DOTween.Kill(rb.transform);
            OnLandingAnimation();
            landed = true;
        }
    }
}
