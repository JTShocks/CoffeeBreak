using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Queuer : Target
{
    Rigidbody rb;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite hitSprite;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void OnHit()
    {
        base.OnHit();

    }

    public override void DestroyTarget()
    {
        //base.DestroyTarget();
        float rng = Random.Range(-1, 1);
        if(rng < 0)
        {
            rng = -1;
        }
        else
        {
            rng = 1;
        }


        rb.AddForce(Vector3.left*40*rng, ForceMode.Impulse);
        spriteRenderer.sprite = hitSprite;
    }
}
