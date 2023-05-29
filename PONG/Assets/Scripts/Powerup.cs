using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    [HideInInspector] public BallController ball;
    public float powerUpTimer = 5;

    // Start is called before the first frame update
    public void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();    
        Debug.Log(ball.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == ball.gameObject)
        {
            Ability();
        }
    }

    public virtual void Ability()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(AbilityTimer());
    }

    public IEnumerator AbilityTimer()
    {

        yield return new WaitForSeconds(powerUpTimer);

        AbilityReset();
        Delete();
    }

    public void Delete()
    {
        Destroy(this.gameObject);
    }

    public virtual void AbilityReset()
    {

    }
}
