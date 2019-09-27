using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEnerge : MonoBehaviour
{
    private Slider EnergeSlider;
    private PlayerController PlayControlInstance;
    // Start is called before the first frame update
    void Start()
    {
        EnergeSlider = GetComponent<Slider>();
        EnergeSlider.minValue = 0;
        PlayControlInstance = GameObject.Find("hero").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        EnergeSlider.value = PlayControlInstance.GetEnerge();
    }
}
