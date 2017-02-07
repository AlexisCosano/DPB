using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    /// <summary>
    /// Variable estatica del RaceManager per a poder-hi accedir des de tot arreu
    /// </summary>
    public static RaceManager current;

    /// <summary>
    /// HACK: Variable temporal per al numero de players. Aixo vindra de la pantalla de sel�leccio de players
    /// </summary>
    [Range(1, 4)]
    public int numPlayers;

    /// <summary>
    /// Punts des d'on poden comencar els players
    /// </summary>
    public Transform[] startPoints;

    /// <summary>
    /// Hack: Variable temporal per a tenir acces al player i poder instanciar
    /// </summary>
    public GameObject player;

    void Awake()
    {
        if(current != null)
        {
            Debug.LogWarning("RaceManager already created. Gonna destroy myself");
            Destroy(this);
        }

        current = this;

        DebugUtils.AssertError(startPoints.Length >= 4, "There are not enough start points for a 4 players race.");

        PlayersInPosition();
    }

    /// <summary>
    /// Posa cada player al seu start point i elimina el start
    /// </summary>
    protected void PlayersInPosition()
    {
        for(int i = 0; i < numPlayers; i++)
        {

        }
    }
}
