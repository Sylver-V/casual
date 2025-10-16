using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartAnimation();
        }
    }

    public void StartAnimation()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        itens = itens.Where(p => p != null).ToList();

        foreach (var p in itens)
        {
            if (p != null)
            {
                p.transform.localScale = Vector3.zero;
            }
        }

        Sort();

        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            if (itens[i] != null)
            {
                itens[i].transform.DOScale(1, scaleDuration).SetEase(ease);
                yield return new WaitForSeconds(scaleTimeBetweenPieces);
            }
        }
    }


    private void Sort()
    {
        itens = itens.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }
}
