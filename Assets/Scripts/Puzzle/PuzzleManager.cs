using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    [SerializeField] Sprite animalImagePuzzle;
    [Header("End Puzzle")]
    public GameObject EndMenu;
    [SerializeField] Image animalImageEnd;
    [Header("Puzzle")]

    public GameObject SelectedPiece;
    int OIL = 1;
    public int PlacedPieces = 0;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        animalImagePuzzle = GameManager.instance.animal.animalImage;
        animalImageEnd.sprite = GameManager.instance.animal.animalImage;
        for (int i = 0; i < 8; i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = animalImagePuzzle;
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<piceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScript>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
        if (PlacedPieces == 8)
        {
            EndMenu.SetActive(true);
            GameManager.instance.animal.caught = true;
            PlayerPrefs.SetString(GameManager.instance.animal.name, "true");
        }
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CloseScene()
    {
        SceneManager.UnloadSceneAsync("Puzzle");
        GameManager.instance.animalCatched += 1;
        GameManager.instance.BacktoGame();
    }
}