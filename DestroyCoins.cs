using System;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
    // Referanser til komponentene våre
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Når vi kolliderer med noe, ødelegg game objectet og spill av lyd
    private void OnTriggerEnter(Collider other)
    {
        // Spill av lydklippet vårt
        _audioSource.Play();
        // Disable mesh renderer komponenten så mynten blir usynlig uten at den blir ødelagt.
        _meshRenderer.enabled = false;
        // Ødelegg dette game objektet etter at lydklippet har spilt ferdig.
        Destroy(gameObject, _audioSource.clip.length);
    }
}

