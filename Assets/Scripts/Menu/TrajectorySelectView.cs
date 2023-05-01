using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrajectorySelectView : MonoBehaviour
{

    [SerializeField] private GameObject StepView;
    [SerializeField] private GameObject VelView;
    [SerializeField] private RectTransform canvas;

    public int viewIndex = 0;
    Dictionary<string, float> p = new Dictionary<string, float>();

    List<GameObject> childrenParams = new List<GameObject>(); 
    List<string> StaticParams = new List<string> {"x0","Home"};
    List<string> TrajParams = new List<string> {"vmax","Home"};

    private void Awake()
    {
        for(int i = 0; i < StepView.transform.childCount; i++)
        {   
            childrenParams.Add(StepView.transform.GetChild(i).gameObject);
        }
    }


    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
        viewIndex = newViewIndex;
        switch (newViewIndex)
        {
            case 0:
		        //Debug.Log(CUICView.transform.GetChild(1));
                SetParamsFromMode(StaticParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 1:
		        //Debug.Log(CUICView.transform.GetChild(1));
                SetParamsFromMode(TrajParams);
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

            foreach (Toggle t in StepView.GetComponentsInChildren<Toggle>())
            {
                p.Add(t.transform.name, t.isOn ? 1 : 0);
                Debug.Log("toggle added " + t.transform.parent.name);
            }

   

        }
        else
        {
            foreach (Slider s in VelView.GetComponentsInChildren<Slider>())
            {
                p.Add(s.transform.parent.name, s.value);
            }

            foreach (Toggle t in StepView.GetComponentsInChildren<Toggle>())
            {
                p.Add(t.transform.parent.name, t.isOn ? 1 : 0);
            }

        }

        return p;
    }

    private void SetParamsFromMode(List<string> ParamList)
    {
        foreach(GameObject go in childrenParams)
        {
            if(!ParamList.Contains(go.name))
            {
                go.SetActive(false);
            }
            else
            {
                go.SetActive(true);
            }
        }
    }

}
