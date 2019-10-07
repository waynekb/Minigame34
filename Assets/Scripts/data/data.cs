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
    public static int xiaofu;
    public static int chizi;
    public static int yueqi;
    public static int yinyueren;
    public static int xiangyantou;
    public static int beike;
    public static int haiyanglaji;
    public static int yunduo;
    public static int huaxiangji;
    public static int object10;

    public static void Save_data()
    {
        PlayerPrefs.SetInt("xiaofu", xiaofu);
        PlayerPrefs.SetInt("chizi", chizi);
        PlayerPrefs.SetInt("yueqi", yueqi);
        PlayerPrefs.SetInt("yinyueren", yinyueren);
        PlayerPrefs.SetInt("xiangyantou", xiangyantou);
        PlayerPrefs.SetInt("beike", beike);
        PlayerPrefs.SetInt("haiyanglaji", haiyanglaji);
        PlayerPrefs.SetInt("yunduo", yunduo);
        PlayerPrefs.SetInt("huaxiangji", huaxiangji);
        PlayerPrefs.SetInt("object10", object10);
    }
    public static void Init_package()
    {
        xiaofu = 0;
        chizi = 0;
        yueqi = 0;
        yinyueren = 0;
        xiangyantou = 0;
        beike = 0;
        haiyanglaji = 0;
        yunduo = 0;
        huaxiangji = 0;
        object10 = 0;
    }

    public static void Load_package()
    {
        xiaofu = PlayerPrefs.GetInt("xiaofu");
        chizi = PlayerPrefs.GetInt("chizi");
        yueqi = PlayerPrefs.GetInt("yueqi");
        yinyueren = PlayerPrefs.GetInt("yinyueren");
        xiangyantou = PlayerPrefs.GetInt("xiangyantou");
        beike = PlayerPrefs.GetInt("beike");
        haiyanglaji = PlayerPrefs.GetInt("haiyanglaji");
        yunduo = PlayerPrefs.GetInt("yunduo");
        huaxiangji = PlayerPrefs.GetInt("huaxiangji");
        object10 = PlayerPrefs.GetInt("object10");
    }
}

public class Level
{
    public static int level0;
    public static int level1;
    public static int level2;
    public static int level3;
    public static int level4;
    public static void Init_level()
    {
        level0 = 0;
        level1 = 0;
        level2 = 0;
        level3 = 0;
        level4 = 0;
    }

    public static void Save_level()
    {
        PlayerPrefs.SetInt("level0", level0);
        PlayerPrefs.SetInt("level1", level1);
        PlayerPrefs.SetInt("level2", level2);
        PlayerPrefs.SetInt("level3", level3);
        PlayerPrefs.SetInt("level4", level4);
    }
    public static void Load_level()
    {
        level0 = PlayerPrefs.GetInt("level0");
        level1 = PlayerPrefs.GetInt("level1");
        level2 = PlayerPrefs.GetInt("level2");
        level3 = PlayerPrefs.GetInt("level3");
        level4 = PlayerPrefs.GetInt("level4");
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



