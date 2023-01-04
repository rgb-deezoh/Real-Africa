using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //game objects
    public GameObject holderPrefab;
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject ratingWin;

    //Animators

    //booleans
    public bool isLocated;
    public bool isGameActive;
    public float remainingTime;
    public bool activeTime;

    //GUI
    public TextMeshProUGUI timeText;
    public Button playButton;


    //timeRates
    private float popUpDelay = 3.0f;

    //psoitions
    //north
    private static float xNorth = 0.36f;
    private static float yNorth = 2.29f;
    //northwest
    private static float xNorthWest = -1.29f;
    private static float yNorthWest = 2.82f;
    //west
    private static float xWest = -0.89f;
    private static float yWest = 1.78f;
    //east
    private static float xEast = 0.78f;
    private static float yEast = 0.53f;
    //south 
    private static float xSouth = 0.35f;
    private static float ySouth = -1.07f;
    //central
    private static float xCentral = 0.2f;
    private static float yCentral = 0.71f;


    private static Vector3 north = new Vector3(xNorth, yNorth, 0);
    private static Vector3 northwest = new Vector3(xNorthWest, yNorthWest, 0);
    private static Vector3 west = new Vector3(xWest, yWest, 0);
    private static Vector3 east = new Vector3(xEast, yEast, 0);
    private static Vector3 south = new Vector3(xSouth, ySouth, 0);
    private static Vector3 central = new Vector3(xCentral, yCentral, 0);

    private Vector3[] spawnArray = new[] { north, northwest, west, east, south, central };

    // Start is called before the first frame update
    public void Start()
    { 
        remainingTime = 60;
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive && activeTime)
        {
            remainingTime -= Time.deltaTime; // Substracts 1 second

            //Converts the time into a whole number
            timeText.SetText("Time: " + Mathf.Round(remainingTime));

            if(remainingTime < 0)
            {
                isGameActive = false;
                ratingWin.SetActive(true);
                gameUI.SetActive(false);
            }
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RatePlayer()
    {
        //show rating panel

    }

    public void PlayGame()
    {
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        isGameActive = true;
        activeTime = true;
        StartCoroutine(SpawnHolder());

    }
    IEnumerator SpawnHolder()
    {
        //randomly chooses a single location
        yield return new WaitForSeconds(popUpDelay);
        int spawnIndex = Random.Range(0, spawnArray.Length);
        Vector3 spawnPos = spawnArray[spawnIndex];
        Instantiate(holderPrefab, spawnPos, holderPrefab.transform.rotation);
    }
}
