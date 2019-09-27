using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour
{
    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;               // Condition for whether the player should jump.


    public float moveForce = 8f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 0.4f;             // The fastest the player can travel in the x axis.

    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Horizontal");

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // 加一个力
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

        if (v * GetComponent<Rigidbody2D>().velocity.y < maxSpeed)
            // 加一个力
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * Mathf.Abs(h/2*3) * moveForce);


        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, maxSpeed);

        // If the player's horizontal velocity is greater than the maxSpeed...
      //  if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,maxSpeed);

    }
}
