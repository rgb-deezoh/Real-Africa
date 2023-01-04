using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{

    // Object Instance
    public static Locations Instance;
    
    //Game Objects
    public GameObject pointPrefab;
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

    //timeRates
    private float popUpDelay = 1.0f;

    //booleans
    public bool isLocated;

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
        isLocated = false;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    IEnumerator SpawnLocation()
    {
        //randomly chooses a single location
        yield return new WaitForSeconds(popUpDelay);
        int spawnIndex = Random.Range(0, spawnArray.Length);
        Vector3 spawnPos = spawnArray[spawnIndex];
        Instantiate(pointPrefab, spawnPos, pointPrefab.transform.rotation);
    }
    public void SartQuiz()
    {
        StartCoroutine(SpawnLocation());
        isLocated = true;
    }
}
