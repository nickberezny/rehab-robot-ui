using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSlider : MonoBehaviour
{
    private Slider slider;
    private InputField inputField;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        inputField = GetComponentInChildren<InputField>();

        slider.onValueChanged.AddListener(delegate { onValueChange(slider.value); });
        inputField.onEndEdit.AddListener(delegate { onValueChange(float.Parse(inputField.text)); });
        
    }

    private void onValueChange(float val)
    {
        slider.value = val;
        inputField.text = val.ToString();
    }

}
