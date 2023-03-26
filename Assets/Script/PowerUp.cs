using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string namePowerUp;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ball")
        {
            if (namePowerUp == "BonusGoals")
            {
                Debug.Log("BonusGoals");
                col.GetComponent<Ball>().bonusGoal = true;
            }
            if (namePowerUp == "SpeedUp")
            {
                Debug.Log("SpeedUp");
                Ball ball = col.GetComponent<Ball>();
                ball.speed *= 2f;
            }
            
            if (namePowerUp == "ChangeDirect")
            {
                Debug.Log("ChangeDirect");
                Ball ball = col.GetComponent<Ball>();
                if (ball.isLastHit1)
                {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, Random.Range(-1, 1)) * ball.speed;
                }
                else
                {
                    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(1, Random.Range(-1, 1)) * ball.speed;
                }
            }
            Destroy(gameObject);
        }
    }

}
