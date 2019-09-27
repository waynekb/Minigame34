using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddFirst : MonoBehaviour
{
    public Button AddElementButton;
    public GameObject ParentObject;
    public GameObject InstanceObject;

    // Start is called before the first frame update
    void Start()
    {
        AddElementButton = this.GetComponent<Button>();
        AddElementButton.onClick.AddListener(addElement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void addElement()
    {
        ParentObject = GameObject.Find("BagCanvas/Scroll View/Viewport/Content");
        GameObject Object = (GameObject)Instantiate(Resources.Load("SecondImage"), transform.position, transform.rotation);
        Object.transform.parent = ParentObject.transform;
    }
}
