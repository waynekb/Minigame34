using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingScene : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private int speed = -1;
    private int wait = 0;
    private AsyncOperation async = null;


    // Start is called before the first frame update
    void Start()
    {
        text = FindObjectOfType<Text>();
        slider = FindObjectOfType<Slider>();
        async = SceneManager.LoadSceneAsync(PassSceneName.SceneName);
        async.allowSceneActivation = false;
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


