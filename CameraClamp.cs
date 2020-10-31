using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField] [HideInInspector] private float _xMin;
    public float xMin
    {
        get { return _xMin; }
        set
        {
            if (value > transform.position.x - horizontalExtents) return;
            else _xMin = value;
        }
    }

    [SerializeField] [HideInInspector] private float _xMax;
    public float xMax
    {
        get { return _xMax; }
        set
        {
            if (value < transform.position.x + horizontalExtents) return;
            else _xMax = value;
        }
    }

    [SerializeField] [HideInInspector] private float _yMin;
    public float yMin
    { 
        get { return _yMin; }
        set
        {
            if (value > transform.position.y - verticalExtents) return;
            else _yMin = value;
        }
    }

    [SerializeField] [HideInInspector] private float _yMax;
    public float yMax
    {
        get { return _yMax; }
        set
        {
            if (value < transform.position.y + verticalExtents) return;
            else _yMax = value;
        }
    }

    [SerializeField] [HideInInspector] private bool initialized;
    private float verticalExtents;
    private float horizontalExtents;
    private Camera cam;

    private void OnValidate()
    {
        cam = GetComponent<Camera>();
        if (!initialized)
        {
            Initialize();
        }
    }

    private void Start()
    {
        CalculateExtents();
        
    }
    void LateUpdate()
    {
        Clamp();
    }
    private void OnDrawGizmos()
    {
        Vector2 topLeft = new Vector2(xMin, yMax);
        Vector2 topRight = new Vector2(xMax, yMax);
        Vector2 bottomLeft = new Vector2(xMin, yMin);
        Vector2 bottomRight = new Vector2(xMax, yMin);
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topLeft, bottomLeft);
        Gizmos.DrawLine(bottomLeft, bottomRight);
        Gizmos.DrawLine(bottomRight, topRight);
    }
    //This method is called once in OnValidate once when this monobehavior is added to a gameobject
    private void Initialize()
    {
        CalculateExtents();
        //initialize values
        xMin = transform.position.x - horizontalExtents;
        xMax = transform.position.x + horizontalExtents;
        yMin = transform.position.y - verticalExtents;
        yMax = transform.position.y + verticalExtents;
        
        initialized = true;
    }
    private void CalculateExtents()
    {
        verticalExtents = cam.orthographicSize;
        horizontalExtents = cam.orthographicSize * cam.aspect;
    }
    private void Clamp()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin + horizontalExtents, xMax - horizontalExtents),
                            Mathf.Clamp(transform.position.y, yMin + verticalExtents, yMax - verticalExtents),
                            transform.position.z);
    }
}

