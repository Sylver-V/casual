using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider colliderCoin;
    public bool collect = false;
    public float lerp = 5f;
    public float minDistance = 1f;


    protected override void OnCollect()
    {
        base.OnCollect();
        colliderCoin.enabled = false;
        collect = true;
        //PlayerController.Instance.Bounce();
        //ItemManager.Instance.AddCoins();
    }

    protected override void Collect()
    {
        base.Collect();
    }

    private void Update()
    {
        if (collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);

            if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                //HideItens();
                Destroy(gameObject);
            }
        }
    }
}
