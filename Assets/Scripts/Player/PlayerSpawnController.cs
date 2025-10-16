using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public float duration = 0.5f;
    public Ease ease = Ease.OutBack;

    //private void Start()
    //{
    //    transform.localScale = Vector3.zero;
    //    transform.DOScale(Vector3.one, duration).SetEase(ease);
    //}

    public void Spawn()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, duration).SetEase(ease);
    }

}

