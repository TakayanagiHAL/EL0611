using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    [SerializeField]
    private bool m_Direction;
    private float m_DeadStartTime;
    [SerializeField]
    private int m_Life;
    [SerializeField]
    private int m_Attack;
    [SerializeField]
    private float m_AttackInterval;
    private float m_AttackStartTime;
    private float m_HitStartTime;
    [SerializeField]
    private RuntimeAnimatorController[] EnemyAnimatorControllers = new RuntimeAnimatorController[4];
    [SerializeField]
    private Sprite[] m_Sprites = new Sprite[4];
    private Animator EnemyAnimator;
    private int m_Type = 0;
    private bool m_IsHit;
    enum EnemyState
    {
        State_Normal,
        State_Attack,
        State_Hit,
        State_Dead,
    }

    [SerializeField]
    private EnemyState m_State;

    // Start is called before the first frame update
    void Start()
    {
        EnemyAnimator = gameObject.GetComponent<Animator>();
        EnemyAnimator.runtimeAnimatorController = EnemyAnimatorControllers[m_Type];
        StateChange(EnemyState.State_Normal);
        m_AttackInterval = 2.0f;
        m_IsHit = false;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateState();
       

    }

    private void UpdateState()
    {
        Vector3 pos = gameObject.transform.position;
        switch (m_State)
        {
            case EnemyState.State_Normal:
                
                pos.x += (m_Direction ? 1.0f : -1.0f) * Time.deltaTime * m_Speed;
                gameObject.transform.position = pos;

                if(m_IsHit)
                {
                    StateChange(EnemyState.State_Attack);
                }
                break;
            case EnemyState.State_Attack:

                if(Time.time - m_AttackStartTime > m_AttackInterval)
                {
                    EnemyAnimator.SetTrigger("Attack");
                    m_AttackStartTime = Time.time;
                }
               
                break;
            case EnemyState.State_Hit:

                pos.x -= (m_Direction ? 1.0f : -1.0f) * Time.deltaTime * m_Speed * 3.0f;

                if(Time.time - m_HitStartTime >0.5)
                {
                    StateChange(EnemyState.State_Normal);
                }

                break;
            case EnemyState.State_Dead:
            
                pos.y -= Time.deltaTime * m_Speed;
                gameObject.transform.position = pos;

                if(Time.time - m_DeadStartTime > 2.0)
                {
                    Destroy(gameObject);
                }
                break;

        }
    }

    private void StateChange(EnemyState enemyState)
    {
        if (m_State == enemyState) return;

        m_State = enemyState;

        switch (enemyState)
        {
            case EnemyState.State_Normal:
                EnemyAnimator.SetBool("Run", true);
                break;

            case EnemyState.State_Attack:
                EnemyAnimator.SetBool("Run", false);
                m_AttackStartTime = Time.time;
                break;

            case EnemyState.State_Hit:
                m_HitStartTime = Time.time;
                break;
            case EnemyState.State_Dead:
                EnemyAnimator.SetTrigger("Death");
                m_DeadStartTime = Time.time;
                break;
        }
    }

    public void EnemyHit()
    {
        EnemyAnimator.SetBool("Run", false);
        EnemyAnimator.SetTrigger("Hit");

        m_Life--;

        if(m_Life <= 0)
        {
            StateChange(EnemyState.State_Dead);
        }
        else
        {

            StateChange(EnemyState.State_Hit);
        }
    }

    public void Init(int type,bool dir,float speed,int life, int attack = 1)
    {
        m_Type = type;
        m_Direction = dir;
        m_Speed = speed;
        m_Life = life;
        m_Attack = attack;

       
        gameObject.GetComponent<SpriteRenderer>().flipX = !m_Direction;
        
    }

    public int GetAttack()
    {
        return m_Attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            m_IsHit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_IsHit = false;
        }
    }

}
