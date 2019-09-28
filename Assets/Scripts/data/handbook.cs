using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handbook : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "hero")
        {
            switch (gameObject.tag)
            {
                case "校服":
                    Package.xiaofu = 1;
                    break;
                case "尺子":
                    Package.chizi = 1;
                    break;
                case "乐器":
                    Package.yueqi = 1;
                    break;
                case "音乐人":
                    Package.yinyueren = 1;
                    break;
                case "香烟头":
                    Package.xiangyantou = 1;
                    break;
                case "贝壳":
                    Package.beike = 1;
                    break;
                case "海洋垃圾":
                    Package.haiyanglaji = 1;
                    break;
                case "云朵":
                    Package.yunduo = 1;
                    break;
                case "滑翔机":
                    Package.huaxiangji = 1;
                    break;
                case "object10":
                    Package.object10 = 1;
                    break;
                default:
                    break;
            }
            Package.Save_data();
        }
    }
}
