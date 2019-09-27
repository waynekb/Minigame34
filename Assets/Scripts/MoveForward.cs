using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 1.0f;
    public int dir = 1;
    public float left = 0.0f;
    public float right = 1.0f;

    public bool bIsRandomSpeed;
    public Vector2 randomSpeedLimit;

    private void Start()
    {
        if (bIsRandomSpeed)
        {
            speed += Random.Range(randomSpeedLimit.x, randomSpeedLimit.y);
        }
    }

    private void Update()
    {
        Vector3 position = transform.position;
        position.x += speed * Time.deltaTime;
        transform.position = position;
        if(position.x < left || position.x > right)
        {
            speed *= dir;
            transform.forward = -transform.forward;
        }
    }
}
