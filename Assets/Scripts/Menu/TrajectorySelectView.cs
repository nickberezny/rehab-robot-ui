using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrajectorySelectView : MonoBehaviour
{

    [SerializeField] private GameObject StepView;
    [SerializeField] private GameObject VelView;
    [SerializeField] private RectTransform canvas;

    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
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
}
