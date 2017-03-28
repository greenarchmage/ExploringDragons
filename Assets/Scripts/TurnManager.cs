using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    private static TurnManager instanceObj;
    public static TurnManager Instance { get { return instanceObj; } }

    private List<Character> turnOrderList = new List<Character>();
    public List<Character> TurnOrder { get { return turnOrderList; } }
    private IEnumerator<Character> turnEnumerator;

    void Awake()
    {
        if (instanceObj != null && !instanceObj.Equals(this))
            GameObject.Destroy(instanceObj.gameObject);
        instanceObj = this;
    }

	// Use this for initialization
	void Start () {
        Character[] allCharacters = FindObjectsOfType<Character>();
        TurnOrder.AddRange(allCharacters);

        turnEnumerator = turnOrderList.GetEnumerator();
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

        Character[] allCharacters = FindObjectsOfType<Character>();
        allCharacters.Select(c => c.gameObject).Where(gObj => enabled);
        TurnOrder.AddRange(allCharacters.Select(c => c.GetComponent<Character>()));

        turnEnumerator = turnOrderList.GetEnumerator();
        turnEnumerator.MoveNext();
    }
	// Update is called once per frame
	//void Update () {
		
	//}


}
