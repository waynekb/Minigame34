using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class danmu : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer render;
    private BoxCollider2D boxclolider;
    public Sprite[] sp2;
    public Sprite[] sp3;
    public Sprite[] sp4;
    public Sprite[] sp5;
    public Sprite[] sp6;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        boxclolider = GetComponent<BoxCollider2D>();
        change_sprite();
        gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0);
        print(boxclolider.size.x);
        print(boxclolider.size.y);
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
            case "Fifth":
            case "JinRu":
                num = Random.Range(0, sp5.Length-1);
                render.sprite = sp5[num];
                break;
            case "Sixth":
                num = Random.Range(0, sp6.Length - 1);
                render.sprite = sp6[num];
                break;
            default:
                break;
        }
    }

}
