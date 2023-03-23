using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CamMovement : MonoBehaviour
{
    [Space]
    [SerializeField] public GameObject camera = null;
    [Space]
    [SerializeField] public Button arrowUp = null;
    [SerializeField] public Button arrowDown = null;
    [SerializeField] public Button arrowRight = null;
    [SerializeField] public Button arrowLeft = null;
    [SerializeField] public Button zoomIn = null;
    [SerializeField] public Button zoomOut = null;

    [Space]
    public static int[] xDelta = new int[3] { 800, 200, 120 };
    public static int[] yDelta = new int[3] { 400, 200, 120 };

    [Space]
    public static int defaultX = 1568;
    public static int defaultY = -801;
    public static int defaultZ = -10;

    public static float[] defaultOrtographicSize = new float[] { 540F, 270F, 135F };

    public static float zoomOutX = 1468;
    public static float zoomOutY = -769;
    public static float zoomOutZ = -10;

    public static int[] maxX = new int[] {2007, 2485, 2718 };
    public static int[] minX = new int[] {856 , 377, 134 };

    public static int[] maxY = new int[] {-459, -191, -56 };
    public static int[] minY = new int[] {-1109, -1377, -1503 };
    [Space]
    public int currentX = defaultX;
    public int currentY = defaultY;
    public int currentZ = defaultZ;
    public float currentOrtographicSize = defaultOrtographicSize[1];
    public int currentZoom = 1;


    // Start is called before the first frame update
    public void Start()
    {
        arrowUp.interactable = true;
        arrowLeft.interactable = true;
        arrowRight.interactable = true;
        arrowDown.interactable = true;
        zoomIn.interactable = true;
        zoomOut.interactable = true;
        currentZoom = 1;
        currentX = defaultX;
        currentY = defaultY;
        currentZ = defaultZ;
        updateCamera();


    }

    //Mid:	1566,	-801,	-10

    //    Xmax: 1946
    //    Xmin: 912

    //    Ymax: -496
    //    Ymin: -1070

    public void moveRight()
    {
        if (currentX < maxX[currentZoom])
        {
            if( (currentX > (maxX[currentZoom] - xDelta[currentZoom])) || (currentX == (maxX[currentZoom] - xDelta[currentZoom])) )
            {
                currentX = maxX[currentZoom];
                updateCamera();
            }
            else
            {
                currentX += xDelta[currentZoom];
                updateCamera();
            }
        }
        else
        {
            //Buzzer
        }
    }

    public void moveLeft()
    {
        if (currentX > minX[currentZoom])
        {
            if ( (currentX < (minX[currentZoom] + xDelta[currentZoom])) || (currentX == (minX[currentZoom] + xDelta[currentZoom])) )
            {
                currentX = minX[currentZoom];
                updateCamera();
            }
            else
            {
                currentX -= xDelta[currentZoom];
                updateCamera();
            }
        }
        else
        {
            //Buzzer
        }
    }

    public void moveUp()
    {
        if (currentY < maxY[currentZoom])
        {
            if ( (currentY > (maxY[currentZoom] - yDelta[currentZoom])) || (currentY == (maxY[currentZoom] - yDelta[currentZoom])) )
            {
                currentY = maxY[currentZoom];
                updateCamera();
            }
            else
            {
                currentY += yDelta[currentZoom];
                updateCamera();
            }
        }
        else
        {
            //Buzzer
        }
    }

    public void moveDown()
    {
        if (currentY > minY[currentZoom])
        {
            if ( (currentY < (minY[currentZoom] + yDelta[currentZoom])) || (currentY == (minY[currentZoom] + yDelta[currentZoom])) )
            {
                currentY = minY[currentZoom];
                updateCamera();
            }
            else
            {
                currentY -= yDelta[currentZoom];
                updateCamera();
            }
        }
        else
        {
            //Buzzer
        }
    }

    void checkButtons()
    {
        if(currentX == maxX[currentZoom])
        {
            arrowRight.interactable = false;
            arrowLeft.interactable = true;
        }
        else if(currentX == minX[currentZoom])
        {
            arrowLeft.interactable = false;
            arrowRight.interactable = true;
        }
        else
        {
            arrowLeft.interactable = true;
            arrowRight.interactable = true;
        }

        if(currentY == maxY[currentZoom])
        {
            arrowUp.interactable = false;
            arrowDown.interactable = true;
        }
        else if(currentY == minY[currentZoom])
        {
            arrowDown.interactable = false;
            arrowUp.interactable = true;
        }
        else
        {
            arrowUp.interactable = true;
            arrowDown.interactable = true;
        }

        //if(currentZoom == 0)
        //{
        //    arrowDown.interactable = false;
        //    arrowUp.interactable = false;
        //    arrowLeft.interactable = false;
        //    arrowRight.interactable = false;
        //}

    }

    public void updateCamera()
    {
        if(currentX > maxX[currentZoom])
        {
            currentX = maxX[currentZoom];
        }
        else if (currentX < minX[currentZoom])
        {
            currentX = minX[currentZoom];
        }

        if (currentY > maxY[currentZoom])
        {
            currentY = maxY[currentZoom];
        }
        else if (currentY < minY[currentZoom])
        {
            currentY = minY[currentZoom];
        }

        camera.transform.position = new Vector3(currentX, currentY, currentZ);
        camera.GetComponent<Camera>().orthographicSize = defaultOrtographicSize[currentZoom];
        checkButtons();
    }

    public void zoomInCamera()
    {
        if(currentZoom == 0)
        {
            currentZoom++;
            zoomIn.interactable = true;
            zoomOut.interactable = true;
        }
        else if(currentZoom == 1)
        {
            currentZoom++;
            zoomIn.interactable = false;
            zoomOut.interactable = true;
        }
        else
        {
            //Buzzer
            zoomIn.interactable = false;
            zoomOut.interactable = true;
        }
        Debug.Log("Zoom In");
        updateCamera();
    }

    public void zoomOutCamera()
    {
        if (currentZoom == 1)
        {
            currentZoom--;
            camera.transform.position = new Vector3(zoomOutX, zoomOutY, zoomOutZ);
            zoomOut.interactable = false;
            zoomIn.interactable = true;
        }
        else if (currentZoom == 2)
        {
            currentZoom--;
            zoomOut.interactable = true;
            zoomIn.interactable = true;
        }
        else
        {
            //Buzzer
            zoomOut.interactable = false;
            zoomIn.interactable = true;
        }
        Debug.Log("Zoom Out");
        updateCamera();
    }

    public void finishCamera()
    {
        camera.GetComponent<Camera>().orthographicSize = 840F;
        camera.transform.position = new Vector3(1468F, -769F, -10F);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
