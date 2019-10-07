using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateAlpha : MonoBehaviour
{
    public float minOpacity = 0.0f;
    public float maxOpacity = 0.5f;
    public float changeSpeed = 0.1f;
    private SpriteRenderer render = null;
    private float curOpacity = 0.0f;

    private void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (render)
        {
            curOpacity += changeSpeed * Time.deltaTime;
            if(curOpacity > maxOpacity || curOpacity < minOpacity)
            {
                changeSpeed *= -1;
            }
            curOpacity = Mathf.Clamp(curOpacity, minOpacity, maxOpacity);
            Color color = render.color;
            color.a = curOpacity;
            render.color = color;
        }
    }
}
