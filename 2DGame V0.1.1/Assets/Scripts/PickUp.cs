﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coin)
    {
        CoinScore.coinAmount += 1;
        Destroy(gameObject);
    }

}
