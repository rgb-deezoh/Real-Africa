using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using System;

public class LevelManager : MonoBehaviour
{
    public ParticleSystem winPart;
    private AudioManager audioMang;
    //Anim
    public Animator ques_anim;
    public Animator answer_anim;
    //Initilize
    private ToggleSystem toggleSystem;

    public TextMeshProUGUI timeText;
    public float remainingTime;
    public bool tapped;
    public bool isGameActive;

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI totalPoints;

    public TextMeshProUGUI complete;
    public TextMeshProUGUI loose;

    public int points;

    //TextHolders
    public TMP_Text questionHolder;
    public Text optionOne;
    public Text optionTwo;
    public Text optionThree;

    public Text[] options;
    public int ques_pos;
    //Geography Class

    public GameObject rating;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject retry;
    public GameObject next;
    public GameObject totalPointsHolder;

    public int freshLength;
    //quest & ans
    public GameObject level;

    [System.Serializable]
    public class Quiz
    {
        public string question;
        public string answer;
        public bool asked;
        public bool answered;

        public Quiz(string q, string a, bool ask, bool ans)
        {
            question = q;
            answer = a;
            asked = ask;
            answered = ans;
        }
    }
    [System.Serializable]
    public class Wrong
    {
        public string wrongOne;

        public Wrong(string w)
        {
            wrongOne = w;
        }
    }

    [System.Serializable]
    public class WrongTwo
    {
        public string wrongTwo;
        public WrongTwo(string w)
        {
            wrongTwo = w;
        }
    }

    public Quiz[] correctAnswer;
    public Wrong[] wrongAnswerOne;
    public WrongTwo[] wrongAnswerTwo;

    public int correctIndex;
    public int wrongIndexOne;
    public int wrongIndexTwo;

    void Start()
    {
        remainingTime = 60;
        toggleSystem = FindObjectOfType<ToggleSystem>();
        audioMang = FindObjectOfType<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (tapped) {
            if (isGameActive) {
                remainingTime -= Time.deltaTime; // Substracts 1 second
                                                 //Converts the time into a whole number
                timeText.SetText("" + Mathf.Round(remainingTime));
                //Checks if time is less than 0 and triggers game over method
                if (remainingTime < 0)
                {
                    ChallengeComplete();
                }
            }
        }
    }
    public void ChallengeComplete()
    {
        isGameActive = false;
        level.SetActive(false);
        rating.SetActive(true);
        RatePlayer();
    }
    //real logic
    public void GetIndex() { 
        correctIndex = UnityEngine.Random.Range(0, correctAnswer.Length);
        correctAnswer[correctIndex] = new Quiz(correctAnswer[correctIndex].question, correctAnswer[correctIndex].answer, false, false);
        questionHolder.text = correctAnswer[correctIndex].question;

        correctAnswer[correctIndex].asked = true;
        
        //wrong answer index one
        wrongIndexOne = correctIndex;
        wrongAnswerOne[wrongIndexOne] = new Wrong(wrongAnswerOne[wrongIndexOne].wrongOne);
        //wrong answer index two
        wrongIndexTwo = correctIndex;
        wrongAnswerTwo[wrongIndexTwo] = new WrongTwo(wrongAnswerTwo[wrongIndexTwo].wrongTwo);

        ques_pos = UnityEngine.Random.Range(0, options.Length);

        // answer position
        switch (ques_pos)
        {
            case 0:
                options[0].text = correctAnswer[correctIndex].answer;
                options[1].text = wrongAnswerOne[wrongIndexOne].wrongOne;
                options[2].text = wrongAnswerTwo[wrongIndexTwo].wrongTwo;
                break;
            case 1:
                options[0].text = wrongAnswerTwo[wrongIndexTwo].wrongTwo;
                options[1].text = correctAnswer[correctIndex].answer;
                options[2].text = wrongAnswerOne[wrongIndexOne].wrongOne;
                break;
            case 2:
                options[0].text = wrongAnswerOne[wrongIndexOne].wrongOne;
                options[1].text = wrongAnswerTwo[wrongIndexTwo].wrongTwo;
                options[2].text = correctAnswer[correctIndex].answer;
                break;
        }
    }
    public string Answer()
    {
        string answer = correctAnswer[correctIndex].answer;
        return answer;
    }
    public bool Asked()
    {
        bool finished = correctAnswer[correctIndex].asked;
        return finished;
    }
    public void RatePlayer()
    {
        if(points >= 100)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            next.SetActive(true);
            totalPointsHolder.SetActive(true);
            totalPoints.text = "" + points;
            winPart.Play();
            audioMang.mech.PlayOneShot(audioMang.winEffect, 1.0f);
            complete.gameObject.SetActive(true);
        }
        else if(points >= 50)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            next.SetActive(true);
            totalPointsHolder.SetActive(true);
            totalPoints.text = "" + points;
            winPart.Play();
            audioMang.mech.PlayOneShot(audioMang.winEffect, 1.0f);
            complete.gameObject.SetActive(true);
        }
        else
        {
            star1.SetActive(true);
            retry.SetActive(true);
            totalPointsHolder.SetActive(true);
            totalPoints.text = "" + points;
            loose.gameObject.SetActive(true);
        }
    }
    public void Dior()
    {
        SceneManager.LoadScene("Dior");
    }

    public void Survivor()
    {
        SceneManager.LoadScene("Survivor");
    }

    public void Tapped()
    {
        isGameActive = true;
        GetIndex();
        level.SetActive(true);
        tapped = true;
    }

    public int ReduceLength()
    {
        int arrLength = correctAnswer.Length;
        for (int index = correctIndex; index < arrLength - 1; index++)
        {
            
            correctAnswer[index] = correctAnswer[index + 1];
            arrLength --;
        }
        return arrLength;
    }
    //Remove element after it has been answered
    public void RemoveElement<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }
}
