using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    [SerializeField] private ColorType triggerColor;
    [SerializeField] private ColorRuleSet rules;
    [SerializeField] private PlatformMover targetPlatform;
    [SerializeField] private PressurePlate pressurePlate;
    

    private void OnCollisionEnter(Collision collision)
    {
        var block = collision.gameObject.GetComponent<ColorBlock>();
        if (block != null && rules.CanActivate(block.blockColor, triggerColor))
        {
            targetPlatform.MoveToPointB();
            if (pressurePlate != null)
            {
               // pressurePlate.PressDown();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        var block = collision.gameObject.GetComponent<ColorBlock>();
        if (block != null && rules.CanActivate(block.blockColor, triggerColor))
        {
            
            targetPlatform.MoveToPointA();
            if (pressurePlate != null)
            {
              //  pressurePlate.Release();
            }
        }
    }

}
