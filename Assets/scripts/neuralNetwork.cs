using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neuralNetwork : MonoBehaviour
{

    playerMovement pm;
    planetSpawner ps;

    neuron[] inputLayer;
    neuron[] hiddenLayer;
    neuron outputLayer;

    List<float> inputHiddenWeights;
    List<float> hiddenOutputWeights;

    float distanceFromPlanets;
    float verticalSpeed;


    void Start()
    {
        pm = gameObject.GetComponent<playerMovement>();
        ps = FindObjectOfType<planetSpawner>();


        inputHiddenWeights = new List<float>();
        hiddenOutputWeights = new List<float>();


        inputLayer = new neuron[2] { new neuron(neuron.neuronLayer.INPUT, 0),
                                     new neuron(neuron.neuronLayer.INPUT, 0)};

        hiddenLayer = new neuron[3] { new neuron(neuron.neuronLayer.HIDDEN, 0),
                                      new neuron(neuron.neuronLayer.HIDDEN, 0),
                                      new neuron(neuron.neuronLayer.HIDDEN, 0)};

        outputLayer = new neuron(neuron.neuronLayer.OUTPUT,0);

        for (int i = 0; i < 6; i++)
        {
            inputHiddenWeights.Add(Random.Range(-1.0f, 1.0f));
        }

        for(int i = 0; i < 3; i++)
            hiddenOutputWeights.Add(Random.Range(-1.0f, 1.0f));

    }

    public bool doNeuralNetwork()
    {
        distanceFromPlanets = disBetweenPlanetsPlayer(ps.planets[1].transform.position, ps.planets[0].transform.position);
        verticalSpeed = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        inputLayer[0].inputValue = distanceFromPlanets;
        inputLayer[1].inputValue = verticalSpeed;
        //input to hidden layer
       
        int neuronConnection = 0;
        for (int i = 0; i < inputLayer.Length; i++)
        {
            for (int j = 0; j < hiddenLayer.Length; j++)
            {

                hiddenLayer[j].inputValue += inputLayer[i].inputValue * inputHiddenWeights[j + neuronConnection];
                if (i == inputLayer.Length - 1)
                {
                    hiddenLayer[j].inputValue -= inputLayer[i].bias;
                    hiddenLayer[j].inputValue = sigmoidActivationFunction(hiddenLayer[j].inputValue);
                    outputLayer.inputValue += hiddenLayer[j].inputValue * hiddenOutputWeights[j];
                    
                }
            }
            neuronConnection += 3; 
        }

        Debug.Log(outputLayer.inputValue);

        if (outputLayer.inputValue <= 0)
            return false;
        else
            return true;

    }

       

    float sigmoidActivationFunction(float x)
    {
        return 1.0f / (1.0f + Mathf.Exp(-x));
    }

    public float disBetweenPlanetsPlayer(Vector2 planet1, Vector2 planet2)
    {
        float dis = (planet1.y + planet2.y) / 2;
        return Vector2.Distance(transform.position, new Vector2(transform.position.x, dis));

    }

    // Update is called once per frame
    void Update()
    {
        if (doNeuralNetwork())
        {
            pm.move();
        }
        outputLayer.inputValue = 0;
    }

  
}
