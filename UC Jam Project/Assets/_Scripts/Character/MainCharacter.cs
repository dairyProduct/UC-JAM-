using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Movement))]
public class MainCharacter : MonoBehaviour
{
    private void Start()
    {
        Debug.LogWarning(UnityEngine.Rendering.GraphicsSettings.defaultRenderPipeline.GetType().Name);
    }
}
