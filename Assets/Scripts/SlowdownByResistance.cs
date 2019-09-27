using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownByResistance : MonoBehaviour
{
    public float resistanceRate;

    private Vector3 velocity;
    [SerializeField]
    private float activeThreshold = 1.0f;

    public void SetInitVelocity(Vector3 initVelocity)
    {
        velocity = initVelocity;
    }

    private void Update()
    {
        //Move();
    }

    private void Move()
    {
        if(velocity.sqrMagnitude > activeThreshold)
        {
            velocity -= resistanceRate * Time.deltaTime * velocity;
            transform.position += velocity * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            return;
        }
        
        if(rigidBody.velocity.sqrMagnitude > activeThreshold)
        {
            Vector3 resistanceForce = -resistanceRate * rigidBody.velocity;
            rigidBody.AddForce(resistanceForce);
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
            Destroy(rigidBody);
        }
    }
}
