using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ShaderCameraScript : MonoBehaviour
{
    // public RenderTexture texture;
    public float baseMultiplier = 0.25f;
    public float addMultiplier = 4f;
    //public Material effectMaterial;
    private Material effectMaterial;

    private void Awake()
    {
        effectMaterial = new Material(Shader.Find("Hidden/HighlightShader"));
        effectMaterial.SetFloat("_BaseMult", baseMultiplier);
        effectMaterial.SetFloat("_AddMult", addMultiplier);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
