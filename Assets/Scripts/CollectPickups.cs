using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPickups : MonoBehaviour
{
    private PlayerController pc = null;

    private void Start()
    {
        pc = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (pc == null)
        {
            return;
        }

        Destroy(collider.gameObject);

        switch (collider.tag)
        {
            case "LifeNum":
                pc.AddLifeNum(1);
                break;
            case "PlatformNum":
                pc.AddPlatformNum(1);
                break;
            case "EnergyNum":
                pc.AddEnergyNum(1);
                break;
            case "RespawnNum":
                pc.AddRespawnNum(1);
                break;
            default:
                break;
        }
    }
}
