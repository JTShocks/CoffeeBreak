using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Queuer : Target
{
    Rigidbody rb;
    protected SpriteRenderer spriteRenderer;
    [SerializeField] Sprite hitSprite;
        private float amplitude = 0.001f; // How much the object bobs up and down
    private float frequency = 1f; // How fast the bobbing occurs
    private float bobOffset = -0f; // Initial offset for the sine wave
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        frequency = Random.Range(5,10);
    }




    public override void Update()
    {

        bobOffset += Time.deltaTime * frequency; // Update the offset over time

        float bobAmount = Mathf.Sin(bobOffset) * amplitude; // Calculate bobbing amount based on sine wave
        transform.position = new Vector3(transform.position.x, transform.position.y + bobAmount, transform.position.z); 

    }

    public override void OnHit()
    {
        int rng = Random.Range(0, GameManager.Instance.NPC_hit_sounds.Count);
        EventManager.OnPlaySoundEffect(GameManager.Instance.NPC_hit_sounds[rng]);
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


        rb.AddForce(Vector3.left*20*rng, ForceMode.Impulse);
        spriteRenderer.sprite = hitSprite;
    }
}
