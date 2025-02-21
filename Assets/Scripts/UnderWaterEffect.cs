using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class UnderWaterEffect : MonoBehaviour
{
    public GameObject boundingBox;
    public GameObject player;

    public Volume postProcessingVolume;
    public Color underWaterColor;
    public bool underWater;
    
    //Effects
    private Vignette vignette;
    private DepthOfField depthOfField;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        postProcessingVolume.profile.TryGet(out depthOfField);
        postProcessingVolume.profile.TryGet(out colorAdjustments);
        postProcessingVolume.profile.TryGet(out vignette);
    }

    private void FixedUpdate()
    {
        if (boundingBox.GetComponent<BoxCollider>().bounds.Contains(player.transform.position))
        {
            underWater = false;
        }
        else
        {
            underWater = true;
        }

        if (!underWater)
        {
            vignette.intensity.value = 0.35f;
            depthOfField.focusDistance.value = 0.1f;
            colorAdjustments.colorFilter.value = underWaterColor;
        }
        else
        {
            vignette.intensity.value = 0.292f;
            depthOfField.focusDistance.value = 5f;
            colorAdjustments.colorFilter.value = Color.white;
        }
    }
}
