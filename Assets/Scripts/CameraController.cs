using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player = null;
    public bool isUp = false;
    [Tooltip("外层边界")]
    public Boundary outerBoundary;
    [Tooltip("玩家触发相机跟随边界")]
    public Boundary activeDist;
    public float lerpSpeed = 1.0f;

    public float xChangePoint = 10.0f;
    public float xChangePoint2 = 12.0f;
    public float xSize = 1.0f;
    public float ySize = 1.0f;
    private Camera xCamera = null;
    public float deltaX = 0.1f;

    private void Start()
    {
        xCamera = gameObject.GetComponent<Camera>();
        xCamera.orthographicSize = xSize;
    }
    private void LateUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector3 position = transform.position;
        Vector3 delta = player.transform.position - transform.position;

        if(position.x > xChangePoint && position.x <= xChangePoint2)
        {
            isUp = true;
            float size = Mathf.Lerp(xCamera.orthographicSize, ySize, Time.deltaTime * lerpSpeed);
            position.x = Mathf.Lerp(transform.position.x, xChangePoint2+deltaX, Time.deltaTime * lerpSpeed);
            xCamera.orthographicSize = size;
            transform.position = position;
            return;
        }

        if (!isUp && (delta.x > activeDist.max.x || delta.x < activeDist.min.x))
        {
            position.x = Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime * lerpSpeed);
            position.x = Mathf.Clamp(position.x, outerBoundary.min.x, outerBoundary.max.x);
        }

        if (isUp && (delta.y > activeDist.max.y || delta.y < activeDist.min.y))
        {
            position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * lerpSpeed);
            position.y = Mathf.Clamp(position.y, outerBoundary.min.y, outerBoundary.max.y);
        }

        transform.position = position;
    }
}