using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player = null;
    public Vector3 lerpSpeed = Vector3.zero;
    public Vector3 activeDist = Vector3.zero;
    private Rigidbody2D rigid = null;

    private void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        if(rigid == null)
        {
            rigid = gameObject.AddComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        Vector3 position = player.transform.position - transform.position;
        Vector3 velocity = Vector3.zero;

        if(Mathf.Abs(position.x) > activeDist.x)
        {
            velocity.x = Time.deltaTime * lerpSpeed.x * Mathf.Sign(position.x);
        }

        if (Mathf.Abs(position.y) > activeDist.y)
        {
            velocity.y = Time.deltaTime * lerpSpeed.y * Mathf.Sign(position.y);
        }

        if (rigid)
        {
            rigid.velocity = velocity;
        }
    }
}
