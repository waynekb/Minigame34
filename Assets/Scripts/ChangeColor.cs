using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer render = null;
    public Color curColor;
    public float changeTime = 1.0f;
    private float sumTime = 0.0f;
    private Color color1;
    private Color color2;

    private void Start()
    {
        render = gameObject.GetComponent<SpriteRenderer>();
        if (render)
        {
            color1 = render.color;
            color2 = color1;
            color1.b = 1.0f;
            color2.b = 0.0f;
        }
    }
    private void Update()
    {
        if (render)
        {
            sumTime += Time.deltaTime;
            curColor = Color.Lerp(color1, color2, sumTime / changeTime);
            if (sumTime >= changeTime)
            {
                sumTime = 0.0f;
                Color color = color1;
                color1 = color2;
                color2 = color;
            }
            render.color = curColor;
        }
    }
}
