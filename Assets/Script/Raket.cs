using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raket : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    private Animator anim;
    public string axis = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(axis == "Vertical2" && GameData2.instace.isSinglePlayer)
        {
            return;
        }

        float vert = Input.GetAxis(axis);
        rb.velocity = new Vector2(0, vert) * speed;

        if(transform.position.y > 1.65f)
        {
            transform.position = new Vector2(transform.position.x, 1.65f);
        }

        if (transform.position.y < -1.65f)
        {
            transform.position = new Vector2(transform.position.x, -1.65f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Shoot");
        }
    }

}
