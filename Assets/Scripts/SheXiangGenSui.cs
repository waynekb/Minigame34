using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundary
{
    public Vector2 min;
    public Vector2 max;
}

public class SheXiangGenSui : MonoBehaviour
{
    public Transform player;
    [Tooltip("外层边界")]
    public Boundary outerBoundary;
    [Tooltip("内层相对边界")]
    public Vector2 deltaInnerBoundary;
    [Tooltip("玩家触发相机跟随边界")]
    public Boundary activeDist;
    public float lerpSpeed = 1.0f;

    private void LateUpdate()
    {
        if(player == null)
        {
            return;
        }

        Vector3 position = transform.position;
        Vector3 delta = player.transform.position - transform.position;

        if(delta.x > activeDist.max.x || delta.x < activeDist.min.x)
        {
            position.x = Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime*lerpSpeed);
            if(position.y <= outerBoundary.max.y - deltaInnerBoundary.y)
            {
                position.x = Mathf.Clamp(position.x, outerBoundary.min.x, outerBoundary.max.x);
            }
            else
            {
                position.x = Mathf.Clamp(position.x, outerBoundary.min.x + deltaInnerBoundary.x, outerBoundary.max.x);
            }
        }

        if(delta.y > activeDist.max.y || delta.y < activeDist.min.y)
        {
            position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * lerpSpeed);
            if(position.x >= outerBoundary.min.x + deltaInnerBoundary.x)
            {
                position.y = Mathf.Clamp(position.y, outerBoundary.min.y, outerBoundary.max.y);
            }
            else
            {
                position.y = Mathf.Clamp(position.y, outerBoundary.min.y, outerBoundary.max.y - deltaInnerBoundary.y);
            }
        }

        transform.position = position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            print(Package.beike);
            print(Package.chizi);
            print(Package.haiyanglaji);
            print(Package.xiangyantou);
            print(Package.yueqi);
            print(Package.yunduo);
        }
    }
}
