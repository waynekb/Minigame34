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

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        change_sprite();
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
            case "Third_2":
                num = Random.Range(0, sp3.Length-1);
                render.sprite = sp3[num];
                break;
            case "Fourth":
                num = Random.Range(0, sp4.Length-1);
                render.sprite = sp4[num];
                break;
            case "Fifth":
                num = Random.Range(0, sp5.Length-1);
                render.sprite = sp5[num];
                break;
            default:
                break;
        }
    }

}
