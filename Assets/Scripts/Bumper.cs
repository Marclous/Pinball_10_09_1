using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    // Start is called before the first frame update
    public int bumperValue = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Ball") 
        { 
            GameManager.Instance.currentScore += bumperValue;
            Debug.Log("Current Score" + GameManager.Instance.currentScore);
        }
    }
}