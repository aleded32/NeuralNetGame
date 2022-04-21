using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neuralNetwork : MonoBehaviour
{

    playerMovement pm;
    planetSpawner ps;
    birdSpawner bs;

    neuron[] inputLayer;
    neuron[] hiddenLayer;
    neuron outputLayer;

    List<float> inputHiddenWeights;
    List<float> hiddenOutputWeights;

    float distanceFromPlanets;
    float verticalSpeed;

    float[] neuronErrorInputHidden = new float[3] {0,0,0 };
    float neuronErrorHiddenOutput = 0;

    void Start()
    {
        pm = gameObject.GetComponent<playerMovement>();
        ps = FindObjectOfType<planetSpawner>();
        bs = FindObjectOfType<birdSpawner>();

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
        distanceFromPlanets = disBetweenPlanetsPlayer(ps.planets[0].transform.position, ps.planets[1].transform.position);
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
                    
                    hiddenLayer[j].inputValue = HyperBolicTangentActivationFunction(hiddenLayer[j].inputValue);
                   
                    outputLayer.inputValue += hiddenLayer[j].inputValue * hiddenOutputWeights[j];
                    outputLayer.inputValue = HyperBolicTangentActivationFunction(outputLayer.inputValue);
                    
                }
            }
            neuronConnection += 3; 
        }

        //foreach (neuron hidden in hiddenLayer)

        //Debug.Log(0 <= outputLayer.inputValue);
        return 0 <= outputLayer.inputValue;

    }

    float hyperBolicTangentDervitiave(float x)
    {
        return 1- Mathf.Pow((Mathf.Exp(x) - Mathf.Exp(-x)) / (Mathf.Exp(x) + Mathf.Exp(-x)),2);
    }

    public void backPropagation()
    {

        if (outputLayer.inputValue > 0)
            neuronErrorHiddenOutput = (1 - outputLayer.inputValue);
        else if (outputLayer.inputValue < 0)
            neuronErrorHiddenOutput = (1 + outputLayer.inputValue);
        
        

        for (int i = 0; i < neuronErrorInputHidden.Length; i++)
        {
            if (hiddenLayer[i].inputValue > 0)
               neuronErrorInputHidden[i] = (1 - hiddenLayer[i].inputValue);
            else if (outputLayer.inputValue < 0)
                neuronErrorInputHidden[i] = (1 + hiddenLayer[i].inputValue);
        }
        
        

        for (int i = 0; i < hiddenOutputWeights.Count; i++)
        {
            hiddenOutputWeights[i] -= 0.3f * neuronErrorHiddenOutput * hyperBolicTangentDervitiave(outputLayer.inputValue) * outputLayer.inputValue;
        }

        int k = 0;
        for (int i = 0; i < inputHiddenWeights.Count; i++)
        {
            if (k > 2)
                k = 0;

            
            inputHiddenWeights[i] -= 0.3f * neuronErrorInputHidden[k] * hyperBolicTangentDervitiave(hiddenLayer[k].inputValue) * hiddenLayer[k].inputValue;
            k++;
        }
        

    }


    float HyperBolicTangentActivationFunction(float x)
    {
        return (Mathf.Exp(x) - Mathf.Exp(-x)) / (Mathf.Exp(x) + Mathf.Exp(-x));
    }

    public float disBetweenPlanetsPlayer(Vector2 planet1, Vector2 planet2)
    {
        float dis = (planet1.y + planet2.y) / 2;
        return Vector2.Distance(transform.position, new Vector2(transform.position.x,dis - 0.25f));

    }

    // Update is called once per frame
    void Update()
    {
        if (doNeuralNetwork())
        {
           
            pm.move();
            
        }
        
    }

  
}
