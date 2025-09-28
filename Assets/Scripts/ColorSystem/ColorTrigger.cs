using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    [SerializeField] private ColorType triggerColor;
    [SerializeField] private ColorRuleSet rules;
    [SerializeField] private PlatformMover targetPlatform;
    

    private void OnCollisionEnter(Collision collision)
    {
        var block = collision.gameObject.GetComponent<ColorBlock>();
        if (block != null && rules.CanActivate(block.blockColor, triggerColor))
        {
            targetPlatform.StartMoving();
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        var block = collision.gameObject.GetComponent<ColorBlock>();
        if (block != null && rules.CanActivate(block.blockColor, triggerColor))
        {
            
            targetPlatform.StartMoving();
        }
    }

}
