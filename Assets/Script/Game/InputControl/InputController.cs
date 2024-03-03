using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InputController
{
    [SerializeField]private InputConfig inputConfig;
    public InputConfig Config => inputConfig;

    public bool IsMoving()
    {
        return (Input.GetKey(inputConfig.downKey) ||
            Input.GetKey(inputConfig.leftKey) ||
            Input.GetKey(inputConfig.rightKey) ||
            Input.GetKey(inputConfig.upKey));
    }
    public bool IsInteracting()
    {
        return Input.GetKey(inputConfig.interactiveKey);
    }
    public KeyCode GetInteractiveKey()
    {
        return Config.interactiveKey;
    }
}
