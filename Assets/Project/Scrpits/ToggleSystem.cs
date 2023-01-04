using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using TMPro;


public class ToggleSystem : MonoBehaviour
{
    ToggleGroup toggles;
    Toggle choice;

    private LevelManager levelManager;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        toggles = GetComponent<ToggleGroup>();
        levelManager = FindObjectOfType<LevelManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (levelManager.isGameActive && choice.isOn)
        {
            levelManager.RemoveElement(ref levelManager.correctAnswer, levelManager.correctIndex);
            levelManager.RemoveElement(ref levelManager.wrongAnswerOne, levelManager.wrongIndexOne);
            levelManager.RemoveElement(ref levelManager.wrongAnswerTwo, levelManager.wrongIndexTwo);
            levelManager.GetIndex();
            choice.isOn = false;
        }
    }
    public void Submit()
    {
        choice = toggles.ActiveToggles().FirstOrDefault();
        //Debug.Log(choice.GetComponentInChildren<Text>().text);
        if (levelManager.Answer() == choice.GetComponentInChildren<TMP_Text>().text)
        {
            levelManager.points += 10;
            levelManager.pointsText.text = "Points: " + levelManager.points;
            audioManager.mech.PlayOneShot(audioManager.correctAnserClip, 1.0f);
        }
        else
        {
            levelManager.points -= 15;
            levelManager.pointsText.text = "Points: " + levelManager.points;
            audioManager.mech.PlayOneShot(audioManager.wrongAnswerClip, 1.0f);
        }
    }
}
