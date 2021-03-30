using UnityEngine;
using System.Collections.Generic;
using System;

public class InputManager : Singleton<InputManager>
{
    private Dictionary<string, KeyCode> Buttons = new Dictionary<string, KeyCode>
    {
        ["Grab"] = KeyCode.LeftShift,
        ["Attack"] = KeyCode.Mouse0,
        ["Jump"] = KeyCode.Space
    };

    public void ChangeBinding(string button, KeyCode value, InputChanger changer)
    {
        if (changer)
        {
            Buttons[button] = value;
        }
    }

    private void TestKey(string key)
    {
        if (!Buttons.ContainsKey(key))
        {
            throw new Exception("Button not found.");
        }
    }

    public bool GetButtonDown(string button)
    {
        TestKey(button);
        return Input.GetKeyDown(Buttons[button]);
    }

    public bool GetButton(string button)
    {
        TestKey(button);
        return Input.GetKey(Buttons[button]);
    }

    public bool GetButtonUp(string button)
    {
        TestKey(button);
        return Input.GetKeyUp(Buttons[button]);
    }

    public float GetAxisRaw(string axis)
    {
        return Input.GetAxisRaw(axis);
    }
}
