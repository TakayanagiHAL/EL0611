using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    enum DIRECTION
    {
        LEFT,
        RIGHT
    }

    public enum ATTACKRANGE
    {
        RIGHTUP,
        RIGHTMIDDLE,
        RIGHTDOWN,
        LEFTUP,
        LEFTMIDDLE,
        LEFTDOWN,
        MAX

    }

    DIRECTION dir;
    [SerializeField] DIRECTION defaultDir;

    [SerializeField] int life;
    [SerializeField] int attack;

    [SerializeField] GameObject[] targets = new GameObject[(int)ATTACKRANGE.MAX];

    int cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        dir = defaultDir;
        
    }

    // Update is called once per frame
    void Update()
    {

        //��������
        if (Input.GetKeyDown(KeyCode.RightArrow)) TurnAround(DIRECTION.RIGHT);
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) TurnAround(DIRECTION.LEFT);

        //�U��
        Attack();


        //TargetReset();
    }


    //�U�����
    void TurnAround(DIRECTION s_dir)
    {

        dir = s_dir;

        if (dir != defaultDir)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    void Attack()
    {

        //��i
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (dir == DIRECTION.RIGHT) EnemyBreak(targets[(int)ATTACKRANGE.RIGHTUP]);
            else if (dir == DIRECTION.LEFT) EnemyBreak(targets[(int)ATTACKRANGE.LEFTUP]);
        }
        //���i
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (dir == DIRECTION.RIGHT) EnemyBreak(targets[(int)ATTACKRANGE.RIGHTMIDDLE]);
            else if (dir == DIRECTION.LEFT) EnemyBreak(targets[(int)ATTACKRANGE.LEFTMIDDLE]);
        }
        //���i
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            if (dir == DIRECTION.RIGHT) EnemyBreak(targets[(int)ATTACKRANGE.RIGHTDOWN]);
            else if (dir == DIRECTION.LEFT) EnemyBreak(targets[(int)ATTACKRANGE.LEFTDOWN]);
        }

    }

    void Damage(int s_damage)
    {

        life -= s_damage;
    }

    public void SetTarget(ATTACKRANGE arg,GameObject s_target)
    {
        targets[(int)arg] = s_target;
    }


    void EnemyBreak(GameObject s_target)
    {

        if (s_target == null) return;

        //��
        Destroy(s_target);

    }

    void TargetReset()
    {

        cnt++;

        if (cnt < 5) return;

        for(int i = 0; i < (int)ATTACKRANGE.MAX; i++)
        {
            targets[i] = null;
        }

        cnt = 0;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //��
        Damage(1);

        EnemyBreak(collision.gameObject);

    }

}
