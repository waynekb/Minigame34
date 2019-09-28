using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            print(gameObject.tag);
            switch (gameObject.tag)
            {
                case "台阶":
                    break;
                case "阳光":
                    break;
                case "水分":
                    break;
                case "肥料":
                    break;
                default:
                    break;

            }
        }
    }
}
