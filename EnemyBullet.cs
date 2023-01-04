using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground" || target.gameObject.tag == "Player" || target.gameObject.tag == "deadly" || target.gameObject.tag == "enemydamage")
        {
            Destroy(gameObject);
        }
       
    }

}
