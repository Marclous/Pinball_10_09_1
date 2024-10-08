using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLost : MonoBehaviour
{
    private GameManager gameManager;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        gameManager.BallLost(collision.gameObject);
    }
}
