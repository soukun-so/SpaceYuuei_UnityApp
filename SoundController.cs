using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip Choice;
    public AudioClip GoMain;

    public AudioClip Coin;
    public AudioClip Item;
    public AudioClip Dig;
    public AudioClip StartSe;
    public AudioClip Go;
    public AudioClip TimeOver;
    public AudioClip Denger;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ChoiceSe()
    {
        audioSource.PlayOneShot(Choice);
    }

    public void GoMainSe()
    {
        audioSource.PlayOneShot(GoMain);
    }

    public void CoinSe()
    {
        audioSource.PlayOneShot(Coin);
    }

    public void ItemSe()
    {
        audioSource.PlayOneShot(Item);
    }

    public void DigSe()
    {
        audioSource.PlayOneShot(Dig);
    }

    public void StartSeFunction()
    {
        audioSource.PlayOneShot(StartSe);
    }

    public void GoSe()
    {
        audioSource.PlayOneShot(Go);
    }

    public void TimeOverSe()
    {
        audioSource.PlayOneShot(TimeOver);
    }
    
    public void DengerSe()
    {
        audioSource.PlayOneShot(Denger);
    }
}
