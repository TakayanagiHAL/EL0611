using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Player.ATTACKRANGE atrg;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            player.SetTarget(atrg, collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            player.SetTarget(atrg, null);
        }

    }


}
