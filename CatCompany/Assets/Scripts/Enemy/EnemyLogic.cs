using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    //------------------------------------------------AI
    //Die
    //do nothing
    public void Die()
    {

    }


    //Idle
    //do nothing


    //Move
    //move to base
    public void Move(Rigidbody2D rigid, Transform finalTarget, float speed)
    {
        Vector2 dirVec = finalTarget.position - transform.position;
        Vector2 moveVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }


    //MoveToTarget
    //move to nearestTarget
    public void MoveToTarget(Rigidbody2D rigid, Transform nearestTarget, float speed)
    {
        Vector2 dirVec = nearestTarget.position - transform.position;
        Vector2 moveVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }


    //Attack
    //
    public void Attack(Transform nearestTarget, float attack, float cooldown)
    {
        //set target gameObject
        GameObject target;
        target = nearestTarget.transform.gameObject;

        //call Hit from target
        target.GetComponent<AllyController>().Hit(attack);
    }
    //------------------------------------------------AI end


    //------------------------------------------------Method


    


    //------------------------------------------------Method end
}