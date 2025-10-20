using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{

    public string compareTag = "Player";
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
        Debug.Log($"[ItemCollactableBase] Colidiu com: {collision.name}");

        if (collision.transform.CompareTag(compareTag))
        {
            Debug.Log("[ItemCollactableBase] Tag bateu, coletando...");
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
        Debug.Log("[ItemCollactableBase] OnCollect chamado");
        if (collectParticleSystem != null)
        {
            collectParticleSystem.transform.SetParent(null);
            collectParticleSystem.Play();
        }
        if (audioSource != null && audioSource.clip != null)
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
    }

}
