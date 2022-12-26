using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hp = 100.0f;
    // Start is called before the first frame update
    public void GetDamage(float amount)
    {
        hp -= amount;
        if (hp < 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);

        FindObjectOfType<GameManager>().EndGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PUNCH")
        {
            GetDamage(10.0f);
        }
    }
}
