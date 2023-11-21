using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Moviment Setup")]
    public float moveVelocity;
    public float runningVelocity;
    public float jumpForce;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Animation Player")]
    public string boolRun = "Run";
    public string boolJump = "Jump";
    public string triggerDeath = "Death";
    
    public float swipeSideDuration = 0;
    public bool landed = false;
    public string groundTag = "Ground";


    [Header("Controls Input")]
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode moveLeftInput = KeyCode.LeftArrow;
    public KeyCode moveRightInput = KeyCode.RightArrow;
    public KeyCode runningInput = KeyCode.LeftShift;
}
