using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    private Level_1_Manager level_1_ManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        level_1_ManagerScript = FindObjectOfType<Level_1_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(level_1_ManagerScript.remainingTime < 0)
        {
            Destroy(gameObject);
        }
    }
}
