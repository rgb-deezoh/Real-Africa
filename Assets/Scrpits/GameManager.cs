using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public struct CountryData
    {
        public string name; //Nation name
        public Sprite flag; //Nation flag
        public bool answered; //When a country is guessed
        public bool asked; //When the Flag is Questioned
    }

    public CountryData[] nationData;
    public CountryData[] nationDataSet;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignNationArray()
    {
        nationDataSet = new CountryData[nationData.Length];
        nationDataSet.CopyTo(nationDataSet, 0);
    }
}
