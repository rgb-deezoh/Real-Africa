using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [System.Serializable]
    public struct CountryData
    {
        public string Name;
        public Sprite Flag;
        public bool Guessed; //When a country is guessed
        public bool BeenQuestioned;//When the Flag is Questioned
    }

    public CountryData[] AfricanCountryDataSet;

    
    public CountryData[] CountrySetPerGame;
   
    public CountryData[] CountryDataSet;

    public static GameData Instance;

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

    public void AssignArrayOfCountry()
    {
        CountryDataSet = new CountryData[AfricanCountryDataSet.Length];
        AfricanCountryDataSet.CopyTo(CountryDataSet, 0);
    }
}
