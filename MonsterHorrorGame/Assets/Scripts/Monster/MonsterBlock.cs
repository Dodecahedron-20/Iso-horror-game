using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject thisthing = null;
    [SerializeField]
    private GameObject monDirect = null;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
      monDirect.SetActive(true);
      Destroy(thisthing);
    }
}
