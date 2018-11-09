using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using Random = System.Random;

[CustomEditor(typeof(Deck))]
public class DeckEditor : Editor
{
    private Deck _deck;
    private GameObject topCard;
    
    float counter = 0;


    private void OnEnable()
    {
        _deck = (Deck)target;
    }
}
