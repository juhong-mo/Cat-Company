using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //------------------------------------------------Declaration
    //Data
    public EnemyData enemyData;
    public Transform finalTarget;

    //Components
    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private ScanLogic scanLogic;
    private EnemyLogic enemyLogic;
    private EnemyAnimator enemyAnimator;
    private LayerSettings layerSettings;

    //States
    private enum State
    {
        Die,
        Idle,
        Move,
        MoveToTarget,
        Attack
    }
    State state;

    //Current Data
    public float hp;
    private float coolTime;

    //------------------------------------------------Declaration end


    //------------------------------------------------Init & Debug
    private void Awake()
    {
        //Init
        //Init Component
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        scanLogic = GetComponent<ScanLogic>();
        enemyLogic = GetComponent<EnemyLogic>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        layerSettings = GetComponent<LayerSettings>();

        //Init State
        state = State.Idle;

        //Init EnemyData
        enemyData.Init();

        //Init current Data
        hp = enemyData.data.hp;
        coolTime = 0;
    }

    private void OnEnable()
    {
        hp = enemyData.data.hp;
        coolTime = 0;
    }


    private void Start()
    {
        //Debug
        //EnemyData null -> set Active false this
        if (enemyData == null)
        {
            Debug.Log("Enemy data missing");
            this.gameObject.SetActive(false);
            return;
        }
    }
    //------------------------------------------------Init & Debug end


    //------------------------------------------------Enemy AI
    private void FixedUpdate()
    {
        //Nearest target to this
        Transform nearestTarget;

        //Scan -> Set nearestTarget -> Check state
        scanLogic.Scan(enemyData.data.scanRange, layerSettings.layerAlly);
        nearestTarget = scanLogic.GetNearest();
        state = StateCheck(nearestTarget);

        //Cooldown for Attack
        Cooldown(enemyData.data.cooldown);

        //Do AI with EnemyLogic
        switch (state)
        {
            case State.Die:
                enemyLogic.Die();
                break;

            case State.Idle:
                break;

            case State.Move:
                enemyLogic.MoveToTarget(rigid, finalTarget, enemyData.data.speed);
                break;

            case State.Attack:
                if (Cooldown())
                    enemyLogic.Attack(nearestTarget, enemyData.data.damage, enemyData.data.cooldown);
                break;

            case State.MoveToTarget:
                enemyLogic.MoveToTarget(rigid, nearestTarget, enemyData.data.speed);
                break;

            default:
                break;
        }

        //Do not slip
        rigid.velocity = Vector2.zero;

    }
    //------------------------------------------------Enemy AI end


    //------------------------------------------------Enemy Animation
    private void LateUpdate()
    {
        Transform nearestTarget;
        nearestTarget= scanLogic.GetNearest();



        //Do Animation with EnemyAnimator
        switch (state)
        {
            case State.Die:
                enemyAnimator.Die();
                break;

            case State.Idle:
                break;

            case State.Move:
                enemyAnimator.Move(spriter, finalTarget);
                break;

            case State.Attack:
                if(Cooldown())
                {
                    enemyAnimator.Attack(spriter, nearestTarget);
                    CooldownReset(enemyData.data.cooldown);
                }
                break;

            case State.MoveToTarget:
                enemyAnimator.MoveToTarget(spriter, nearestTarget);
                break;
                
            default:
                break;
        }



        //Active false
        if(hp < 0)
        {
            gameObject.SetActive(false);
        }
    }
    //------------------------------------------------Enemy Animation end


    //------------------------------------------------Method

    /** StateCheck Method
     * check State with ScanLogic & EnemyData
     * this hp 0                                  -> return Die
     * finalTarget is null                      -> return Idle
     * nearestTarget is null                    -> return Move
     * nearestTarget distance less than attackRange -> return Attack
     * nearestTarget distance less than scanRange -> return MoveToTarget
     */
    private State StateCheck(Transform nearestTarget)
    {
        if (hp <= 0)
        {
            return State.Die;
        }
        if (finalTarget == null)
        {
            return State.Idle;
        }
        if (nearestTarget == null)
        {
            return State.Move;
        }

        // Distance between this and nearestTarget
        float nearestTargetDis;
        nearestTargetDis = Vector2.Distance(nearestTarget.position, transform.position);

        if (nearestTargetDis < enemyData.data.attackRange)
        {
            return State.Attack;
        }
        if (nearestTargetDis < enemyData.data.scanRange)
        {
            return State.MoveToTarget;
        }
        
        return state;
    }



    /** Hit Method
     * hit trigger on
     * take damage
     */
    public void Hit(float damage)
    {
        hp -= damage;
    }



    /** Cooldown Methods
     */
    //cooldown for fixedUpdate
    private void Cooldown(float cooldown)
    {
        coolTime -= Time.fixedDeltaTime;
    }

    //check restTime
    private bool Cooldown()
    {
        if(coolTime <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //reset restTime
    private void CooldownReset(float cooldown)
    {
        coolTime = cooldown;
    }



    //------------------------------------------------Method end

}
