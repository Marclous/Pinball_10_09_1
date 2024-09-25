using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb2D;
    public float ballVelocityY = 0f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.0f);
        Debug.DrawRay(transform.position, -Vector2.up);

        if (hit.collider != null)
        {
            //Debug.Log("Ray hit something: " + hit.collider.gameObject.name);

            //Debug.Log("Velocity is:" + rigidbody2D.velocity);

            if (rb2D.velocity.y < 0)
            {
                ballVelocityY = rb2D.velocity.y;
                Debug.Log(ballVelocityY);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        //Debug.Log("The ball collided with" + collider.gameObject.name);

        

        rb2D.velocity = new Vector2(0, -ballVelocityY);
        if (rb2D != null)
        {
            //Debug.Log("Ball Velocity is:" + rigidbody2D.velocity);
        }
    }
}
