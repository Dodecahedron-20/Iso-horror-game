using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField]
    float sprintSpeed;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float maxStamina;
    
    public float currentStamina;

    [SerializeField]
    int staminaToUse;

    [SerializeField]
    Slider staminaBar;

    [SerializeField]
    Slider staminaBarTwo;

    //private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    //Coroutine regen;

    [SerializeField] bool isSprinting = false;
    [SerializeField] bool isMoving = false;
    bool isDead;

    [HideInInspector]
    public GameObject[] waypoint;

    Vector3 forward, right;

    [SerializeField]
    private Animator anim;

    private bool goo = false;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;

        staminaBarTwo.maxValue = maxStamina;
        staminaBarTwo.value = maxStamina;


        anim.SetBool("run", false);
        anim.SetBool("walk", false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            Move();
        }
        else
        {
            isMoving = false;
            anim.SetBool("run", false);
            anim.SetBool("walk", false);
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(isMoving == true)
            {
                if (currentStamina > 0)
                {
                    anim.SetBool("run", true);
                    isSprinting = true;
                    Sprint();

                }
                else
                {
                    moveSpeed = walkSpeed;
                    isSprinting = false;
                    anim.SetBool("run", false);
                    anim.SetBool("walk", true);
                }
            }           
        }
        else
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
            anim.SetBool("run", false);

        }
    }

    private void Move()
    {
        isMoving = true;

        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        anim.SetBool("walk", true);
        anim.SetBool("run", false);
    }

    private void Sprint()
    {
        if(isSprinting == true)
        {
            moveSpeed = sprintSpeed;
            currentStamina = Mathf.Clamp(currentStamina - staminaToUse * Time.deltaTime, 0f, 100f);
            staminaBar.value = currentStamina;
            staminaBarTwo.value = currentStamina;
        }        
    }

    public void StaminaRegen()
    {
        currentStamina += 12f;
        staminaBar.value = currentStamina;
        staminaBarTwo.value = currentStamina;
    }

    //public void Death()
    //{
    //    moveSpeed = 0;
    //    add animation here
    //}

    //public void PlayerSteps()
    //{
    //    if (goo == false)
    //    {
    //        FindObjectOfType<AudioManager>().Play("playerFotstep");
    //    }
    //    else
    //    {
    //        FindObjectOfType<AudioManager>().Play("goosteps");
    //    }

    //}
}
