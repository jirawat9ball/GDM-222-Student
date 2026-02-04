using UnityEngine;

namespace Solution
{

    public class OOPMapGenerator : MonoBehaviour
    {
        [Header("Set MapGenerator")]
        public int Rows;
        public int Cols;

        [Header("Set Player")]
        public GameObject player;
        public Vector2Int playerStartPos;

        [Header("Set Exit")]
        public GameObject Exit;

        [Header("Set Prefab")]
        public GameObject[] floorsPrefab;
        public GameObject[] wallsPrefab;
        public GameObject[] demonWallsPrefab;
        public GameObject[] itemsPrefab;

        [Header("Set Transform")]
        public Transform floorParent;
        public Transform wallParent;
        public Transform itemPotionParent;
        public Transform EnemyParent;

        [Header("Set object Count")]
        public int obsatcleCount;
        public int itemPotionCount;

        public Identity[,] mapdata;

        public OOPPlayer playerScript;
        public OOPExit exitScript;
        // block types ...
        [HideInInspector]
        public string empty = "";
        [HideInInspector]
        public string demonWall = "demonWall";
        [HideInInspector]
        public string potion = "potion";
        [HideInInspector]
        public string bonuesPotion = "bonuesPotion";
        [HideInInspector]
        public string exit = "exit";
        [HideInInspector]
        public string playerOnMap = "player";

        // Start is called before the first frame update
        void Start()
        {
            mapdata = new Identity[Rows, Cols];
            for (int x = -1; x < Rows + 1; x++)
            {
                for (int y = -1; y < Cols + 1; y++)
                {
                    if (x == -1 || x == Rows || y == -1 || y == Cols)
                    {
                        int r = Random.Range(0, wallsPrefab.Length);
                        GameObject obj = Instantiate(wallsPrefab[r], new Vector3(x, y, 0), Quaternion.identity);
                        obj.transform.parent = wallParent;
                        obj.name = "Wall_" + x + ", " + y;
                    }
                    else
                    {
                        int r = Random.Range(0, floorsPrefab.Length);
                        GameObject obj = Instantiate(floorsPrefab[r], new Vector3(x, y, 1), Quaternion.identity);
                        obj.transform.parent = floorParent;
                        obj.name = "floor_" + x + ", " + y;
                        mapdata[x, y] = null;
                    }
                }
            }

            GameObject plyer = PlaceObject(0, 0, player.gameObject, null);
            playerScript = plyer.GetComponent<OOPPlayer>();

            GameObject exit = PlaceObject(Rows-1, Cols-1, Exit.gameObject, null);
            exitScript = exit.GetComponent<OOPExit>();

            int count = 0;

            int preventInfiniteLoop = 100;
            while (count < obsatcleCount)
            {
                if (--preventInfiniteLoop < 0) break;
                int x = Random.Range(0, Rows);
                int y = Random.Range(0, Cols);
                if (mapdata[x, y] == null)
                {
                    int r = Random.Range(0, demonWallsPrefab.Length);
                    GameObject g = demonWallsPrefab[r];
                    PlaceObject(x, y, g, wallParent);
                    count++;
                }
            }

            count = 0;
            preventInfiniteLoop = 100;
            while (count < itemPotionCount)
            {
                if (--preventInfiniteLoop < 0) break;
                int x = Random.Range(0, Rows);
                int y = Random.Range(0, Cols);
                if (mapdata[x, y] == null)
                {

                    int r = Random.Range(0, itemsPrefab.Length);
                    GameObject g = itemsPrefab[r];
                    PlaceObject(x, y, g, itemPotionParent);
                    count++;
                }
            }

        }

        public Identity GetMapData(float x, float y)
        {
            if (x >= Rows || x < 0 || y >= Cols || y < 0) return null;
            return mapdata[(int)x, (int)y];
        }

        public GameObject PlaceObject(int x, int y,GameObject identity,Transform parrent)
        {
            
            GameObject obj = Instantiate(identity, new Vector3(x, y, 0), Quaternion.identity);
            obj.transform.parent = parrent;
            Identity _identity = obj.GetComponent<Identity>();
            _identity.mapGenerator = this;
            _identity.positionX = x;
            _identity.positionY = y;
            mapdata[x, y] = _identity;
            return obj;
        }
        public void UpdatePositionIdenity(Identity identity, 
        int toX,int toY)
        {
            mapdata[identity.positionX,identity.positionY] = null;
            int newX = Mathf.Clamp(toX,0,Rows);
            int newY = Mathf.Clamp(toY,0,Cols);

            Debug.Log(newX+":"+newY);
            mapdata[newX,newY] = identity;
            identity.positionX  =newX;
            identity.positionY  =newY;
            identity.transform.position  = new Vector3(newX,newY,0);
        }
      
    }
}