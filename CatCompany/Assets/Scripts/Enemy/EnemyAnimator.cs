using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    //Die
    public void Die()
    {

    }

    //Idle

    //Move
    public void Move(SpriteRenderer spriter, Transform finalTarget)
    {
        //flip sprite
        spriter.flipX = finalTarget.position.x < transform.position.x;
    }

    //MoveToTarget
    public void MoveToTarget(SpriteRenderer spriter, Transform nearestTarget)
    {
        //flip sprite
        spriter.flipX = nearestTarget.position.x < transform.position.x;
    }

    //Attack
    public void Attack(SpriteRenderer spriter, Transform nearestTarget)
    {
        //flip sprite
        spriter.flipX = nearestTarget.position.x < transform.position.x;
    }
}
