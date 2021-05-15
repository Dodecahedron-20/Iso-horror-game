using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioSource clip;
    [SerializeField]
    private AudioSource runClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        runClip.Play();

    }

    public void Walk()
    {
        clip.Play();
        //FindObjectOfType<AudioManager>().Play("playerFotstep");
    }
    public void Stomp()
    {
        clip.Play();
        //FindObjectOfType<AudioManager>().Play("MonsterFootstep");
    }
}
