using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neuron
{
    public enum neuronLayer {INPUT, HIDDEN, OUTPUT};
    public float weight;
    int bias;
    neuronLayer layer;
    float inputValue = 0;

    neuron(neuronLayer _layer, float _inputValue)
    {
        layer = _layer;
        weight = Random.value;

        if (layer == neuronLayer.INPUT)
            inputValue = _inputValue;
    }

   
    
}
