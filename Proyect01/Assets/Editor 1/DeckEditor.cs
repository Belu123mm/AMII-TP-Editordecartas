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
    private bool add;
    private bool remove;
    private bool shuffle;
    private bool empty;
    private bool removeSpecific;

    private void OnEnable()
    {
        _deck = (Deck)target;
        topCard = _deck.mainDeck[0];
    }

    public override void OnInspectorGUI()
    {
        _deck.card2Add = (GameObject)EditorGUILayout.ObjectField("Card to add", _deck.card2Add, typeof(GameObject), false);
        //topCard = (GameObject)EditorGUILayout.ObjectField("Top card", topCard, typeof(GameObject), true);
        add = EditorGUILayout.Toggle("Add to deck", add);
        remove = EditorGUILayout.Toggle("remove from deck", remove);
        shuffle = EditorGUILayout.Toggle("Shuffle deck", shuffle);
        empty = EditorGUILayout.Toggle("Empty deck", empty);
        removeSpecific = EditorGUILayout.Toggle("Remove the card", removeSpecific);
        for (int i = 0; i < _deck.mainDeck.Count; i++)
        {
            _deck.mainDeck[i] = (GameObject)EditorGUILayout.ObjectField("Deck layout", _deck.mainDeck[i], typeof(GameObject), false);
        }
        if (add)
        {
            _deck.mainDeck.Add(_deck.card2Add);
            add = false;
        }
        if (remove && _deck.mainDeck.Count >= 1)
        {
            _deck.mainDeck.RemoveAt(_deck.mainDeck.Count - 1);
            remove = false;
        }
        if (shuffle)
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
            shuffle = false;
        }
        if (removeSpecific)
        {
            _deck.mainDeck.Remove(_deck.card2Add);
            removeSpecific = false;
        }
        if (empty)
        {
            _deck.mainDeck.RemoveRange(0, _deck.mainDeck.Count);
            empty = false;
        }
    }
}
