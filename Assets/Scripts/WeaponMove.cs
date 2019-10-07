using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    public Vector3 velocity = Vector3.zero;
    public Vector3 gravity = Vector3.zero;
    public float mass = 1.0f;
    private Rigidbody2D rigid = null;
    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();

        if (rigid == null)
        {
            rigid = gameObject.AddComponent<Rigidbody2D>();
            rigid.mass = mass;
            rigid.gravityScale = 0.0f;
            rigid.drag = 0.0f;
            rigid.angularDrag = 0.0f;
            rigid.freezeRotation = true;
        }
        rigid.velocity = velocity;

        BoxCollider2D box = gameObject.GetComponent<BoxCollider2D>();
        if (box)
        {
            box.isTrigger = true;
        }
    }
    private void FixedUpdate()
    {
        if (rigid)
        {
            rigid.AddForce(gravity);
        }
    }
}
