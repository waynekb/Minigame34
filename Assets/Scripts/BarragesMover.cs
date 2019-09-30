using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarragesMover : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 rotation = Vector2.zero;

    public float destroyTime = 10.0f;

    private void Start()
    {
        float zRotation = Random.Range(rotation.x, rotation.y);
        transform.Rotate(0.0f, 0.0f, zRotation);

        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right;
    }
}
