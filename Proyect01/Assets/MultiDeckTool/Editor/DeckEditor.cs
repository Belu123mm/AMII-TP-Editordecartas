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

    public override void OnInspectorGUI()
    {
        _deck.card2Add = (BaseCard) EditorGUILayout.ObjectField("Card to add", _deck.card2Add, typeof(BaseCard), false);
        _deck.deckMaxCards = EditorGUILayout.IntField("Max card ammount", _deck.deckMaxCards);
        _deck.deckMinCards = EditorGUILayout.IntField("Min card ammount", _deck.deckMinCards);

        if (GUILayout.Button("Add card") && _deck.cardCounter < _deck.deckMaxCards)
        {
            _deck.mainDeck.Add(_deck.card2Add);
            _deck.cardCounter++;
        }
        if (GUILayout.Button("Remove last added card") && _deck.mainDeck.Count >= 1)
        {
            _deck.mainDeck.RemoveAt(_deck.mainDeck.Count - 1);
            _deck.cardCounter--;
        }
        if (GUILayout.Button("Shuffle deck"))
        {
            int n = _deck.mainDeck.Count;
            var rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = _deck.mainDeck[k];
                _deck.mainDeck[k] = _deck.mainDeck[n];
                _deck.mainDeck[n] = value;
            }
        }
        if (GUILayout.Button("Remove specific card"))
        {
            _deck.mainDeck.RemoveAll(n => n==_deck.card2Add);
            _deck.cardCounter = _deck.mainDeck.Count;
        }
        if (GUILayout.Button("Sort by type"))
        {
            _deck.mainDeck = _deck.mainDeck.OrderBy(n => n.name).ToList();
        }
        if (GUILayout.Button("Empty deck")) 
        {
            _deck.mainDeck.RemoveRange(0, _deck.mainDeck.Count);
            _deck.cardCounter = 0;
        }
        if (GUILayout.Button("Try Deck"))
        {
            HandWindow.ShowWindow();
        }
        for (int i = 0; i < _deck.mainDeck.Count; i++)
        { 
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Card " + (i +1), GUILayout.Width(60));
            _deck.mainDeck[i] = (BaseCard) EditorGUILayout.ObjectField( _deck.mainDeck[i], typeof(BaseCard), false);
            if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(20)) && _deck.cardCounter < _deck.deckMaxCards)
            {
                _deck.mainDeck.Add(_deck.mainDeck[i]);
                _deck.cardCounter++;
            }
            if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(20)))
            {
                _deck.mainDeck.Remove(_deck.mainDeck[i]);
                _deck.cardCounter--;
            }
            if ( GUILayout.Button("Edit Card") ) {
                //Aca esta lo que edites no me mates D: 
                if (_deck.mainDeck[i])
                CardWindowEditor.CreateWindow();
                CardWindowEditor.window.card = _deck.mainDeck [ i ];
                
            }

            EditorGUILayout.EndHorizontal();
        }

    }
}
