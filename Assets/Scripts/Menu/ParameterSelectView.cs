using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterSelectView : MonoBehaviour
{

    [SerializeField] private GameObject AdmView;
    [SerializeField] private GameObject CUICView;
    [SerializeField] private RectTransform canvas;

    public int viewIndex = 1;
    Dictionary<string, float> p = new Dictionary<string, float>();
    List<GameObject> childrenParams = new List<GameObject>(); 
    List<string> PDParams = new List<string> {"kp","kv"};
    List<string> ImpParams = new List<string> {"mass","damp","Md","Bd","Kd"};
    List<string> AdmParams = new List<string> {"kp","kv","Md","Bd","Kd"};
    List<string> UICParams = new List<string> {"kp","kv","Md","Bd","Kd","delta","alpha"};
    List<string> StochParams = new List<string> {"Fmax","PhaseTime","NumPositions"};

    private void Awake()
    {
        for(int i = 0; i < CUICView.transform.childCount; i++)
        {   
            childrenParams.Add(CUICView.transform.GetChild(i).gameObject);
        }
    }


    public void changeView(int newViewIndex)
    {
        Debug.Log(newViewIndex);
        viewIndex = newViewIndex;
        switch(newViewIndex)
        {
            case 0:
		        //Debug.Log(CUICView.transform.GetChild(1));
                SetParamsFromMode(PDParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 1:
                SetParamsFromMode(ImpParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 2:
                SetParamsFromMode(AdmParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 3:
                SetParamsFromMode(UICParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 4:
                SetParamsFromMode(StochParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
                
        }
    }

    public Dictionary<string, float> GetParams()
    {
        p.Clear();

        foreach (Slider s in CUICView.GetComponentsInChildren<Slider>())
        {
            p.Add(s.transform.parent.name, s.value);
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
