using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResource : MonoBehaviour
{
    public Image ImageHuafei;
    public Image ImageSun;
    public Image ImagePanel;
    public Text TextHuafei;
    public Text TextSun;
    public Text TextPanel;

    private int SunNum = 0;
    private int HuafeiNum = 0;
    private int PlaneNum = 0;

    private Sprite[] ResourcesSpriteSet = new Sprite[6];

    void Start()
    {
        string[] ImagePath = new string[8];
        ImagePath[0] = "huafei0";
        ImagePath[1] = "huafei1";
        ImagePath[2] = "huafei2";
        ImagePath[4] = "sun0";
        ImagePath[5] = "sun1";
        ImagePath[6] = "sun2";

        for (int i = 0; i < 6; ++i)
        {
            string SpritePath = "Image/Card/" + "Card1_Color";
            ResourcesSpriteSet[i] = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
        }

        TextHuafei.GetComponent<Text>().text = "1";
        TextSun.GetComponent<Text>().text = "1";
        TextPanel.GetComponent<Text>().text = "1";

        ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[1];
        ImagePanel.GetComponent<Image>().sprite = ResourcesSpriteSet[1];
        ImageSun.GetComponent<Image>().sprite = ResourcesSpriteSet[5];
    }

    // Update is called once per frame
    void Update()
    {

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
        int RemainPanelNum = PlaneNum % 3;

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
        else if (RemainSunNumn == 1)
        {
            ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[4];
        }
        else
        {
            ImageHuafei.GetComponent<Image>().sprite = ResourcesSpriteSet[5];
        }
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
