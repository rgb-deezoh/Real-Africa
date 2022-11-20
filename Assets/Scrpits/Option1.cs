using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option1 : MonoBehaviour
{
    public int firstIndex;
    public Image nationFlag;
   
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AssignNationArray();
        FirstSlot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstSlot()
    {
        firstIndex = Random.Range(0, GameManager.Instance.nationDataSet.Length);
        /*
        showNationFlag.sprite = GameManager.Instance.nationDataSet[firstIndex].flag;
        GameManager.Instance.nationDataSet[firstIndex].asked = true;
        */
        nationFlag.sprite = GameManager.Instance.nationDataSet[firstIndex].flag;
        Debug.Log(firstIndex);
    }
}
