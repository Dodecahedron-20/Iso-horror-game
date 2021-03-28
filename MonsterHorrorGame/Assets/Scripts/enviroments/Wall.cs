using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private GameObject currentGameObject;
    [SerializeField]
    private float alpha = 0.1f;
    [SerializeField]
    private float opaque = 1f;

    private bool trans = false;

    // Start is called before the first frame update
    void Start()
    {
      currentGameObject = gameObject;

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Q))
      {
        if (trans == false)
        {
          Transparent(currentGameObject.GetComponent<Renderer>().material, alpha);
          trans = true;
        }
        else
        {
          Transparent(currentGameObject.GetComponent<Renderer>().material, opaque);
          trans = false;
        }

      }
    }







    private void Transparent(Material mat, float alphaVal)
    {

      Color oldColor = mat.color;
      Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
      mat.SetColor("_Color", newColor);
    }


}
