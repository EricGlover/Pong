using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // check for inputs 
        // set vel 
        var v = body.velocity;
        if (Input.GetKey(moveUp))
        {
            v.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            v.y = -speed;
        } else {
            v.y = 0;
        }
        body.velocity = v;

        //check boundary box
        var position = body.position;
        if(position.y > boundY) {
            position.y = boundY;
        } else if (position.y < -boundY) {
            position.y = -boundY;
        } 
        body.position = position;
    }
}
