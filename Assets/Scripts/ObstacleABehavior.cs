using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleABehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider) {
        Debug.Log("collider" + collider.collider.gameObject.name);

        collider.otherCollider.attachedRigidbody.velocity = 2 *     new Vector2(0, ball.GetComponent<BallBehavior>().ballVelocityY);
    }
}
