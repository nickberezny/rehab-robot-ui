using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterSelectView : MonoBehaviour
{

    [SerializeField] private GameObject CUICView;
    [SerializeField] private RectTransform canvas;

    public int viewIndex = 1;
    Dictionary<string, float> p = new Dictionary<string, float>();
    List<GameObject> childrenParams = new List<GameObject>(); 
    List<string> PDParams = new List<string> {"kp","kv"};
    List<string> ImpParams = new List<string> {"mass","damp","Md","Bd","Kd","useFriction"};
    List<string> AdmParams = new List<string> {"kp","kv","Md","Bd","Kd", "useFriction" };
    List<string> UICParams = new List<string> {"kp","kv","Md","Bd","Kd","delta","alpha", "useFriction" };
    List<string> StochParams = new List<string> {"kp","kv","Fmax","PhaseTime","NumPositions","StochasticStepTime"};
    List<string> UIACParams = new List<string> { "kp", "kv", "Md", "Bd", "Kd", "delta", "alpha", "useFriction" };

    List<string> StochTrajParams = new List<string> {"kp","kv","Md","Bd","Fmax","PhaseTime","StochasticStepTime"};

    private void Awake()
    {
        for(int i = 0; i < CUICView.transform.childCount; i++)
        {   
            childrenParams.Add(CUICView.transform.GetChild(i).gameObject);
        }
       
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            changeView(i);
        }
        changeView(0);
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
                SetParamsFromMode(UIACParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 5:
                SetParamsFromMode(StochParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 6:
                SetParamsFromMode(StochTrajParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            

        }
        StartCoroutine(rebuild());
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

    IEnumerator rebuild()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Rebuild!");
        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
        LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
        yield return new WaitForSeconds(1f);



    }


}
