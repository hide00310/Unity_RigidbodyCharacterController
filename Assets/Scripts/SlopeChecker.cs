using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 坂のチェックを行う
/// </summary>
public class SlopeChecker : MonoBehaviour
{
    public float MinSlopeCos = 0.1f; // 坂と判定する最小のcos
    public float MaxSlopeCos = 0.9f; // 坂と判定する最大のcos
    public float GravityGain = 1e-3f; // 反転重力に掛ける係数
    public bool IsCollided; // 接触しているかどうか
    public float CosTheta; // 接触面の角度cos
    Rigidbody CharacterRigidbody;
    GravityCharacterController GravityCharacterController;
    Vector3 Force;

    private void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
        GravityCharacterController = GetComponent<GravityCharacterController>();
    }

    void FixedUpdate()
    {
        if (!IsCollided)
        {
            GravityCharacterController.IsEnabledGravity = true;
            return;
        }
        IsCollided = false;
        
        float absCosTheta = Mathf.Abs(CosTheta);
        if ((absCosTheta >= MinSlopeCos) && (absCosTheta <= MaxSlopeCos))
        {
            Force.y = -GravityCharacterController.Gravity * GravityGain;
            CharacterRigidbody.AddForce(Force, ForceMode.Acceleration);
            GravityCharacterController.IsEnabledGravity = false;
        }
        else
        {
            GravityCharacterController.IsEnabledGravity = true;
        }
    }
}
