using System;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
    private AudioSource _audioSource;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Når vi kolliderer med noe, ødelegg game objectet.
    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        _meshRenderer.enabled = false;
        Destroy(gameObject, _audioSource.clip.length);
    }
}
