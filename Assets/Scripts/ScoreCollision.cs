using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    // Score
    private GameManager gameManager;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("GameManager");
        gameManager = obj.GetComponent<GameManager>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collider){
        gameManager.currentScore += 10;
    }
}
