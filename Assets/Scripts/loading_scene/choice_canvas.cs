using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choice_canvas : MonoBehaviour
{
    public Button first_sce;
    public Button second_sce;
    public Button third_sce;
    public Button fourth_sce;
    public Button fifth_sce;
    public Button sixth_sce;
    // Start is called before the first frame update
    void Start()
    {
        first_sce.onClick.AddListener(firstsce);
        second_sce.onClick.AddListener(secondsce);
        third_sce.onClick.AddListener(thirdsce);
        fourth_sce.onClick.AddListener(fourthsce);
        fifth_sce.onClick.AddListener(fifthsce);
        sixth_sce.onClick.AddListener(sixthfirstsce);

    }

    void firstsce()
    {
        PassSceneName.SceneName = "First";
        SceneManager.LoadScene("loading_sce");
    }

    void secondsce()
    {
        PassSceneName.SceneName = "Second";
        SceneManager.LoadScene("loading_sce");
    }

    void thirdsce()
    {
        PassSceneName.SceneName = "Third_1";
        SceneManager.LoadScene("loading_sce");
    }

    void fourthsce()
    {
        PassSceneName.SceneName = "Fourth";
        SceneManager.LoadScene("loading_sce");
    }

    void fifthsce()
    {
        PassSceneName.SceneName = "Fifth";
        SceneManager.LoadScene("loading_sce");
    }

    void sixthfirstsce()
    {
        PassSceneName.SceneName = "Sixth";
        SceneManager.LoadScene("loading_sce");
    }
}
