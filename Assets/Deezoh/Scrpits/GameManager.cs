using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    [System.Serializable]
    public class Country
    {
        public string name;
        public Sprite flag; 
        public bool answered; 
        public bool asked; 

    }

    public Country[] nation;


    // private Option3 optionThree;
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

    public void Start()
    {
        //CreatCountry();
    }


    
    public void NationArray()
    {
        nation = new Country[nation.Length];
    }
    

   
    public void CreatCountry()
    {
        Country uganda = new Country(); // creates uganda as country
        Country kenya = new Country(); // creates kenya as country

        uganda.name = "Uganda";
        Debug.Log(uganda.name);
    }

}
