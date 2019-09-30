using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        next_level();
    }


    private void next_level()
    {
        string scenename = SceneManager.GetActiveScene().name;
        switch (scenename)
        {
            case "First":
                PassSceneName.SceneName = "Second";
                if (Level.level < 1)
                {
                    Level.level = 1;
                }
                break;
            case "Second":
                PassSceneName.SceneName = "Third_1";
                if (Level.level < 2)
                {
                    Level.level = 2;
                }
                break;
            case "Third_1":
                PassSceneName.SceneName = "TuZi";
                break;
            case "TuZi":
                PassSceneName.SceneName = "Niu_Dan";
                break;
            case "Niu_Dan":
                PassSceneName.SceneName = "Fourth";
                if (Level.level < 3)
                {
                    Level.level = 3;
                }
                break;
            case "Fourth":
                PassSceneName.SceneName = "Third_2";
                break;
            case "Third_2":
                PassSceneName.SceneName = "JinRu";
                if (Level.level < 4)
                {
                    Level.level = 4;
                }
                break;
            case "JinRu":
                PassSceneName.SceneName = "Fifth";
                break;
            case "Fifth":
                PassSceneName.SceneName = "Sixth";
                if (Level.level < 5)
                {
                    Level.level = 5;
                }
                break;
            case "Sixth":
                PassSceneName.SceneName = "Start";
                break;
            default:
                break;
        }
        Level.Save_level();
        SceneManager.LoadScene("loading_sce");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            next_level();
        }
    }

}
