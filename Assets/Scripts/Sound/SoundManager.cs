using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource[] audioSources;

    public void playSfx(int index)
    {
        audioSources[index].Stop();
        audioSources[index].Play();
    }
    
}
