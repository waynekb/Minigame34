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
                PassSceneName.SceneName = "Third";
                if (Level.level < 2)
                {
                    Level.level = 2;
                }
                break;
            case "Third":
                PassSceneName.SceneName = "Fouth";
                if (Level.level < 3)
                {
                    Level.level = 3;
                }
                break;
            case "Fouth":
                PassSceneName.SceneName = "Fifth";
                if (Level.level < 4)
                {
                    Level.level = 4;
                }
                break;
            case "Fifth":
                PassSceneName.SceneName = "Start";
                if (Level.level < 5)
                {
                    Level.level = 5;
                }
                break;
            default:
                break;
        }
        Level.Save_level();
        SceneManager.LoadScene("loading_sce");
    }

}
