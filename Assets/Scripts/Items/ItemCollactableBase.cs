using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{

    public string comparteTag = "Player";
    public ParticleSystem collectParticleSystem;
    public float timeToHide = 3;
    public GameObject graphicItem;

    [Header("Sounds")]
    public AudioSource audioSource;


    private void Awake()
    {
        //if (collectParticleSystem != null) collectParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(comparteTag))
        {
            Collect();
        }
    }



    protected virtual void Collect()
    {
        if(graphicItem != null) graphicItem.SetActive(false);
        Invoke(nameof(HideObject), timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }


    protected virtual void OnCollect()
    {
        if (collectParticleSystem != null) collectParticleSystem.Play();
        if (audioSource != null && audioSource.clip != null)
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
    }
}
