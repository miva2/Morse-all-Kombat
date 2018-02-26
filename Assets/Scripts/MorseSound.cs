using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseSound : MonoBehaviour {
    public static MorseSound morseSound;

    public AudioClip dotSound;
    public AudioClip dashSound;
    public float spaceDelay;
    public float letterDelay;
    public float charDelay;

    private AudioSource source;
    
    public void Start()
    {
        source = GetComponent<AudioSource>();

        //StartCoroutine("PlayMorseSound", "..--.-");
        StartCoroutine("PlayMorseSound", MorseDictionary.TranslateStringToMorse("Fight!"));
        //StartCoroutine("PlayMorseSound", MorseDictionary.TranslateStringToMorse("Hello world"));
        morseSound = this;
    }

    public IEnumerator PlayMorseSound(string morseCode)
    {
        char[] morse = morseCode.ToLowerInvariant().ToCharArray();
        Debug.Log("morseCode: " + morse.Length.ToString());

        for(int i = 0; i < morseCode.Length; i++)
        {
            if(morseCode[i].Equals(' ')) { yield return new WaitForSeconds(spaceDelay); }

            source.clip = GetAudioClipForChar(morseCode[i]);
            source.Play();
            yield return new WaitForSeconds(charDelay);
        }

    }

    public void PlayDeathSound()
    {
        if (PlayerScript.useGlitch)
        {
            AudioClip ac = dotSound;
            source.clip = ac;
            source.loop = true;
            source.Play();
        }
        else
        {
            StartCoroutine(PlayMorseSound(MorseDictionary.TranslateStringToMorse("You Died!")));
        }
    }

    private AudioClip GetAudioClipForChar(char c)
    {
        if (c.Equals(Morse.DOT))
        {
            return dotSound;
        } else if (c.Equals(Morse.DASH))
        {
            return dashSound;
        }
        else
        {
            return null;
        }
    }

   
}
