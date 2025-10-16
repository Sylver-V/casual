using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBounceX : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceScaleX = 2f;
    public float bounceDuration = 2f;
    public float bounceDelay = 0.5f;
    public Ease bounceEase = Ease.OutBack;

    private Vector3 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        StartBounceLoop();
    }

    private void StartBounceLoop()
    {
        Vector3 targetScale = new Vector3(bounceScaleX, _originalScale.y, _originalScale.z);

        transform.DOScale(targetScale, bounceDuration)
            .SetEase(bounceEase)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(bounceDelay);
    }
}

