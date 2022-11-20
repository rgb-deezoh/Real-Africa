using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGameData : MonoBehaviour
{
    [HideInInspector]
    public int firstFlagIndex = 0;
    [HideInInspector]
    public int secondFlagIndex;
    [HideInInspector]
    public int finalFlagIndex;

    private int previousFinalFlagIndex;
    private int countriesPerGame = 60;      //How many countries should be in one game
    private bool gameFinished = false;


    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.AssignArrayOfCountry();

        if(countriesPerGame >= GameData.Instance.CountryDataSet.Length)
            countriesPerGame = GameData.Instance.CountryDataSet.Length;

        GameData.Instance.CountrySetPerGame = new GameData.CountryData[countriesPerGame];
        gameFinished = false;

        PickCountriesPerGame();
        GetNewCountries();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickCountriesPerGame()
    {
        int pickedCountryNumber = 0;

        for (int index = 0; index < GameData.Instance.CountryDataSet.Length; index++)
        {
            if (pickedCountryNumber >= countriesPerGame)
                break;
            else
            {
                if (GameData.Instance.CountryDataSet[index].Guessed == false)
                {
                    GameData.Instance.CountrySetPerGame[pickedCountryNumber] = GameData.Instance.CountryDataSet[index];
                    pickedCountryNumber++;
                }
            }
        }

        if (pickedCountryNumber < countriesPerGame - 1)
        {
            //if we dont have enough countries, select random which where guessed...
            for (int index = 0; index < GameData.Instance.CountryDataSet.Length; index++)
            {
                if (pickedCountryNumber >= countriesPerGame)
                    break;
                else
                {
                    if (GameData.Instance.CountryDataSet[index].Guessed == true)
                    {
                        GameData.Instance.CountrySetPerGame[pickedCountryNumber] = GameData.Instance.CountryDataSet[index];
                        pickedCountryNumber++;
                    }
                }
            }
        }
    }
    public void GetNewCountries()
    {
        previousFinalFlagIndex = finalFlagIndex;

        if(GetNumberOfFlagsLeft() > 0)
        {
            do
            {
                finalFlagIndex = (int)Random.Range(0, GameData.Instance.CountrySetPerGame.Length);
            } while (previousFinalFlagIndex  == finalFlagIndex || GameData.Instance.CountrySetPerGame[finalFlagIndex].Guessed == true);

            do
            {
                firstFlagIndex = (int)Random.Range(0, GameData.Instance.CountrySetPerGame.Length);
            } while (firstFlagIndex == finalFlagIndex);

            do
            {
                secondFlagIndex = (int)Random.Range(0, GameData.Instance.CountrySetPerGame.Length);
            } while (secondFlagIndex == firstFlagIndex || secondFlagIndex == finalFlagIndex);

            GameData.Instance.CountrySetPerGame[finalFlagIndex].BeenQuestioned = true;

        }
        else
        {
            //The level has been completed
            gameFinished = true;
        }
    }

    private int GetNumberOfFlagsLeft()
    {
        int left = 0;
        for(int index = 0; index < GameData.Instance.CountrySetPerGame.Length; index++)
        {
            if (GameData.Instance.CountrySetPerGame[index].Guessed == false)
                left++;
        }
        return left;
    }

    public int GetFlagNameLength(int flagIndex)
    {
        return GameData.Instance.CountrySetPerGame[flagIndex].Name.Length;
    }

    public int GetFirstFlagIndex()
    {
        return firstFlagIndex;
    }

    public int GetSecondFlagIndex()
    {
        return secondFlagIndex;
    }

    public int GetFinalFlagIndex()
    {
        return finalFlagIndex;
    }

    public void SetGuessed()
    {
        GameData.Instance.CountrySetPerGame[finalFlagIndex].Guessed = true;
    }

    public Sprite GetFlagSpriteIndex(int flagIndex)
    {
        return GameData.Instance.CountrySetPerGame[flagIndex].Flag; 
    }
}