using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    bool isSprinting = false;
    bool isDead;

    public int maxStamina = 100;
    public int currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            UseStamina(15);
            moveSpeed = 6f;
        }
        else
        {
            moveSpeed = 3f;
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

    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            moveSpeed = 3f;
            Debug.Log("Not enough stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
