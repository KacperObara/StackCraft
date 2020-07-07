using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public void ChangeMusicVolume(float volume)
    {
        GetComponent<AudioSource>().volume = volume;
    }
}
