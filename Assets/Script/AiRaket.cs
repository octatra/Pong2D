using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRaket : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Npc seting")]
    public float speed;
    public float deleymove;

    private bool isMoveAI;
    private float randomPos;
    private bool isSingletake;
    private bool isUp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        if (GameData2.instace.isSinglePlayer)
        {
            if (!isMoveAI && !isSingletake)
            {
                StartCoroutine("DelayAiMove");
                isSingletake = true;
            }

            if (isMoveAI)
            {
                MoveAI();
            }

        }
    }

    private IEnumerator DelayAiMove()
    {
        yield return new WaitForSeconds(deleymove);
        randomPos = Random.Range(-1.65f, 1.65f);

        if(transform.position.y < randomPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        isSingletake = false;
        isMoveAI = true;
    }

    private void MoveAI()
    {
        if (!isUp)
        {
            rb.velocity = new Vector2(0, -1) * speed;
            if (transform.position.y <= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

        if (isUp)
        {
            rb.velocity = new Vector2(0, 1) * speed;
            if (transform.position.y >= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

    }
}
