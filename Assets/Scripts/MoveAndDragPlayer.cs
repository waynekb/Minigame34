using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndDragPlayer : MonoBehaviour
{
    public float speed = 0.5f;
    [HideInInspector]
    public int dir = 1;

    private Transform player = null;

    private void Update()
    {
        Move(transform);
        DragPlayer();
    }

    private void Move(Transform trans)
    {
        Vector3 position = trans.position;
        position.x = trans.position.x + Time.deltaTime * speed * dir;
        trans.position = position;
    }

    private void DragPlayer()
    {
        if(player == null)
        {
            return;
        }

        Move(player);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            player = collision.collider.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            player = null;
        }
    }
}
