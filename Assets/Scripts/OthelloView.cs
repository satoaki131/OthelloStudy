using UnityEngine;

public class OthelloView : MonoBehaviour
{

    [SerializeField]
    private GameObject[,] map = null;
    private Renderer _renderer;

    public int countX;
    public int countZ;

    private int selectX = 0;
    private int selectZ = 0;

    void Start()
    {
        map = new GameObject[countX, countZ];
        var cell = Resources.Load<GameObject>("Cell/Cell");
        for (int x = 0; x < countX; x++)
        {
            for (int z = 0; z < countZ; z++)
            {
                map[x, z] = Instantiate(cell,
                    new Vector3(x * 1.05f, 0.0f, z * 1.05f),
                    new Quaternion(0.0f, 0.0f, 0.0f, 1.0f))
                    as GameObject;

                map[x, z].transform.name =
                    "[" + x + " , " + z + " ] ";

                map[x, z].transform.parent =
                    this.gameObject.transform;

               
            }
        }
        _renderer = map[selectX, selectZ].GetComponent<Renderer>();
        _renderer.material.color = Color.red;   
    }

    void Update()
    {
        Selectmap();
    }

    void Selectmap()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectZ < countZ - 1) selectZ += 1;
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectZ > 0) selectZ -= 1;
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectX < countX - 1) selectX += 1;
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.green;
            if (selectX > 0) selectX -= 1;
            map[selectX, selectZ].GetComponent<Renderer>().material.color = Color.red;
        }
    }
  
}