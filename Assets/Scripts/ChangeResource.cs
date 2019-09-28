using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeResource : MonoBehaviour
{
    public Image[] ImageSet = new Image[3];
    public Text[]  TextSet = new Text[3];


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<3; ++i)
        {
            TextSet[i].GetComponent<Text>().text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateResourceInfo()
    {
        UpdateResourceImage();
        UpdateResourceText();
    }

    private void UpdateResourceImage()
    {
        for (int i = 0; i<3; ++i)
        {
            string SpritePath = "Image/" + i;
            Sprite ImageSprite = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
            ImageSet[i].GetComponent<Image>().sprite = ImageSprite;
        }
    }

    private void UpdateResourceText()
    {
        for (int i = 0; i < 10; ++i)
        {
            TextSet[i].GetComponent<Text>().text = "2";
        }
    }
}
