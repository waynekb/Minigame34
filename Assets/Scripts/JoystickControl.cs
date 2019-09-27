using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    public delegate void VoidDelegate(Vector3 direction);
    public delegate void onDragDelegate();
    public VoidDelegate onRelease;
    public onDragDelegate onDrag;

    private Vector3 origin;
    private Transform mTrans;

    // 边界
    public float maxDistance = 50.0f;
    public float activeRotateDist = 1.0f;

    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public Vector3 finalVector;

    private void Awake()
    {
        EventTriggerListener.Get(gameObject).onDrag = OnDrag;
        EventTriggerListener.Get(gameObject).onEndDrag = OnEndDrag;
        EventTriggerListener.Get(gameObject).onDown = OnDown;
        EventTriggerListener.Get(gameObject).onUp = OnUp;
    }

    private void Start()
    {
        origin = transform.localPosition;
        mTrans = transform;
    }

    private void Update()
    {
        Vector3 dir = transform.localPosition - origin;
        float dis = dir.magnitude;

        if (dis > maxDistance)
        {
            transform.localPosition = origin + dir * maxDistance / dis;
        }

        if (dis > activeRotateDist)
        {
            direction = (new Vector3(dir.x, dir.y, 0.0f)).normalized;
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    private void OnDrag(GameObject obj, Vector2 delta)
    {
        transform.localPosition += new Vector3(delta.x, delta.y, 0.0f);
    }

    private void OnEndDrag(GameObject obj)
    {
        finalVector = transform.localPosition - origin;
        finalVector.z = 0.0f;
        transform.localPosition = origin;

        if(onRelease != null)
        {
            onRelease(finalVector);
        }
    }

    private void OnDown(GameObject obj)
    {
        Debug.Log("onDown");

        if (onDrag != null)
        {
            onDrag();
        }
    }

    private void OnUp(GameObject obj)
    {
        Debug.Log("onUp");
    }
}
