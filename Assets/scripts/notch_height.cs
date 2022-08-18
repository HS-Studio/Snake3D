using System.Collections;
using UnityEngine;

public class notch_height : settings
{
    RectTransform rectHeader;
    void Start()
    {
        Change_height();
    }

    public void ChangeNotch (float val)
    {
        notch_height = val;
        saveSettings();

        Change_height();
        //rectHeader.sizeDelta = new Vector2(rectHeader.rect.width, rectHeader.rect.height + notch_height);
    }

    private void Change_height()
    {
        loadSettings();
        rectHeader = GetComponent<RectTransform>();
        rectHeader.sizeDelta = new Vector2(rectHeader.rect.width, 128.0f + notch_height);
    }
}
