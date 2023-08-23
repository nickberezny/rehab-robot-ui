using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
        {
            b.onClick.AddListener(delegate { ButtonMessage(b.name); });
        }
    }

    void ButtonMessage(string name)
    {
        Manager.Instance.gameMode = (Manager.games)System.Enum.Parse(typeof(Manager.games), name);
    }

}
