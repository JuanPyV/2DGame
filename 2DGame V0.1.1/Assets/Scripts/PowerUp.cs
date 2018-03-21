using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private float mult = 1.4f;
    private float duration = 4f;

    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Pickup(collision));
        }        
    }

    IEnumerator Pickup (Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        player.transform.localScale *= mult;

        GetComponent<ParticleSystemRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.transform.localScale /= mult;

        Destroy(gameObject);
    }
}
