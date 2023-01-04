using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter: MonoBehaviour
{
    [SerializeField]
    private GameObject bullet; //this will be the fireball or enemy projectile


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }


    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        //this attatches the bullet to the position of the shooter

        Instantiate(bullet, transform.position, Quaternion.identity);
        //this begins the coroutine
        //Instantiate means to bring into being
        StartCoroutine (Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
