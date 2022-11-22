
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Level_1_Manager : MonoBehaviour
{
    //game objects
    public GameObject level_1;
    public GameObject ratingWin;
    public GameObject answerSection;
    public GameObject questionSection;

    //booleans
    public float remainingTime;
    public bool panelsActive;
    public bool gameFinished;

    //GUI
    public TextMeshProUGUI timeText;

    //Links
    private Locations locationScript;

    //
    private float delay = 3.0f;
    private float countDownDelay = 4.0f;

    // Start is called before the first frame update
    public void Start()
    {
        remainingTime = 60;
        panelsActive = false;
        gameFinished = false;
        locationScript = FindObjectOfType<Locations>();
    }

    // Update is called once per frame
    void Update()
    {
        if (locationScript.isLocated)
        {
            StartCoroutine(Pop());

            if (panelsActive)
            {
                StartCoroutine(Timer());
            }
        }

        if (remainingTime < 0)
        {
            ratingWin.SetActive(true);
            level_1.SetActive(false);
        }
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Skip()
    {

    }
    IEnumerator Pop()
    {
        yield return new WaitForSeconds(delay);
        questionSection.SetActive(true);
        answerSection.SetActive(true);
        timeText.gameObject.SetActive(true);
        panelsActive = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(countDownDelay);
        // Substracts 1 second
        remainingTime -= Time.deltaTime;
        //Converts the time into a whole number
        timeText.SetText("Time: " + Mathf.Round(remainingTime));
    }

    public void GetNation()
    {

    }
}