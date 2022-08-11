using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterSelectView : MonoBehaviour
{

    [SerializeField] private GameObject AdmView;
    [SerializeField] private GameObject CUICView;
    [SerializeField] private RectTransform canvas;

    int viewIndex = 0;
    Dictionary<string, float> p = new Dictionary<string, float>();

    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
        viewIndex = newViewIndex;
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

    public Dictionary<string, float> GetParams()
    {
        p.Clear();

        if(viewIndex == 0)
        {
            foreach(Slider s in AdmView.GetComponentsInChildren<Slider>())
            {
                p.Add(s.transform.parent.name, s.value);
            }

        }
        else
        {
            foreach (Slider s in CUICView.GetComponentsInChildren<Slider>())
            {
                p.Add(s.transform.parent.name, s.value);
            }

        }

        return p;
    }


}
