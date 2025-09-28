using UnityEngine;

[CreateAssetMenu(menuName = "Color System/Color Rule")]
public class ColorRule : ScriptableObject
{
    public ColorType blockColor;
    public ColorType targetColor;
    public bool canActivate;
}
