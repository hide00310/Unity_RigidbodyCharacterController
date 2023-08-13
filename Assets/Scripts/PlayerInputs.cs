using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーの入力
/// </summary>
public class PlayerInputs : MonoBehaviour
{
    public float HorizontalAxis = 0;
    public float VerticalAxis = 0;
    public float RotateAxis = 0;
    public bool JumpButton = false;

    private void Update()
    {
        JumpButton = Input.GetButton("Jump");
        HorizontalAxis = Input.GetAxis("Horizontal");
        VerticalAxis = Input.GetAxis("Vertical");
        RotateAxis = GetRotateAxis();
    }

    private float GetRotateAxis()
    {
        float ret = 0;
        if (Input.GetKey(KeyCode.E)) ret = 1;
        else if (Input.GetKey(KeyCode.Q)) ret = -1;
        return ret;
    }
}
