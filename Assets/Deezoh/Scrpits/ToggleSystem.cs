using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleSystem : MonoBehaviour
{
    ToggleGroup toggles;
    Toggle choice;

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        toggles = GetComponent<ToggleGroup>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.isGameActive && choice.isOn)
        {
            levelManager.GetIndex();
            choice.isOn = false;
        }
    }
    public void Submit()
    {
        choice = toggles.ActiveToggles().FirstOrDefault();
        Debug.Log(choice.GetComponentInChildren<Text>().text);
        if (levelManager.Answer() == choice.GetComponentInChildren<Text>().text)
        {
            levelManager.points += 5;
            levelManager.pointsText.text = "Points: " + levelManager.points;
        }
        else
        {
            levelManager.points -= 5;
            levelManager.pointsText.text = "Points: " + levelManager.points;
        }
    }
}
