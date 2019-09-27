using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheXiangGenSui : MonoBehaviour
{
    public Transform Player;
    public float activeDeltaDist = 1.0f;
    public float lerpSpeed = 1.0f;

    public bool bIsFollow = true;
    private Vector3 Pos;
 
    void LateUpdate()
    {
        if(Player != null)
        {
            float deltaX = (Player.transform.position.x - transform.position.x);

            if(Mathf.Abs(deltaX) > activeDeltaDist)
            {
                transform.position = new Vector3(Mathf.Lerp(transform.position.x, Player.transform.position.x, Time.deltaTime * lerpSpeed), transform.position.y, transform.position.z);
            }
        }

        /*Pos.x= Player.transform.position.x - gameObject.transform.position.x;
        Pos.z = 0;
        gameObject.transform.position += Pos / 20;*/
    }
}
