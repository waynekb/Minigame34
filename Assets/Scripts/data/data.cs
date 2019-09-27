using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PassSceneName
{
    public static string SceneName;
}

public class Package
{
    public Package() { }
    public static int object1;
    public static int object2;
    public static int object3;
    public static int object4;
    public static int object5;
    public static int object6;
    public static int object7;
    public static int object8;
    public static int object9;
    public static int object10;

    public static void Save_data()
    {
        PlayerPrefs.SetInt("object1", object1);
        PlayerPrefs.SetInt("object2", object2);
        PlayerPrefs.SetInt("object3", object3);
        PlayerPrefs.SetInt("object4", object4);
        PlayerPrefs.SetInt("object5", object5);
        PlayerPrefs.SetInt("object6", object6);
        PlayerPrefs.SetInt("object7", object7);
        PlayerPrefs.SetInt("object8", object8);
        PlayerPrefs.SetInt("object9", object8);
        PlayerPrefs.SetInt("object10", object10);
    }
    public static void Init_package()
    {
        object1 = 0;
        object2 = 0;
        object3 = 0;
        object4 = 0;
        object5 = 0;
        object6 = 0;
        object7 = 0;
        object8 = 0;
        object9 = 0;
        object10 = 0;
    }

    public static void Load_package()
    {
        object1 = PlayerPrefs.GetInt("object1");
        object2 = PlayerPrefs.GetInt("object2");
        object3 = PlayerPrefs.GetInt("object3");
        object4 = PlayerPrefs.GetInt("object4");
        object5 = PlayerPrefs.GetInt("object5");
        object6 = PlayerPrefs.GetInt("object6");
        object7 = PlayerPrefs.GetInt("object7");
        object8 = PlayerPrefs.GetInt("object8");
        object9 = PlayerPrefs.GetInt("object9");
        object10 = PlayerPrefs.GetInt("object10");
    }
}

public class SavesceneName
{

    public static void Save_sce(string scene_name)
    {
        PlayerPrefs.SetString("scene_name", scene_name);
    }

    public static void Load_sce()
    {
        PassSceneName.SceneName = PlayerPrefs.GetString("scene_name");
        SceneManager.LoadScene("loading_sce");
    }
}



