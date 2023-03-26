using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public bool isBounce;
    public bool bonusGoal;
    public bool isLastHit1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int random = Random.Range(0, 2);
        if (random == 0)
        {
            rb.velocity = Vector2.right * speed;
        }
        else
        {
            rb.velocity = Vector2.left * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 12 || transform.position.x < -12 || transform.position.y > 10 || transform.position.x < -10)
        {
            GameData.instace.SpawnBall();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Soundmanager.instance.BallBounceSfx();
        if (col.gameObject.tag == "Raket Red" && !isBounce)
        {
            Vector2 dir = new Vector2(1, 0).normalized;
            rb.velocity = dir * speed;
            StartCoroutine("Delaybounce");
            isLastHit1 = true;

        }

        if (col.gameObject.tag == "Raket Blue" && !isBounce)
        {
            Vector2 dir = new Vector2(-1, 0).normalized;
            rb.velocity = dir * speed;
            StartCoroutine("Delaybounce");
            isLastHit1 = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Goal 1")
        {
            Soundmanager.instance.GoalSfx();
            GameData.instace.player2Score++;
            Debug.Log("Goal");
            if (bonusGoal)
            {
                GameData.instace.player2Score++;
            }
            GameData.instace.SpawnBall();
            Destroy(gameObject);
            if (GameData.instace.goldenGoal)
            {
                Debug.Log("Goal1");
                GameData.instace.GameOver();
            }
        }

        if (col.gameObject.tag == "Goal 2")
        {
            Soundmanager.instance.GoalSfx();
            GameData.instace.player1Score++;
            if (bonusGoal)
            {
                GameData.instace.player1Score++;
            }
            GameData.instace.SpawnBall();
            Destroy(gameObject);
            if (GameData.instace.goldenGoal)
            {
                GameData.instace.GameOver();
            }
        }

    }

    private IEnumerator Delaybounce()
    {
        isBounce = true;
        yield return new WaitForSeconds(1f);
        isBounce = false;
    }
}
