using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "hero")
        {
            next_level();
        }
    }


    private void next_level()
    {
        string scenename = SceneManager.GetActiveScene().name;
        switch (scenename)
        {
            case "First":
                PassSceneName.SceneName = "Second";
                Level.level0 = 1;
                break;
            case "Second":
                PassSceneName.SceneName = "Third_1";
                Level.level1 = 1;
                break;
            case "Third_1":
                PassSceneName.SceneName = "TuZi";
                break;
            case "TuZi":
                PassSceneName.SceneName = "Niu_Dan";
                break;
            case "Niu_Dan":
                PassSceneName.SceneName = "Fourth";
                Level.level2 = 1;

                break;
            case "Fourth":
                PassSceneName.SceneName = "Third_2";
                break;
            case "Third_2":
                PassSceneName.SceneName = "JinRu";
                Level.level3 = 1;

                break;
            case "JinRu":
                PassSceneName.SceneName = "Fifth";
                break;
            case "Fifth":
                PassSceneName.SceneName = "Sixth";
                Level.level4 = 1;

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
