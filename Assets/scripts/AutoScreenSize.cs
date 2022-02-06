using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScreenSize : MonoBehaviour
{
    [SerializeField] Canvas _canvas;

    private void OnEnable()
    {
        float width = _canvas.GetComponent<RectTransform>().rect.width;
        float height = _canvas.GetComponent<RectTransform>().rect.height;

        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }
}
