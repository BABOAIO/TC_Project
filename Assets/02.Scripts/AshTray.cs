using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AshTray : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 25f;
    public float attackAmount = 10.0f;
    private Rigidbody AshRigidbody;



    void Start()
    {
        AshRigidbody = GetComponent<Rigidbody>();
        AshRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playercontroller = other.GetComponent<PlayerController>();

            if (playercontroller != null)
            {
                playercontroller.GetDamage(attackAmount);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
