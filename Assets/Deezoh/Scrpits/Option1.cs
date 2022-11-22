using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option1 : MonoBehaviour
{
    public Image nationFlag;
    public int firstIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.NationArray();
        RollNewNation();


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void RollNewNation()
    {
        firstIndex = Random.Range(0, GameManager.Instance.nation.Length);
        GameManager.Instance.nation[firstIndex] = new GameManager.Country();
        Debug.Log(firstIndex);
        Debug.Log(GameManager.Instance.nation[firstIndex].flag);
        
    }

    public Sprite SpriteIndex(int flagIndex)
    {
        return GameManager.Instance.nation[flagIndex].flag;
    }
    
}
