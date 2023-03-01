using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongController : MonoBehaviour
{
    public float songBPM;
    public float secPerBeat;
    public float songPos;
    public float SongPosInBeats;
    public float dspSongTime;
    public AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
        secPerBeat = 60f / songBPM;
        dspSongTime = (float)AudioSettings.dspTime;
        song.Play();        
    }

    // Update is called once per frame
    void Update()
    {
        if (song.isPlaying) MeasureTime();
    }

    void MeasureTime()
    {
        songPos = (float)AudioSettings.dspTime - dspSongTime;
        SongPosInBeats = songPos / secPerBeat;
    }
}
