using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public GameObject[] flagObjects;
    private int numberOfFlagObjects = 0;

    //Flag Data variables..
    private CurrentGameData m_GameData;
    private bool isFirstRun = false;

    // Start is called before the first frame update
    void Start()
    {
        numberOfFlagObjects = flagObjects.Length;
        m_GameData = GameObject.Find("GameDataObject").GetComponent<CurrentGameData>() as CurrentGameData;
        isFirstRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirstRun)FirstRun();
    }

    void FirstRun()
    {
        AssignFlags();
        isFirstRun = false;
    }
    public void AssignFlags()
    {
        int finalFlagPosition = (int)Random.Range(0, numberOfFlagObjects);
        switch (finalFlagPosition)
        {
            case 0:
                flagObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                flagObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                flagObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                break;
            case 1:
                flagObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                flagObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                flagObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                break;
            case 2:
                flagObjects[0].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFirstFlagIndex());
                flagObjects[1].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetSecondFlagIndex());
                flagObjects[2].GetComponent<SpriteRenderer>().sprite = m_GameData.GetFlagSpriteIndex(m_GameData.GetFinalFlagIndex());
                break;
        }
    }
}
