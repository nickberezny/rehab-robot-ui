using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrajectorySelectView : MonoBehaviour
{

    [SerializeField] private GameObject StepView;
    [SerializeField] private GameObject VelView;
    [SerializeField] private RectTransform canvas;

    int viewIndex = 0;
    Dictionary<string, float> p = new Dictionary<string, float>();

    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
        viewIndex = newViewIndex;
        switch (newViewIndex)
        {
            case 0:
                VelView.SetActive(false);
                StepView.SetActive(true);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 1:
                StepView.SetActive(false);
                VelView.SetActive(true); ;
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;

        }
    }

    public Dictionary<string, float> GetParams()
    {
        p.Clear();

        if (viewIndex == 0)
        {
            foreach (Slider s in StepView.GetComponentsInChildren<Slider>())
            {
                p.Add(s.transform.parent.name, s.value);
            }

        }
        else
        {
            foreach (Slider s in VelView.GetComponentsInChildren<Slider>())
            {
                p.Add(s.transform.parent.name, s.value);
            }

        }

        return p;
    }
}
