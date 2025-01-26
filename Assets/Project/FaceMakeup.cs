using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMakeup : MonoBehaviour
{
    public Renderer renderer;

    Material skin;
    Material underEye;
    Material blush;

    private void Start()
    {
        skin = renderer.materials[0];
        underEye = renderer.materials[1];
        blush = renderer.materials[2];

        MakeupManager.Instance.updateFaceColor += ApplyColorToSkin;
        MakeupManager.Instance.updateBlushColor += ApplyColorToBlush;
        MakeupManager.Instance.updateUnderEyeColor += ApplyColorToUnderEye;
        ApplyInitialColor();
    }

    private void ApplyInitialColor()
    {
        ApplyColorToSkin(MakeupManager.Instance.currentSkinColor);
        ApplyColorToUnderEye(MakeupManager.Instance.currentUnderEyeColor);
        ApplyColorToBlush(MakeupManager.Instance.currentBlushColor);
    }

    void ApplyColorToSkin(Color color)
    {
        skin.color = color;
    }

    void ApplyColorToUnderEye(Color color)
    {
        underEye.color = color;
    }

    void ApplyColorToBlush(Color color)
    {
        blush.color = color;
    }

    private void OnDestroy()
    {
        MakeupManager.Instance.updateFaceColor -= ApplyColorToSkin;
        MakeupManager.Instance.updateBlushColor -= ApplyColorToBlush;
        MakeupManager.Instance.updateUnderEyeColor -= ApplyColorToUnderEye;
    }

}
