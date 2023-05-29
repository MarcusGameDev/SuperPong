using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBall_Powerup : Powerup
{
    public float sizeModifier = 2;
    public Vector2 originalScale;



    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        originalScale = ball.gameObject.transform.localScale;
    }

    public override void Ability()
    {
        base.Ability();
        ball.gameObject.transform.localScale = ball.gameObject.transform.localScale * sizeModifier;
   //     ball.gameObject.
        
    }

    public override void AbilityReset()
    {
        base.AbilityReset();
        ball.gameObject.transform.localScale = originalScale;
    }
}
