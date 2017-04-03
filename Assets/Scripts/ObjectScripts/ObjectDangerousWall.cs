using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectDangerousWall : MonoBehaviour {
public Transform respawnPos;
  public Vector3 direction;
  float speed;
 Vector3 startPos;
    public float moveSpeed;
public float travelDistance;

    Vector3 posOne;
    Vector3 posTwo;
    float startTime;
    bool goingToOne = true;

    // Use this for initialization
    void Start () {
        //Set start position to current position	
        startPos = transform.position;
        startTime = Time.time;

        //set startPost to current position
        startPos = transform.position;

        //set posOne to startPos+direction*travelDistance
        posOne = startPos + (direction * travelDistance);

        //set posTwo to startPos-direction*travelDistance
        posTwo = startPos - (direction * travelDistance);

    }

    // Update is called once per frame
    void Update () {
        //Move in direction, facroting frame rate independednce and speed
        transform.Translate(direction * speed * Time.deltaTime);

            //Calculate how far obj has traveled
            float disCovered = (Time.time - startTime) * moveSpeed;

            //Calculate what % through the journey
            float fracJourney = disCovered / travelDistance;

            if (fracJourney > 1)
            {

                //toggle goingToOne
                goingToOne = !goingToOne;

                //set startTime to current time
                startTime = Time.time;

                //set % through journey to 0
                disCovered = 0f;
                fracJourney = 0f;
            }

            //going to location one?
            if (goingToOne)
            {

                //move smoothly towards posOne
                transform.position = Vector3.Lerp(posTwo, posOne, fracJourney);

            }
            else
            {

                //move smoothly towards posTwo
                transform.position = Vector3.Lerp(posOne, posTwo, fracJourney);
            }
        }


  private void OnTriggerEnter(Collider other)
  {
        //Collidfe with player?
        if (other.CompareTag("Player"))
        {

            //Set player position to respawnPos and set my position to startPos
            other.transform.position = respawnPos.position;
            transform.position=startPos;

        }
    SceneManager.LoadScene("Badlevel");
  }
    void OnDrawGizmos()
    {
        //Set color to red
        Gizmos.color = Color.red;

        //is startPos 0?
        if (startPos == Vector3.zero)
        {

            //draw a line from current position+ direction * distance
            Gizmos.DrawLine(transform.position, transform.position + direction * travelDistance);
            Gizmos.DrawLine(transform.position, transform.position - direction * travelDistance);
        }
        else
        {

            //draw a line from startPos+direction*distance
            Gizmos.DrawLine(startPos, startPos + direction * travelDistance);
            Gizmos.DrawLine(startPos, startPos - direction * travelDistance);
        }
    }
}
