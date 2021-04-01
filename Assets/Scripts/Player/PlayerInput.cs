﻿using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float movement = 0;
    [HideInInspector] public Vector3 mousePos = Vector3.zero;
    [HideInInspector] public bool attack = false;
    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool jumpEnter = false;
    [HideInInspector] public bool jumpExit = false;
    [HideInInspector] public bool grab = false;

    [SerializeField] private float smoothRate = 1;
    [SerializeField] private Camera cam = null;

    private void Update()
    {
        movement = Mathf.MoveTowards(movement, InputManager.Instance.GetAxisRaw("Horizontal"), smoothRate);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        attack = InputManager.Instance.GetButtonDown("Attack");
        jump = InputManager.Instance.GetButton("Jump");
        jumpEnter = InputManager.Instance.GetButtonDown("Jump");
        jumpExit = InputManager.Instance.GetButtonUp("Jump");
        grab = InputManager.Instance.GetButton("Grab");
    }
}
