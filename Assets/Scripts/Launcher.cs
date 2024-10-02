using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Rigidbody2D launcherRB;
    bool isGrounded = true;
    public int launchForce;

    // Start is called before the first frame update
    void Start()
    {
        launcherRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(isGrounded) launcherRB.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
        }
    }
}
