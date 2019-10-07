using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop : MonoBehaviour
{
    public int energy = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            switch (gameObject.tag)
            {
                case "台阶":
                    print("taijie0");
                    GameObject.Find("hero").GetComponent<PlayerController>().AddPlatformNum(1);
                    break;
                case "阳光":
                    print("yangguang");
                    GameObject.Find("hero").GetComponent<PlayerController>().AddLifeNum(1);
                    break;
                case "水分":
                    print("shuifen");
                    //GameObject.Find("hero").GetComponent<PlayerController>().AddEnergyNum(1);
                    GameObject.Find("hero").GetComponent<PlayerController>().AddEnergy(energy);
                    break;
                case "肥料":
                    print("yangfen");
                    GameObject.Find("hero").GetComponent<PlayerController>().AddRespawnNum(1);
                    break;
                default:
                    break;

            }
            Destroy(gameObject);
        }
    }
}
