using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResource : MonoBehaviour
{
    public Image ImageSun;
    public Image ImageHuafei;
    public Image ImagePanel;
    public Text TextSun;
    public Text TextHuafei;
    public Text TextPanel;

    private int SunNum = 0;
    private int HuafeiNum = 0;
    private int PlaneNum = 0;

    private Sprite[] ResourcesSpriteSet = new Sprite[8];

    void Start()
    {
        string[] ImagePath = new string[8];
        ImagePath[0] = "sun0";
        ImagePath[1] = "sun1";
        ImagePath[2] = "sun2";
        ImagePath[3] = "huafei0";
        ImagePath[4] = "huafei1";
        ImagePath[5] = "huafei2";
        ImagePath[6] = "panel";
        ImagePath[7] = "chengfuhao";

        for (int i = 0; i < 8; ++i)
        {
            string SpritePath = "Image/gongneng/" + ImagePath[i];
            ResourcesSpriteSet[i] = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
        }

        TextHuafei.GetComponent<Text>().text = "0";
        TextSun.GetComponent<Text>().text = "0";
        TextPanel.GetComponent<Text>().text = "0";

        ImageSun.GetComponent<Image>().sprite = ResourcesSpriteSet[0];
        ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[3];
        ImagePanel.GetComponent<Image>().sprite = ResourcesSpriteSet[6];
    }

    // Update is called once per frame
    void Update()
    {
        UpdateResourceInfo();
    }

    public void UpdateResourceInfo()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            return;
        }
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc == null)
        {
            return;
        }
        Pickups pickups = pc.GetPickups();

        SunNum = pickups.lifeNum;
        HuafeiNum = pickups.respawnNum;
        PlaneNum = pickups.platformNum;


        UpdateResourceImage();
        UpdateResourceText();
    }

    private void UpdateResourceImage()
    {
        int RemainSunNumn = SunNum % 3;
        int RemainHuafeiNum = HuafeiNum % 3;

        if(RemainSunNumn == 0)
        {
            ImageSun.GetComponent<Image>().sprite = ResourcesSpriteSet[0];
        }
        else if(RemainSunNumn == 1)
        {
            ImageSun.GetComponent<Image>().sprite = ResourcesSpriteSet[1];
        }
        else
        {
            ImageSun.GetComponent<Image>().sprite = ResourcesSpriteSet[2];
        }

        if (RemainHuafeiNum == 0)
        {
            ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[3];
        }
        else if (RemainHuafeiNum == 1)
        {
            ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[4];
        }
        else
        {
            ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[5];
        }

        ImagePanel.GetComponent<Image>().sprite = ResourcesSpriteSet[6];
    }

    private void UpdateResourceText()
    {
        int DivideSunNum = SunNum / 3;
        int DivideHuafeiNum = HuafeiNum / 3;
        TextSun.GetComponent<Text>().text = "" + DivideSunNum;
        TextHuafei.GetComponent<Text>().text = "" + DivideHuafeiNum;
        TextPanel.GetComponent<Text>().text = "" + PlaneNum;
    }

        
}
