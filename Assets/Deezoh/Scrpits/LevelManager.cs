using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float remainingTime;
    public bool clicked;
    public bool isGameActive;
    public bool askedD;

    public TextMeshProUGUI pointsText;
    private int points;

    public int ques_pos;

    //TextHolders

    public TMP_Text questionHolder;
    public Text optionOne;
    public Text optionTwo;
    public Text optionThree;

    public Text[] options;

    //OptionLogic

    public ToggleGroup option1;
    public ToggleGroup option2;
    public ToggleGroup option3;
    Toggle toggle;

    //Geography Class

    public GameObject rating;

    [System.Serializable]
    public class Quiz
    {
        public string topic;
        public string question;
        public string answer;
        public bool asked;
        public bool answered;

        public Quiz(string t, string q, string a, bool ask, bool ans)
        {
            topic = t;
            question = q;
            answer = a;
            asked = ask;
            answered = ans;
        }
    }
    [System.Serializable]
    public class Wrong
    {
        public string topic;
        public string wrongOne;

        public Wrong(string t, string w)
        {
            topic = t;
            wrongOne = w;
        }
    }

    [System.Serializable]
    public class WrongTwo
    {
        public string topic;
        public string wrongTwo;

        public WrongTwo(string t, string w)
        {
            topic = t;
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
        isGameActive = true;
        GetIndex();
    }

    // Update is called once per frame
    void Update()
    {
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

        if(toggle.isOn && isGameActive)
        {
            GetIndex();
            toggle.isOn = false;
        }
    }
    public void ChallengeComplete()
    {
        isGameActive = false;
    }

    //real logic
    public void GetIndex()
    {
        //correct answer index
        correctIndex = Random.Range(0, correctAnswer.Length);
        correctAnswer[correctIndex] = new Quiz(correctAnswer[correctIndex].topic, correctAnswer[correctIndex].question, correctAnswer[correctIndex].answer, false, false);
        questionHolder.text = correctAnswer[correctIndex].question;
        correctAnswer[correctIndex].asked = true;
        //wrong answer index one
        wrongIndexOne = correctIndex;
        wrongAnswerOne[wrongIndexOne] = new Wrong(wrongAnswerOne[wrongIndexOne].topic, wrongAnswerOne[wrongIndexOne].wrongOne);
        //wrong answer index two
        wrongIndexTwo = correctIndex;
        wrongAnswerTwo[wrongIndexTwo] = new WrongTwo(wrongAnswerTwo[wrongIndexTwo].topic, wrongAnswerTwo[wrongIndexTwo].wrongTwo);

         ques_pos = Random.Range(0, options.Length);

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

    public void Option1()
    {
        toggle = option1.ActiveToggles().FirstOrDefault();
    }

    public void Option2()
    {
        toggle = option2.ActiveToggles().FirstOrDefault();
    }

    public void Option3()
    {
        toggle = option3.ActiveToggles().FirstOrDefault();
    }
}
