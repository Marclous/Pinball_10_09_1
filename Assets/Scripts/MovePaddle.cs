using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D paddlerb;
    HingeJoint2D hingeJoint2D;
    void Start()
    {
        paddlerb = GetComponent<Rigidbody2D>();
        hingeJoint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            paddlerb.AddForce(Vector2.up * 50f, ForceMode2D.Impulse);
            
        }
    }

    void FixedUpdate() {
       
    }
}
