using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラクターに重力を与える
/// </summary>
public class GravityCharacterController : MonoBehaviour
{
    public float Gravity = -15; // 重力
    public bool IsEnabledGravity; // 重力有効かどうか
    private Rigidbody CharacterRigidbody;
    private void Start()
    {
        CharacterRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (IsEnabledGravity)
        {
            CharacterRigidbody.AddForce(0, Gravity, 0, ForceMode.Acceleration);
        }
    }
}
