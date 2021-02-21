using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderCameraScript : MonoBehaviour
{
    // public RenderTexture texture;
    public float multiplier = 10;
    //public Material effectMaterial;
    private Material effectMaterial;

    private void Awake()
    {
        effectMaterial = new Material(Shader.Find("Hidden/HighlightShader"));
        effectMaterial.SetFloat("_Multiplier", multiplier);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
