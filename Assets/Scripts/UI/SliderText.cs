using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    private Text text;
    private Slider slider;

    private void Awake()
    {
        text = GetComponent<Text>();
        slider = GetComponentInParent<Slider>();
    }

    private void Update()
    {
        text.text = $"Мгдижа...\n{(int)(slider.value * 100)}%";
    }
}
