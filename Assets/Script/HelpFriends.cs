using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;

public class HelpFriends : MonoBehaviour
{
    public Text infoText;
    public AudioClip helpFriendSound;
    public GameObject miniMap;
    private GameObject cage;
    private AudioSource audioSource;
    private bool canOpen;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cage")
        {
            cage = other.gameObject;
            canOpen = true;
            infoText.text = "Click E to help your freind";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Cage")
            emptyData();
    }

    private void Update()
    {
        if (cage != null && canOpen && Input.GetKeyDown(KeyCode.E)) {
            try
            {
                iTween.ShakeScale(cage, new Vector3(140, 140, 140), 1f);
            }
            catch(Exception e)
            {
                print(e);
            }
            Destroy(cage,1.5f);
            infoText.text = "";
            emptyData();
            audioSource.PlayOneShot(helpFriendSound);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {

            try
            {
                miniMap.SetActive(!miniMap.activeSelf);
            }
            catch (Exception e)
            {
                print(e);
            }
        }
    }

    public void emptyData()
    {
        cage = null;
        canOpen = false;
        infoText.text = "";
    }
}
