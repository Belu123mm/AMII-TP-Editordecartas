using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Random = System.Random;

[CustomEditor(typeof(Deck))]
public class DeckEditor : Editor
{
    private Deck _deck;
    private GameObject topCard;
    private int deckMaxCards;
    private int cardCounter;
    float counter = 0;

    private void OnEnable()
    {
        _deck = (Deck)target;
    }

    public override void OnInspectorGUI()
    {
        _deck.card2Add = (GameObject)EditorGUILayout.ObjectField("Card to add", _deck.card2Add, typeof(GameObject), false);
        deckMaxCards = EditorGUILayout.IntField("Max card ammount", deckMaxCards);
        //topCard = (GameObject)EditorGUILayout.ObjectField("Top card", topCard, typeof(GameObject), true);

        if (GUILayout.Button("Add card") && cardCounter < deckMaxCards)
        {
            _deck.mainDeck.Add(_deck.card2Add);
            cardCounter++;
        }
        if (GUILayout.Button("Remove last added card") && _deck.mainDeck.Count >= 1)
        {
            _deck.mainDeck.RemoveAt(_deck.mainDeck.Count - 1);
            cardCounter--;
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
            _deck.mainDeck.Remove(_deck.card2Add);
            cardCounter--;
        }
        if (GUILayout.Button("Empty deck"))
        {
            _deck.mainDeck.RemoveRange(0, _deck.mainDeck.Count);
            cardCounter = 0;
        }
        Debug.Log(cardCounter);
        for (int i = 0; i < _deck.mainDeck.Count; i++)
        { 
            _deck.mainDeck[i] = (GameObject)EditorGUILayout.ObjectField(("Card "+ (i+1)), _deck.mainDeck[i], typeof(GameObject), false);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(20)) && cardCounter < deckMaxCards)
            {
                _deck.mainDeck.Add(_deck.mainDeck[i]);
                cardCounter++;
            }
            if (GUILayout.Button("-", GUILayout.Width(20), GUILayout.Height(20)))
            {
                _deck.mainDeck.Remove(_deck.mainDeck[i]);
                cardCounter--;
            }
            EditorGUILayout.EndHorizontal();
        }

    }
}
