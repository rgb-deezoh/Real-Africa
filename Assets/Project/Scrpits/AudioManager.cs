using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mech;
    public AudioClip winEffect;
    public AudioClip correctAnserClip;
    public AudioClip wrongAnswerClip;

    private float audioVolume = 1.0f;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mech.volume = audioVolume;
    }

    public void UpdateVolume(float volume)
    {
        audioVolume = volume;
    }
}
