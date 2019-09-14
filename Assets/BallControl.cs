using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D body;
    private int MinInitialSpeed = 5;
    private int MaxInitialSpeed = 9;

    // Start is called before the first frame update
    public void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // this has no delay 
        //this.ThrowBall();

        // this blows, because now you're indirectly calling methods
        Invoke("ThrowBall", 2);    // why not just call go ball?

        // this doesn't work because you can't set velocity outside 
        // of the main thread and Task.Run creates a new thread 
        //Task t = Task.Run(async () =>
        //{
        //    await Task.Delay(1000 * 2);
        //    this.ThrowBall();
        //});
        //t.Wait();

        // this however works
        //await Task.Delay(1000 * 2);
        //this.ThrowBall();
    }

    // randomly throw the ball in a direction 
    // used at the start of the game 
    void ThrowBall()
    {
        var r = new System.Random();
        // clear old velocity 
        body.velocity = Vector2.zero;

        // throw the ball right give or take 45 degrees
        // throw the ball left give or take 45 degrees

        // compute random degree 
        float angle = (float) r.NextDouble() * 45;

        // compute random sign 
        if(r.NextDouble() >= .5) {
            angle += 180;
        }

        // convert to radians 
        angle *= Mathf.Deg2Rad;

        // make a random magnitude 
        var range = this.MaxInitialSpeed - this.MinInitialSpeed;
        float magnitude = (float)r.NextDouble() * range + this.MinInitialSpeed;

        // make vector with trig functions 
        // set it 
        body.velocity = new Vector2(Mathf.Cos(angle) * magnitude, Mathf.Sin(angle) * magnitude);
    }

    public void ResetBall()
    {
        // reset ball to initial conditions
        body.position = Vector2.zero;
        body.velocity = Vector2.zero;
        this.transform.position = Vector2.zero;
    }

    public void RestartGame()
    {
        this.ResetBall();
        //await Task.Delay(1000 * 1);
        //this.ThrowBall();
        Invoke("ThrowBall", 2);
    }

    //???
    private void OnCollisionEnter(Collision collision)
    {
        // if we hit the paddle 
        if(collision.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = body.velocity.x;
            vel.y = (body.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            body.velocity = vel;
        }
    }
}
