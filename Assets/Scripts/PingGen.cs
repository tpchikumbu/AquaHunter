using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingGen : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;
    private float pingTimer;
    private float pingTimerMax;
    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        pingTimerMax = 1f;
        pingTimer = 0f;
    }

    // Update is called once per frame
    void Update() {
        pingTimer += Time.deltaTime;
        color.a = Mathf.Lerp(pingTimerMax, 0, pingTimer / pingTimerMax);
        spriteRenderer.color = color;
        
        if (pingTimer >= pingTimerMax) {
            Destroy(gameObject);
        }
    }
}
