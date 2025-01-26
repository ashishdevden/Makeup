using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeupManager : MonoBehaviour
{

    public static MakeupManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(this);
    }

    public Color currentSkinColor;
    public Color currentUnderEyeColor;
    public Color currentBlushColor;

    public Action<Color> updateFaceColor;
    public Action<Color> updateUnderEyeColor;
    public Action<Color> updateBlushColor;

    public void UpdateFaceColor(Image img)
    {
        currentSkinColor = GetColorWithThisOpasity(img.color, 0.18f);
        updateFaceColor?.Invoke(currentSkinColor);
    }

    public void UpdateUnderEyeColor(Image img)
    {
        currentUnderEyeColor = GetColorWithThisOpasity(img.color, 0.18f);
        updateUnderEyeColor?.Invoke(currentUnderEyeColor);
    }

    public void UpdateBlushColor(Image img)
    {
        currentBlushColor = GetColorWithThisOpasity(img.color, 0.18f);
        updateBlushColor?.Invoke(currentBlushColor);
    }


    public Color GetColorWithThisOpasity(Color color, float opacity)
    {
        Color newColor = color;
        newColor.a = opacity;
        return newColor;
    }

}
