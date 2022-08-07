using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CnCameraViewportHandler : MonoBehaviour
{
    public enum Constraint { Landscape, Portrait }

    #region FIELDS
    public Color wireColor = Color.white;
    public float UnitsSize = 1; // size of your scene in unity units
    public Constraint constraint = Constraint.Portrait;
    public static CnCameraViewportHandler Instance;
    public new CinemachineVirtualCamera camera;

    public bool executeInUpdate;

    private float _width;
    private float _height;
    //*** bottom screen
    private Vector3 _bl;
    private Vector3 _bc;
    private Vector3 _br;
    //*** middle screen
    private Vector3 _ml;
    private Vector3 _mc;
    private Vector3 _mr;
    //*** top screen
    private Vector3 _tl;
    private Vector3 _tc;
    private Vector3 _tr;
    #endregion

    #region PROPERTIES
    public float Width
    {
        get
        {
            return _width;
        }
    }
    public float Height
    {
        get
        {
            return _height;
        }
    }

    // helper points:
    public Vector3 BottomLeft
    {
        get
        {
            return _bl;
        }
    }
    public Vector3 BottomCenter
    {
        get
        {
            return _bc;
        }
    }
    public Vector3 BottomRight
    {
        get
        {
            return _br;
        }
    }
    public Vector3 MiddleLeft
    {
        get
        {
            return _ml;
        }
    }
    public Vector3 MiddleCenter
    {
        get
        {
            return _mc;
        }
    }
    public Vector3 MiddleRight
    {
        get
        {
            return _mr;
        }
    }
    public Vector3 TopLeft
    {
        get
        {
            return _tl;
        }
    }
    public Vector3 TopCenter
    {
        get
        {
            return _tc;
        }
    }
    public Vector3 TopRight
    {
        get
        {
            return _tr;
        }
    }
    #endregion

    #region METHODS
    private void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        Instance = this;
        ComputeResolution();
    }

    private void ComputeResolution()
    {
        float leftX, rightX, topY, bottomY;

        if (constraint == Constraint.Landscape)
        {
            camera.m_Lens.OrthographicSize = 1f / camera.m_Lens.Aspect * UnitsSize / 2f;
        }
        else
        {
            camera.m_Lens.OrthographicSize = UnitsSize / 2f;
        }

        _height = 2f * camera.m_Lens.OrthographicSize;
        _width = _height * camera.m_Lens.Aspect;

        float cameraX, cameraY;
        cameraX = camera.transform.position.x;
        cameraY = camera.transform.position.y;

        leftX = cameraX - _width / 2;
        rightX = cameraX + _width / 2;
        topY = cameraY + _height / 2;
        bottomY = cameraY - _height / 2;

        //*** bottom
        _bl = new Vector3(leftX, bottomY, 0);
        _bc = new Vector3(cameraX, bottomY, 0);
        _br = new Vector3(rightX, bottomY, 0);
        //*** middle
        _ml = new Vector3(leftX, cameraY, 0);
        _mc = new Vector3(cameraX, cameraY, 0);
        _mr = new Vector3(rightX, cameraY, 0);
        //*** top
        _tl = new Vector3(leftX, topY, 0);
        _tc = new Vector3(cameraX, topY, 0);
        _tr = new Vector3(rightX, topY, 0);
    }

    private void Update()
    {
#if UNITY_EDITOR

        if (executeInUpdate)
            ComputeResolution();

#endif
    }

    void OnDrawGizmos()
    {
        Gizmos.color = wireColor;

        Matrix4x4 temp = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        if (camera.m_Lens.Orthographic)
        {
            float spread = camera.m_Lens.FarClipPlane - camera.m_Lens.NearClipPlane;
            float center = (camera.m_Lens.FarClipPlane + camera.m_Lens.NearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, center), new Vector3(camera.m_Lens.OrthographicSize * 2 * camera.m_Lens.Aspect, camera.m_Lens.OrthographicSize * 2, spread));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, camera.m_Lens.FieldOfView, camera.m_Lens.FarClipPlane, camera.m_Lens.NearClipPlane, camera.m_Lens.Aspect);
        }
        Gizmos.matrix = temp;
    }
    #endregion

} // class