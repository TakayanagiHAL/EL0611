using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Player.ATTACKRANGE atrg;

    public bool attackFlag;

    private void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!attackFlag) return;

        if (collision.tag == "Enemy")
        {
            //player.SetTarget(atrg, collision.gameObject);

            Destroy(collision.gameObject);

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
