using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Colour Swatch Object")]
public class ColorSwatchObject : ScriptableObject
{
    [SerializeField]
    private List<Color> _colorSwatches = new List<Color>();

    public List<Color> ColorSwatches => _colorSwatches;
}

