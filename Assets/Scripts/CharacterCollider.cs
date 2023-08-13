using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラクターの当たり判定を行う
/// </summary>
public class CharacterCollider : MonoBehaviour
{
    SlopeChecker SlopeChecker;
    GroundChecker GroundChecker;
    private void Start()
    {
        SlopeChecker = GetComponent<SlopeChecker>();
        GroundChecker = GetComponent<GroundChecker>();
    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 collidedNormal = collision.contacts[0].normal;

        Vector3 v = Vector3.zero;
        v.x = collidedNormal.x;
        v.z = collidedNormal.z;
        v = v.normalized;
        float cosTheta = Vector3.Dot(collidedNormal, v);

        SlopeChecker.CosTheta = cosTheta;
        GroundChecker.CosTheta = cosTheta;
        SlopeChecker.IsCollided = true;
        GroundChecker.IsCollided = true;
    }
}
