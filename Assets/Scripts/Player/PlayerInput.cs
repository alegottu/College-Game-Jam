﻿using UnityEngine;

// Try event-based input
public class PlayerInput : MonoBehaviour
{
    // make read-only outside of this script

    [HideInInspector] public float movement = 0;
    [HideInInspector] public bool attack = false;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool jumpEnter = false;
    [HideInInspector] public bool jumpExit = false;
    [HideInInspector] public bool grab = false;
    [HideInInspector] public bool grabEnter = false;

    [SerializeField] private float smoothRate = 1;

    private void Update()
    {
        movement = Mathf.MoveTowards(movement, InputManager.Instance.GetAxisRaw("Horizontal"), smoothRate);
        attack = InputManager.Instance.GetButtonDown("Attack");
        jump = InputManager.Instance.GetButton("Jump");
        jumpEnter = InputManager.Instance.GetButtonDown("Jump");
        jumpExit = InputManager.Instance.GetButtonUp("Jump");
        grab = InputManager.Instance.GetButton("Grab");
        grabEnter = InputManager.Instance.GetButtonDown("Grab");
    }
}
