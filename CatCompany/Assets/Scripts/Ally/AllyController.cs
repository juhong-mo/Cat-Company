using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyController : MonoBehaviour
{
    //------------------------------------------------Declaration
    //Data
    public AllyData allyData;

    //Components
    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    private ScanLogic scanLogic;
    private AllyLogic allyLogic;
    private AllyAnimator allyAnimator;
    private LayerSettings layerSettings;

    public GameObject g1;
    public GameObject g2;
    public GameObject g3;


    //States
    private enum State
    {
        Die,
        Idle,
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
        allyLogic = GetComponent<AllyLogic>();
        allyAnimator = GetComponent<AllyAnimator>();
        layerSettings = GetComponent<LayerSettings>();

        //Init State
        state = State.Idle;

        //Init AllyData
        allyData.Init();

        //Init current Data
        hp = allyData.data.hp;
        coolTime = 0;
    }


    private void Start()
    {
        //Debug
        //AllyData null -> set Active false this
        if (allyData == null)
        {
            Debug.Log("Ally data missing");
            this.gameObject.SetActive(false);
            return;
        }
    }
    //------------------------------------------------Init & Debug end


    //------------------------------------------------Mouse WIP

    //Collider2D otherC = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //otherC = collision;
        if (collision.gameObject.tag == "1" && gameObject.tag == "3")
        {

            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);

            Instantiate(g1);
        }
        if (collision.gameObject.tag == "1" && gameObject.tag == "2")
        {

            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);


            Instantiate(g2);
        }
        if (collision.gameObject.tag == "2" && gameObject.tag == "2")
        {

            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);


            Instantiate(g3);
        }
    }
    private void OnMouseDrag()
    {
        Vector2 pos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (Vector3)pos;

        
    }


    //------------------------------------------------Mouse end


    //------------------------------------------------Ally AI
    private void FixedUpdate()
    {
        //Nearest target to this
        Transform nearestTarget;

        //Scan -> Set nearestTarget -> Check state
        scanLogic.Scan(allyData.data.scanRange, layerSettings.layerEnemy);
        nearestTarget = scanLogic.GetNearest();
        state = StateCheck(nearestTarget);

        Debug.Log(state);

        //Cooldown for Attack
        Cooldown(allyData.data.cooldown);

        //Do AI with AllyLogic
        switch (state)
        {
            case State.Die:
                allyLogic.Die();
                break;

            case State.Idle:
                break;

            case State.Attack:
                if (Cooldown())
                    allyLogic.Attack(nearestTarget, allyData.data.damage, allyData.data.cooldown);
                break;

            case State.MoveToTarget:
                allyLogic.MoveToTarget(rigid, nearestTarget, allyData.data.speed);
                break;

            default:
                break;
        }

        //Do not slip
        rigid.velocity = Vector2.zero;

    }
    //------------------------------------------------Ally AI end


    //------------------------------------------------Ally Animation
    private void LateUpdate()
    {
        Transform nearestTarget;
        nearestTarget = scanLogic.GetNearest();



        //Do Animation with AllyAnimator
        switch (state)
        {
            case State.Die:
                allyAnimator.Die();
                break;

            case State.Idle:
                break;

            case State.Attack:
                if (Cooldown())
                {
                    allyAnimator.Attack(spriter, nearestTarget);
                    CooldownReset(allyData.data.cooldown);
                }
                break;

            case State.MoveToTarget:
                allyAnimator.MoveToTarget(spriter, nearestTarget);
                break;

            default:
                break;
        }


        //Destroy this
        if (hp < 0)
        {
            gameObject.SetActive(false);
        }
    }
    //------------------------------------------------Ally Animation end


    //------------------------------------------------Method

    /** StateCheck
     * check State with ScanLogic & AllyData
     * this hp 0                                  -> return Die
     * nearestTarget is null                      -> return Idle
     * nearestTarget distance less than attackRange -> return Attack
     * nearestTarget distance less than scanRange -> return MoveToTarget
     */
    private State StateCheck(Transform nearestTarget)
    {
        if (hp <= 0)
        {
            return State.Die;
        }
        if (nearestTarget == null)
        {
            return State.Idle;
        }

        // Distance between this and nearestTarget
        float nearestTargetDis;
        nearestTargetDis = Vector2.Distance(nearestTarget.position, transform.position);

        if (nearestTargetDis < allyData.data.attackRange)
        {
            return State.Attack;
        }
        if (nearestTargetDis < allyData.data.scanRange)
        {
            return State.MoveToTarget;
        }

        return state;
    }



    /** Hit
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
        if (coolTime <= 0)
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
