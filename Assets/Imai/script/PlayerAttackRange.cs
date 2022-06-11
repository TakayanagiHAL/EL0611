using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Player.ATTACKRANGE atrg;

    public bool attackFlag;
    float waitTime = 0.1f;
    public float timer = 0;

    private void Update()
    {
        //Debug.Log("t " + timer);
        //attackFlag���K�p����Ă��班�������čU��
        if (attackFlag) {
            timer += Time.deltaTime;
            Debug.Log("t " + timer);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        //Debug.Log(timer);

        if (!attackFlag) return;

        timer += Time.deltaTime;

        if (timer <= waitTime) return;

        if (collision.tag == "Enemy")
        {
            //player.SetTarget(atrg, collision.gameObject);

            collision.GetComponent<Enemy>().EnemyHit();

            //Destroy(collision.gameObject);

            SoundManager.instance.PlaySE("�a��");

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            //player.SetTarget(atrg, null);
        }

    }


}
