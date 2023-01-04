using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private Transform StartPos, EndPos;
    private bool collision;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Movement();
        Direction();
    }

    private void Movement()
    {
        rb.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    private void Direction()
    {
        collision = Physics2D.Linecast(StartPos.position, EndPos.position, 1 << LayerMask.NameToLayer("Player"));
        if (collision)
        {
            Vector2 temp = transform.localScale;
            if (temp.x == 1)
            {
                temp.x = -1f;
            }
            transform.localScale = temp;
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "ground" || target.gameObject.tag == "damage" || target.gameObject.tag == "deadly")
        {
            Destroy(gameObject);
        }
    }
}