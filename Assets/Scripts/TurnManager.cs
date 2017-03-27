using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour, ITurnManager {

    private static TurnManager _instance;
    public static ITurnManager Instance { get { return _instance; } }

    private List<Character> _turnOrder = new List<Character>();
    public List<Character> TurnOrder { get { return _turnOrder; } }
    private IEnumerator<Character> turnEnumerator;

    void Awake()
    {
        if (_instance != null && !_instance.Equals(this))
            GameObject.Destroy(_instance.gameObject);
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        var allCharacters = FindObjectsOfType<Character>();
        TurnOrder.AddRange(allCharacters);

        turnEnumerator = _turnOrder.GetEnumerator();
	}
	
    public Character NextCharacter()
    {
        if (!turnEnumerator.MoveNext()) {
            Renew();
        }
        return turnEnumerator.Current;
    }

    public void Renew()
    {
        TurnOrder.Clear();

        var allCharacters = FindObjectsOfType<Character>();
        allCharacters.Select(c => c.gameObject).Where(gObj => enabled);
        TurnOrder.AddRange(allCharacters.Select(c => c.GetComponent<Character>()));

        turnEnumerator = _turnOrder.GetEnumerator();
        turnEnumerator.MoveNext();
    }
	// Update is called once per frame
	//void Update () {
		
	//}


}
