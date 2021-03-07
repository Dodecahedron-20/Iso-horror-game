using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsVisable : MonoBehaviour
{
//put a room's walls in one empty GameObject,
//and the interior stuff in a secondary one under that

  [SerializeField]
  private GameObject roomWalls = null;

  [SerializeField]
  private GameObject roomInterior = null;

  //has this room been into before?
  [SerializeField]
  private bool investigated = false;

  private bool insideRoom = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



private void OnOff()
{
  if (investigated == false)
  {
    RoomEnterFirst();
  }
  else
  {
    if (insideRoom == false)
    {
      RoomEnter();
    }
    else
    {
      RoomExit();
    }

  }
}


private void RoomEnterFirst()
{
  roomWalls.SetActive(true);
  roomInterior.SetActive(true);
}

private void RoomEnter()
{
  roomInterior.SetActive(true);
}

private void RoomExit()
{
  roomInterior.SetActive(false);
}




}
