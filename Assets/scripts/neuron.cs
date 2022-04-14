using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neuron
{
    public enum neuronLayer {INPUT, HIDDEN, OUTPUT};
    public int bias = 1;
    neuronLayer layer;
    public float inputValue = 0;

    public neuron(neuronLayer _layer, float _inputValue)
    {
        layer = _layer;


    }

   
    
}
