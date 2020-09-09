using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPaddle : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = slider.value;
        Vector3 temp = transform.position;
        temp.x = sliderValue;
        transform.localPosition = temp;
    }
}
