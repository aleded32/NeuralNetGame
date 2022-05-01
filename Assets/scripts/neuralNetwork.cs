using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neuralNetwork : MonoBehaviour
{

    playerMovement pm;
    planetSpawner ps;
    geneticAlgo ga;

    neuron[] inputLayer;
    neuron[] hiddenLayer;
    public neuron outputLayer;

    public List<float> inputHiddenWeights;
    public List<float> hiddenOutputWeights;

    public float distanceFromPlanets;
    public float verticalSpeed;

    float[] neuronErrorInputHidden = new float[3] {0,0,0 };
    float neuronErrorHiddenOutput = 0;

    void Start()
    {
        pm = gameObject.GetComponent<playerMovement>();
        ps = FindObjectOfType<planetSpawner>();
        ga = FindObjectOfType<geneticAlgo>();

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
        

        inputLayer[0].inputValue = distanceFromPlanets;
        inputLayer[1].inputValue = verticalSpeed;
        //input to hidden layer
        

        int neuronConnection = 0;
        for (int i = 0; i < inputLayer.Length; i++)
        {
            for (int j = 0; j < hiddenLayer.Length; j++)
            {

                hiddenLayer[j].inputValue += inputLayer[i].inputValue * inputHiddenWeights[j + neuronConnection];
                
                
            }
            neuronConnection += 3; 
        }

        for (int k = 0; k < hiddenLayer.Length; k++)
        {
            hiddenLayer[k].inputValue = (float)System.Math.Tanh(hiddenLayer[k].inputValue);
            //Debug.Log("hidden layer " + k + " " + hiddenLayer[k].inputValue);
            // Debug.Log("hidden Values " + hiddenLayer[j].inputValue);
            outputLayer.inputValue += hiddenLayer[k].inputValue * hiddenOutputWeights[k];
        }

        outputLayer.inputValue = (float)System.Math.Tanh(outputLayer.inputValue);
        //foreach (neuron hidden in hiddenLayer)
        

        return  outputLayer.inputValue > 0;

    }



 


    

    public float disBetweenPlanetsPlayer(Vector2 planet1, Vector2 planet2)
    {
        float dis = ((planet1.y + planet2.y) / 2);
        if (dis <= 0)
            dis = 0;
        return Vector3.Distance(gameObject.transform.position, new Vector3(gameObject.transform.position.x, dis));
        
       
    }

    float disXbetweenRocketPlanet(Vector2 planet1)
    {
        return Vector2.Distance(gameObject.transform.position, new Vector3(planet1.x, gameObject.transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {

        distanceFromPlanets = disBetweenPlanetsPlayer(ps.planets[0].transform.position, ps.planets[1].transform.position);

        if(ps.planets.Count > 2)
            verticalSpeed = disXbetweenRocketPlanet(ps.planets[2].transform.position);
        else if(ps.planets.Count <= 2)
            verticalSpeed = disXbetweenRocketPlanet(ps.planets[0].transform.position);



        if (!pm.isNotMoving)
        {
            
            if (doNeuralNetwork() == true)
            {

                pm.move();

            }
        }
        else
            ga.crossover();

        


        //Debug.Log(verticalSpeed);

        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, new Vector2(gameObject.transform.position.x, distanceFromPlanets));

    }

}
