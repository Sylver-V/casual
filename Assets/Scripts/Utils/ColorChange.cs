using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    public float duration = .2f;
    public Color startColor = Color.white;

    private Color _startColor;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _startColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_startColor, duration).SetDelay(.5f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            LerpColor();
        }
    }
}
