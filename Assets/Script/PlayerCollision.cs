using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject killMobEffect;
    public GameObject coin;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public AudioClip mobDie;
    public AudioClip collectCoin;
    public AudioClip hitPlayerSound;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    private AudioSource audioSource;
    private int nbKilledMobs = 0;
    private bool canInstantiate = true ;
    private bool isInvinsible = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cam0")
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(false);
        } 
        if (other.gameObject.tag == "cam1")
            cam1.SetActive(true);
        if (other.gameObject.tag == "cam2")
            cam2.SetActive(true);
        if (other.gameObject.tag == "cam3")
            cam3.SetActive(true);


        if(other.gameObject.name == "EndLvl")
            SceneManager.LoadScene(2);


        if (other.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(collectCoin);
            GameObject effect = Instantiate(pickupEffect,other.transform.position,Quaternion.identity);
            Destroy(effect,0.4f);
            PlayerInfo.playerInfo.getCoins();
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cam1")
            cam1.SetActive(false);
        if (other.gameObject.tag == "cam2_1")
            cam2.SetActive(false);
        if (other.gameObject.tag == "cam2_2")
            cam2.SetActive(false);
        if (other.gameObject.tag == "cam3")
            cam3.SetActive(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Hurt" && !isInvinsible)
        {
            isInvinsible = true;
            PlayerInfo.playerInfo.setHealth(-1);
            iTween.PunchPosition(gameObject, Vector3.back * 5, .5f);
            audioSource.PlayOneShot(hitPlayerSound);
            StartCoroutine("ResetInvinsible");
        }
        if (hit.gameObject.tag == "Mobs" && canInstantiate)
        {
            canInstantiate = false;
            nbKilledMobs++;
            audioSource.PlayOneShot(mobDie);
            GameObject effect = Instantiate(killMobEffect, hit.gameObject.transform.parent.gameObject.transform.position, Quaternion.identity);
            Instantiate(coin, hit.gameObject.transform.parent.gameObject.transform.position + Vector3.forward, Quaternion.identity * Quaternion.Euler(90, 0, 0));
            Destroy(effect, 0.8f);
            Destroy(hit.gameObject.transform.parent.gameObject);
            StartCoroutine("ResetInstantiate");
        }
        if (hit.gameObject.tag == "Death")
            StartCoroutine("RespawnPlayer");

    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }

    IEnumerator ResetInstantiate()
    {
        yield return new WaitForSeconds(0.8f);
        canInstantiate = true;
    }
    IEnumerator ResetInvinsible()
    {
        for(int i =0; i < 10; i++)
        {
            yield return new WaitForSeconds(.2f);
            skinnedMeshRenderer.enabled = !skinnedMeshRenderer.enabled;
        }
        yield return new WaitForSeconds(.2f);
        skinnedMeshRenderer.enabled = true;
        isInvinsible = false;
    }
}
