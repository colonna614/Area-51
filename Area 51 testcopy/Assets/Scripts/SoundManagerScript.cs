using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Pistol, Shotgun, CrateOpening, Knife, ChaChing, GetHit;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        Pistol = Resources.Load<AudioClip>("SFX/Pistol");
        Knife = Resources.Load<AudioClip>("SFX/Knife");
        Shotgun = Resources.Load<AudioClip>("SFX/Shotgun");
        CrateOpening = Resources.Load<AudioClip>("SFX/CrateOpening");
        ChaChing = Resources.Load<AudioClip>("SFX/ChaChing");
        GetHit = Resources.Load<AudioClip>("SFX/GetHit");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "SFX/Pistol":
                audioSrc.PlayOneShot(Pistol);
                break;
            case "SFX/Shotgun":
                audioSrc.PlayOneShot(Shotgun);
                break;
            case "SFX/CrateOpening":
                audioSrc.PlayOneShot(CrateOpening);
                break;
            case "SFX/Knife":
                audioSrc.PlayOneShot(Knife);
                break;
            case "SFX/ChaChing":
                audioSrc.PlayOneShot(ChaChing);
                break;
            case "SFX/GetHit":
                audioSrc.PlayOneShot(GetHit);
                break;
        }
    }
}
