using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GrassAnime : MonoBehaviour
{

    void Start()
    {
        float randomTime = Random.Range(2f, 2.5f);
        float randomX = Random.Range(2f, 2.5f);
        float randomY = Random.Range(2f, 2.5f);
        float randomZ = Random.Range(2f, 2.5f);

        iTween.PunchScale(gameObject,iTween.Hash(
            "amount",new Vector3(randomX,randomY,randomZ),
            "time",randomTime,
            "looptype",iTween.LoopType.loop
            ));
    }
}
