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
    public int gameMode = 0;

    Dictionary<string, float> p = new Dictionary<string, float>();

    List<GameObject> childrenParams = new List<GameObject>(); 
    List<string> StaticParams = new List<string> {"x0_","Home","recordEMG"};
    List<string> TrajParams = new List<string> {"vmax","Home","recordEMG"};
    List<string> StaticRandomParams = new List<string> {"Home","recordEMG","Rate"};

    List<string> SineWaveParams = new List<string> {"Home","recordEMG","Amplitude", "Offset", "Frequency"};

    private void Awake()
    {
        for(int i = 0; i < StepView.transform.childCount; i++)
        {   
            childrenParams.Add(StepView.transform.GetChild(i).gameObject);
        }
        
    }

    private void Start()
    {
        changeView(0);
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
            case 2:
		        //Debug.Log(CUICView.transform.GetChild(1));
                SetParamsFromMode(SineWaveParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;
            case 3:
                //Debug.Log(CUICView.transform.GetChild(1));
                SetParamsFromMode(StaticRandomParams);
                LayoutRebuilder.ForceRebuildLayoutImmediate(canvas);
                break;

        }
        StartCoroutine(rebuild());
    }

    public Dictionary<string, float> GetParams()
    {
        p.Clear();

  
        foreach (Slider s in StepView.GetComponentsInChildren<Slider>())
        {
            p.Add(s.transform.parent.name, s.value);
        }

        foreach (Toggle t in StepView.GetComponentsInChildren<Toggle>())
        {
            p.Add(t.transform.name, t.isOn ? 1 : 0);
            Debug.Log("toggle added gameMode" + t.transform.parent.name);
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

    public void changeGameMode(int mode)
    {
        gameMode = mode;
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
