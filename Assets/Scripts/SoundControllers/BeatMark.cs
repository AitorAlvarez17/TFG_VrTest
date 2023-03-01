using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMark : MonoBehaviour
{
    public AudioClip click;
    public AudioSource player;
    public SongController SC;
    public int roundedBPMPos;
    public int lastBPMPos = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        roundedBPMPos = (int)SC.SongPosInBeats;
        if(roundedBPMPos > lastBPMPos)
        {
            player.PlayOneShot(click);
            lastBPMPos = roundedBPMPos;
        }
        
    }
}
