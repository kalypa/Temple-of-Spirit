using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Rendering;

public class VolumeChange : SingleMonobehaviour<VolumeChange>
{
    [HideInInspector] public Volume volume;
    [HideInInspector] public Vignette vignette;
    private void Start()
    {
        volume = GetComponent<Volume>();
        if (volume.sharedProfile.TryGet<Vignette>(out Vignette v))
        {
            vignette = v;
        }
    }
}
