using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notch_height : settings
{
    RectTransform rectHeader;
    void Start()
    {
        loadSettings();
        rectHeader = GetComponent<RectTransform>();
        rectHeader.sizeDelta = new Vector2(rectHeader.rect.width, 128.0f + notch_height);
    }

    public void ChangeNotch (float val)
    {
        notch_height = val;
        saveSettings();

        Start();
        //rectHeader.sizeDelta = new Vector2(rectHeader.rect.width, rectHeader.rect.height + notch_height);
    }
}
