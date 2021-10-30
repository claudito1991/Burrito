using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera mainCamera;
    private RaycastHit[] Hits = new RaycastHit[1];
    public LayerMask layerMask;
    public Transform player;
    public bool isMoving;
    public Vector3 targetPoint;
    public TransitedNodeList baseDeLista;
    public bool autoReturnState = false;
    public bool Returning;
    private Transform target;
    public int waypointIndex = -1;
    private Transform currentPosition;
    public float timeRemaining = 5f;
    public float waitingTime = 2f;
    public DiceThrow throwingDice;
    private GameManaging gameManager;

    // Start is called before the first frame update
    void Start()
    {
        throwingDice = GetComponent<DiceThrow>();
        gameManager = FindObjectOfType<GameManaging>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameManager.ChangeTurn();
            gameManager.listaSkippedTurns.Add(1);
            gameManager.CheckPassedTurns();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            autoReturnState = true;
            waypointIndex = baseDeLista.listaNodos.Count - 1;
        }
        MovementReturning();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Este código va a hacer un raycast y si el layer no es el enmascarado se va a guardar ese punto en target point y pasar la variable isMoving a true
            isMoving = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.RaycastNonAlloc(ray, Hits) > 0)
            {


                if (baseDeLista.listaNodos.Contains(Hits[0].collider) || Hits[0].transform.GetComponent<Orden>().branchPosition > baseDeLista.actualNodePosition + 1)
                {
                    //Si ya pasé por el nodo o si el nodo al que me quiero mover está más lejos que 1 nodo de distancia, esta parte del código no me va a dejar mover.
                    //Puedo agregar un cartel en la UI que le diga al jugador que no se puede mover ahí.
                    return;


                }
                else
                {
                    targetPoint = new Vector3(Hits[0].point.x, player.position.y, Hits[0].point.z);
                    //Agrego un 0 por cada turno que efectivamente me muevo.
                    gameManager.listaSkippedTurns.Add(0);
                }
                

            }
        }

        if (isMoving)
        // Si la variable isMoving está en true voy a moverme suavemente entre los puntos. 
        {

            player.position = Vector3.Lerp(player.position, targetPoint, Time.deltaTime * 1f);
            //player.Translate(new Vector3(Hits[0].point.x, player.position.y, Hits[0].point.z));
            if (Vector3.Distance(player.position, targetPoint) < 0.5f)
            {
                isMoving = false;
            }
        }



    }


    //public void AutoReturnToBase()
    //{
    //    if (autoReturnState)
    //    {
    //        for (int i = baseDeLista.listaNodos.Count - 1; i >= 0; i--)
    //        {
    //            Debug.Log($"los elementos son: {baseDeLista.listaNodos[i]}");
    //            PlayerMovement(baseDeLista.listaNodos[i].GetComponent<Transform>().position);
    //        }

    //    }
    //    autoReturnState = false;


    //}

    //public void PlayerMovement(Vector3 targetPosition)
    //{

    //    Returning = true;


    //    if (Returning)
    //    // Si la variable isMoving está en true voy a moverme suavemente entre los puntos. 
    //    {
    //        player.position = Vector3.Lerp(player.position, targetPosition, Time.deltaTime * 1f);
    //        //player.Translate(new Vector3(Hits[0].point.x, player.position.y, Hits[0].point.z));
    //        if (Vector3.Distance(player.position, targetPoint) < 0.2f)
    //        {
    //            Returning = false;
    //        }
    //    }
    //}

    public void MovementReturning()

    {
        
        if(autoReturnState && !isMoving)
        {
            if (baseDeLista.listaNodos.Count == 0)
            {
                return;
            }

            
            //Debug.Log($"Waypoint index max value is: {waypointIndex}");

            if (target == null)
            {
                target = baseDeLista.listaNodos[waypointIndex-1].GetComponent<Transform>();
                Debug.Log($"Waypoint index actual : {waypointIndex}");
                Debug.Log($"Waypoint index destino : {waypointIndex-1}");
            }

            //Debug.Log($"El target es: {target.position}");


            //Debug.Log($"Target position: {target.position}");
            //transform.position = Vector3.Lerp(player.position, target.position, Time.deltaTime * 1f);
            player.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 1f);
            //transform.position = target.position;
            //Debug.Log($"waypoint index : {waypointIndex}");


            //Debug.Log($"Distance to waypoint is: {Vector3.Distance(transform.position, target.position)}");

            if (Vector3.Distance(transform.position, target.position) <= 1f)
            {

                timeRemaining -= Time.deltaTime;
                

                if(timeRemaining<=0)
                {
                    //Debug.Log($"The dice result of this node is: {throwingDice.DiceThrowing()}");
                    
                    GetNextWayPoint();
                    timeRemaining = waitingTime;
                }
                
            }
        }


    }
    public void GetNextWayPoint()
    {
       // Debug.Log("Se entró a GetNextWaypoing");
        if (waypointIndex <= 0)
        {
            autoReturnState = false;
            gameManager.ChangeTurn();
            waypointIndex = -1;
            target = null;
        }
        else
        {
            //Este código puesto acá hace que el dado se tire en todos los nodos menos en el último
            gameObject.SendMessage("DiceThrowing");
            
            waypointIndex--;
        }
        target = baseDeLista.listaNodos[waypointIndex].GetComponent<Transform>();

    }

    IEnumerator waitingAtWaypoint()
    {
        
        yield return new WaitForSeconds(5f);
        
    }


}


