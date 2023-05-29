using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBall_PowerUp : Powerup
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    public override void Ability()
    {
        base.Ability();
        ball.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void AbilityReset()
    {
        base.AbilityReset();
        ball.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
