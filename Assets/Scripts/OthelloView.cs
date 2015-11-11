using UnityEngine;

public class OthelloView : MonoBehaviour
{
    [SerializeField]
    private GameObject[,] _cells = null;
    private Renderer _renderer;
  
    public int countX;
    public int countZ;

    private const float CellMargin = 1.05f;
    private int selectX = 0;
    private int selectZ = 0;
    
 
    void Start()
    {
        _cells = new GameObject[countX, countZ];
        var cell = Resources.Load<GameObject>("Cell/Cell");
        for (int x = 0; x < countX; x++)
        {
            for (int z = 0; z < countZ; z++)
            {
                _cells[x, z] = Instantiate(cell,
                    new Vector3(x * CellMargin, 0.0f, z * CellMargin),
                    new Quaternion(0.0f, 0.0f, 0.0f, 1.0f))
                    as GameObject;

                _cells[x, z].transform.name =
                    "[" + x + " , " + z + " ] ";

                _cells[x, z].transform.parent =
                    gameObject.transform;

               
            }
        }
        _renderer = _cells[selectX, selectZ].GetComponent<Renderer>();
        _renderer.material.color = Color.red;   
    }

    void Update()
    {
        Selectmap();
        var stone = Resources.Load<GameObject>("Stone/Stone");
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(stone, new Vector3(_cells[selectX, selectZ].transform.position.x, 0.1f, _cells[selectX, selectZ].transform.position.z), transform.rotation);
        }
    }

    void Selectmap()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectZ < countZ - 1) selectZ += 1;
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectZ > 0) selectZ -= 1;
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectX < countX - 1) selectX += 1;
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectX > 0) selectX -= 1;
            _cells[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
    }
  
}