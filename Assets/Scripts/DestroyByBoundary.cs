using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public float delayTime = 1.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "MainCamera")
        {
            return;
        }

        if(collision.collider.tag == "Player")
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            if (pc)
            {
                pc.OnDead();
            }
            return;
        }
        Destroy(collision.gameObject, delayTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerController pc = collider.gameObject.GetComponent<PlayerController>();
            if (pc)
            {
                pc.OnDead();
            }
            return;
        }
        Destroy(collider.gameObject, delayTime);
    }
}
