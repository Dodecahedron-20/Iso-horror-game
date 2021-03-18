using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float sprintSpeed;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float maxStamina;
    [SerializeField]
    float currentStamina;
    [SerializeField]
    int staminaToUse;

    public float health;
    public TextMeshProUGUI gameOverText;

    //private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    //Coroutine regen;

    bool isSprinting = false;
    bool isDead;

    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        currentStamina = maxStamina;

        //StartCoroutine(RegenStamina());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(currentStamina > 0)
            {
                isSprinting = true;
                Sprint();
            }
            else
            {
                moveSpeed = walkSpeed;
                isSprinting = false;
            }
        }
        else
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
        }

        if(health <= 0)
        {
            Debug.Log("ded");
            StartCoroutine(Death());
        }
    }

    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private void Sprint()
    {
        if(isSprinting == true)
        {
            moveSpeed = sprintSpeed;
            //currentStamina = Mathf.Clamp(currentStamina - staminaToUse * Time.deltaTime, 0f, 100f);
        }        
    }

    //IEnumerator RegenStamina()
    //{
    //    yield return new WaitForSeconds(2);

    //    while (currentStamina <= 0)
    //    {
    //        currentStamina += maxStamina / 100;
    //        yield return regenTick;
    //    }  
    //}

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameScene");
    }
}
