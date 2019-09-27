using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class EventTriggerListener: UnityEngine.EventSystems.EventTrigger
{
    public delegate void VoidDelegate(GameObject obj);
    public delegate void VectorDelegate(GameObject obj, Vector2 delta);

    public VoidDelegate onDown;
    public VoidDelegate onUp;
    public VoidDelegate onEndDrag;
    public VectorDelegate onDrag;

    static public EventTriggerListener Get(GameObject obj)
    {
        if(obj == null)
        {
            Debug.LogError("EventTriggerListener is null");
            return null;
        }
        else
        {
            EventTriggerListener listener = obj.GetComponent<EventTriggerListener>();
            if(listener == null)
            {
                listener = obj.AddComponent<EventTriggerListener>();
            }
            return listener;
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        if(onDrag != null)
        {
            onDrag(gameObject, eventData.delta);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if(onEndDrag != null)
        {
            onEndDrag(gameObject);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if(onUp != null)
        {
            onUp(gameObject);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if(onDown != null)
        {
            onDown(gameObject);
        }
    }
}