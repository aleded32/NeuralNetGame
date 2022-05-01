using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class geneticAlgo : MonoBehaviour
{

   
    birdSpawner bs;

    void Start()
    {
        bs = GetComponent<birdSpawner>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void crossover()
    {
        if (bs.birds.TrueForAll(x => x.GetComponent<playerMovement>().isNotMoving))
        {
            bs.birds = bs.birds.OrderByDescending(x => x.GetComponent<playerMovement>().fitness).ToList();

            
            

            for (int i = 2; i < bs.birds.Count; i++)
            {

                for (int j = 0; j < 6; j++)
                {
                    if (Random.Range(0, 1) % 2 == 0)
                    {
                        bs.birds[i].GetComponent<neuralNetwork>().inputHiddenWeights[j] = bs.birds[0].GetComponent<neuralNetwork>().inputHiddenWeights[j];

                }
                    else
                    {
                        bs.birds[i].GetComponent<neuralNetwork>().inputHiddenWeights[j] = bs.birds[1].GetComponent<neuralNetwork>().inputHiddenWeights[j];

                    }
                }

                for (int k = 0; k < 3; k++)
                {
                    if (Random.Range(0, 1) % 2 == 0)
                    {
                        bs.birds[i].GetComponent<neuralNetwork>().hiddenOutputWeights[k] = bs.birds[0].GetComponent<neuralNetwork>().hiddenOutputWeights[k];

                    }
                    else
                    {
                        bs.birds[i].GetComponent<neuralNetwork>().hiddenOutputWeights[k] = bs.birds[1].GetComponent<neuralNetwork>().hiddenOutputWeights[k];

                    }
                }


                if (Random.Range(0, bs.birds.Count) == 2)
                {
                    int randWeight = Random.Range(0, 6);
                    bs.birds[i].GetComponent<neuralNetwork>().inputHiddenWeights[randWeight] = Random.Range(-1.0f, 1.0f);

                    randWeight = Random.Range(0, 3);
                    bs.birds[i].GetComponent<neuralNetwork>().hiddenOutputWeights[randWeight] = Random.Range(-1.0f, 1.0f);
                }
            }

            bs.allrocketsDead = true;

        }

    }
}
