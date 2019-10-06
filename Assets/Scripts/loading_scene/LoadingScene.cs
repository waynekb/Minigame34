using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public Image image;
    private int speed = -1;
    private int wait = 0;
    private AsyncOperation async = null;
    public Sprite[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        //PassSceneName.SceneName = "Second";
        load_image();
        async = SceneManager.LoadSceneAsync(PassSceneName.SceneName);
        async.allowSceneActivation = false;
    }

    void load_image()
    {
        int ret = -1;
        switch (PassSceneName.SceneName)
        {
            case "First":
                ret = 0;
                break;
            case "Second":
                ret = 1;
                break;
            case "Third_1":
            case "TuZi":
            case "Niu_Dan":
                ret = 2;
                break;
            case "Fourth":
            case "Third_2":
                ret = 3;
                break;
            case "JinRu":
            case "Fifth":
                ret = 4;
                break;
            case "Sixth":
                ret = 5;
                break;
            default:
                break;
                
        }
        print(ret);
        image.sprite = sprites[ret];
    }

    void loading() {
        int percent = (int)(async.progress * 100);
        if (speed < percent || (speed >= 89 && speed < 100)){ speed++; }
        slider.value = (float)speed / 100;
        text.text = speed + "%";
        if (speed >= 100)
        {
            wait++;
            if (wait >= 20)
            {
               async.allowSceneActivation = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        loading();
    }
}


