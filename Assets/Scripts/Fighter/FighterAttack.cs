using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterAttack : MonoBehaviour
{
    public float HandHitboxRadius = 0.6f;

    public Transform LeftHand;
    public Transform RightHand;

    public Animator Animator;

    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(LeftHand.position, HandHitboxRadius);

        foreach (var hit in hits)
        {
            Debug.Log($"Hit: {hit.name}");
        }

        Animator.ResetTrigger("Attack");
    }
}
