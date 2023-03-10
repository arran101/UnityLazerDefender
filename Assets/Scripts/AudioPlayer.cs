using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Taken Damage")]
    [SerializeField] AudioClip takenDamageClip;
    [SerializeField] [Range(0f, 1f)] float takenDamageVolume = 1f;

    static AudioPlayer instance;

    void Awake() 
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            //even though we will destroy the gameObject anyway, the setActive to false here is to stop anything from using it just before it is destroyed, which can happen
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageTakenClip()
    {
        PlayClip(takenDamageClip, takenDamageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
    //This is an old function that was being used before PlayClip, keeping it because it shows the transition
    // public void PlayShootingClip()
    // {
    //     if(shootingClip != null)
    //     {
    //         AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
    //     }
    // }