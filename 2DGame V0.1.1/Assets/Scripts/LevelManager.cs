﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float aguanta = 3f;
    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Reaparecer()
    {
        StartCoroutine("Respawn");
    }

    public IEnumerator Respawn()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(aguanta);
        player.transform.position = player.spawn;
        player.gameObject.SetActive(true);
    }
}