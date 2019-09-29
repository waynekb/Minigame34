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
                    GameObject.Find("hero").GetComponent<PlayerController>().AddPlatformNum(1);
                    break;
                case "阳光":
                    GameObject.Find("hero").GetComponent<PlayerController>().AddLifeNum(1);
                    break;
                case "水分":
                    GameObject.Find("hero").GetComponent<PlayerController>().AddEnergyNum(1);
                    break;
                case "养分":
                    GameObject.Find("hero").GetComponent<PlayerController>().AddRespawnNum(1);
                    break;
                default:
                    break;

            }
        }
    }
}
