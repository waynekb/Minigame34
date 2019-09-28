using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop : MonoBehaviour
{
    public int s_taijie;
    public int s_yangguang;
    public int s_shuifen;
    public int s_yangfen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            print(gameObject.tag);
            switch (gameObject.tag)
            {
                case "台阶":
                    props.taijie += s_taijie;
                    break;
                case "阳光":
                    props.yangguang += s_yangguang;
                    break;
                case "水分":

                    break;
                case "养分":
                    props.yangfen += s_yangfen;
                    break;
                default:
                    break;

            }
        }
    }
}
