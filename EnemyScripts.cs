using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    public float forceY = 300f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float eHealth = 4f;
    public float eHealthBurn = 1f;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        forceY = Random.Range(250, 400);
        myRigidbody.AddForce(new Vector2(0, forceY));
        myAnimator.SetBool("attack", true);
        yield return new WaitForSeconds(1.5f);
        myAnimator.SetBool("attack", false);
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "enemydamage")
        {
            EUpdateHealth();
        }
    }

    void EUpdateHealth()
    {
        if (eHealth > 0)
        {
            eHealth -= eHealthBurn;
        }
        if (eHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
