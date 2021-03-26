using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Walk()
    {
        FindObjectOfType<AudioManager>().Play("playerFotstep");
    }
    public void Stomp()
    {
        FindObjectOfType<AudioManager>().Play("MonsterFootstep");
    }
}
