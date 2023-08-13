using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーの入力をもとにキャラクターを動かす
/// </summary>
public class PlayerCharacterController : MonoBehaviour
{
    public float JumpForce; // ジャンプ力
    public float MoveSpeed; // 水平移動の目標速度
    public float RotateSpeed; // 回転速度
    public float Kp; // P項係数

    public Vector3 Speed;

    PlayerInputs PlayerInputs;
    GroundChecker GroundChecker;
    Rigidbody CharacterRigidbody;

    Vector3 JumpForceVec = Vector3.zero;
    Vector3 MoveDirectionVec = Vector3.zero;
    Vector3 JumpDirectionVec = Vector3.zero;
    Vector3 MoveSpeedErr = Vector3.zero;

    private void Start()
    {
        PlayerInputs = GetComponent<PlayerInputs>();
        CharacterRigidbody = GetComponent<Rigidbody>();
        GroundChecker = GetComponent<GroundChecker>();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if (PlayerInputs.JumpButton && GroundChecker.IsGrounded)
        {
            JumpDirectionVec.x = MoveDirectionVec.x;
            JumpDirectionVec.z = MoveDirectionVec.z;
            JumpDirectionVec.y = 1.0f - (Mathf.Abs(JumpDirectionVec.x) + Mathf.Abs(JumpDirectionVec.z));
            JumpForceVec = JumpDirectionVec * JumpForce;
            CharacterRigidbody.AddForce(JumpForceVec, ForceMode.Impulse);
        }
    }

    void Move()
    {
        MoveDirectionVec = transform.forward * PlayerInputs.VerticalAxis + transform.right * PlayerInputs.HorizontalAxis;        
        Vector3 tgtMoveSpeed = MoveDirectionVec * MoveSpeed;
        MoveSpeedErr = tgtMoveSpeed - CharacterRigidbody.velocity;
        MoveSpeedErr.y = 0;
        Vector3 force = MoveSpeedErr * Kp;
        CharacterRigidbody.AddForce(force, ForceMode.Force);
        float rotateSpeed = RotateSpeed * PlayerInputs.RotateAxis;
        CharacterRigidbody.transform.Rotate(0, rotateSpeed * Time.fixedDeltaTime, 0);

        Speed = CharacterRigidbody.velocity;
    }
}
