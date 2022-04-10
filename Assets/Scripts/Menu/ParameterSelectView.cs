using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterSelectView : MonoBehaviour
{

    [SerializeField] private GameObject AdmView;
    [SerializeField] private GameObject CUICView;
    [SerializeField] private RectTransform canvas;

    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
        switch(newViewIndex)
        {
            case 0:
                CUICView.SetActive(false);
                AdmView.SetActive(true);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 1:
                AdmView.SetActive(false);
                CUICView.SetActive(true);;
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
                
        }
    }
}
