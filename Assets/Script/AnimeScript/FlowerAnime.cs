using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnime : MonoBehaviour
{
    void Start()
    {
        float randomTime = Random.Range(2f, 2.5f);
        float randomX = Random.Range(2f, 2.5f);
        float randomY = Random.Range(2f, 2.5f);
        float randomZ = Random.Range(2f, 2.5f);

        iTween.PunchScale(gameObject, iTween.Hash(
            "amount", new Vector3(randomX, randomY, randomZ),
            "time", randomTime,
            "looptype", iTween.LoopType.loop
            ));
    }
}
