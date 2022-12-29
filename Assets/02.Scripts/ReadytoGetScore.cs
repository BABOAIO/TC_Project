using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Scripts.Fractures;

public class ReadytoGetScore : MonoBehaviour
{
    int _score;

    AudioSource audio;

    private void Start()
    {
        this.tag = "CHUNK";
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SELECTABLE"))
        {
            if (GetComponentInParent<ChunkGraphManager>().gotScore_Fracture) return;

            _score = GetComponentInParent<ChunkGraphManager>().score;
            print("score : " + _score);


            GetComponentInParent<ChunkGraphManager>().gotScore_Fracture = true;

            GameManager.Instance.AddScore(_score);

            audio.Play();
        }
    }
}
