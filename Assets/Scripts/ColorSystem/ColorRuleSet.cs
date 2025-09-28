using UnityEngine;

[CreateAssetMenu(menuName = "Color System/Color Rule Set")]
public class ColorRuleSet : ScriptableObject
{
    public ColorRule[] rules;

    public bool CanActivate(ColorType block, ColorType target)
    {
        foreach (var rule in rules)
        {
            if (rule.blockColor == block && rule.targetColor == target)
            {
                return rule.canActivate;
            }
        }
        return false;
    }
}
