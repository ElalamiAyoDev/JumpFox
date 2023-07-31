using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CheckpointMgr : MonoBehaviour
{
    public static CheckpointMgr checkpointMgr;

    public GameObject checkpointPickupEffect;
    public AudioClip checkpointPickupAudio;
    private Vector3 lastPosition;
    private AudioSource audioSource;

    private void Awake()
    {
        checkpointMgr = this;
    }

    void Start()
    {
        lastPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            lastPosition = transform.position;
            audioSource.PlayOneShot(checkpointPickupAudio);
            GameObject effect = Instantiate(checkpointPickupEffect, other.gameObject.transform.position, Quaternion.identity);
            Destroy(effect, .8f);
            Destroy(other.gameObject,.5f);
        }
    }

    public void Respawn()
    {
        transform.position = lastPosition;
        PlayerInfo.playerInfo.setHealth(3);
    }
}
