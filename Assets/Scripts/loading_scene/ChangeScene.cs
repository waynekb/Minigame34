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
                break;
            case "Second":
                PassSceneName.SceneName = "Third";
                break;
            case "Third":
                PassSceneName.SceneName = "Fouth";
                break;
            case "Fouth":
                PassSceneName.SceneName = "Fifth";
                break;
            case "Fifth":
                PassSceneName.SceneName = "Ending";
                break;
            default:
                break;
        }
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
