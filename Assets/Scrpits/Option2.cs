using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option2 : MonoBehaviour
{
    public int secondIndex;
    public Image nationFlag;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AssignNationArray();
        SecondSlot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SecondSlot()
    {
        secondIndex = Random.Range(0, GameManager.Instance.nationDataSet.Length);
        nationFlag.sprite = GameManager.Instance.nationDataSet[secondIndex].flag;
        Debug.Log(secondIndex);
    }
}
