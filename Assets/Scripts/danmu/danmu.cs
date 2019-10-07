using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class danmu : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer render;
    public Sprite[] sp2;
    public Sprite[] sp3;
    public Sprite[] sp4;
    public Sprite[] sp5;
    private float len;
    private float heigh;
    private BoxCollider2D boxCollider;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        change_sprite();
        gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0f);
        len = render.sprite.bounds.size.x;
        heigh = render.sprite.bounds.size.y;
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(len, heigh);
    }

    void change_sprite()
    {
        string scenename = SceneManager.GetActiveScene().name;
        int num = 0;
       
        switch (scenename)
        {
            case "First":
            case "Second":
                num = Random.Range(0, sp2.Length-1);
                render.sprite = sp2[num];
                break;
            case "Third_1":
            case "TuZi":
            case "Niu_Dan":
                num = Random.Range(0, sp3.Length-1);
                render.sprite = sp3[num];
                break;
            case "Fourth":
            case "Third_2":
                num = Random.Range(0, sp4.Length-1);
                render.sprite = sp4[num];
                break;
            case "JinRu":
            case "Fifth":
                num = Random.Range(0, sp5.Length-1);
                render.sprite = sp5[num];
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "hero")
        {
            GameObject.Find("hero").GetComponent<PlayerController>().AddLife(-1);
        }
    }

}
