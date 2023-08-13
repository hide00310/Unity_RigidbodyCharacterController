using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 地面のチェックを行う
/// </summary>
public class GroundChecker : MonoBehaviour
{
    public float MaxGroundCos = 0.5f; // 地面と判定する最大のcos
    public bool IsCollided; // 接触しているかどうか
    public float CosTheta; // 接触面の角度cos
    public bool IsGrounded; // 地面に接触しているかどうか

    void FixedUpdate()
    {
        if (!IsCollided)
        {
            IsGrounded = false;
            return;
        }
        IsCollided = false;
        float absCosTheta = Mathf.Abs(CosTheta);
        if (absCosTheta <= MaxGroundCos) IsGrounded = true;
        else IsGrounded = false;
    }
}
