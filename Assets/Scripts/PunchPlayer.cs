using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPlayer : MonoBehaviour {

    public PlayerScript playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PlayerScript.TAG_PLAYER)
        {
            if (playerScript.gameObject != collision.gameObject)
            {
                PlayerScript.AttackProperties attackProperties = playerScript.GetCurrentAttack;
                if (attackProperties.damage != 0 && attackProperties.IsAttack)
                {
                    collision.gameObject.GetComponent<PlayerScript>().DamagePlayer(attackProperties.damage);
                }
            }
        }
    }
}
