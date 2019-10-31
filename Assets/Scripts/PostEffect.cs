using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    public Material red;
    public void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, dest, red);
    }
}
