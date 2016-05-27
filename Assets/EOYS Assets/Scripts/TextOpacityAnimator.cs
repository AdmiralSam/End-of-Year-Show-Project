using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOpacityAnimator : ParameterizedAnimator
{
    public List<Text> textFields;
    private Dictionary<Text, float> textAlphas;

    public override void SetParameter(float parameter)
    {
        foreach (Text text in textFields)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, textAlphas[text] * parameter);
        }
    }

    private void Start()
    {
        textAlphas = new Dictionary<Text, float>();
        foreach (Text text in textFields)
        {
            textAlphas[text] = text.color.a;
        }
    }
}