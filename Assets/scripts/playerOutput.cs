using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOutput : MonoBehaviour
{
    
    public float playerDisFromCentre;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
   
    }

    public float centreBetweenPlanets(Vector2 planet1, Vector2 planet2)
    {
        float dis = (planet1.y + planet2.y) / 2;
        return dis;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, new Vector2(gameObject.transform.position.x, playerDisFromCentre));
        
    }
}
