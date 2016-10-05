using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class FileManager : MonoBehaviour {

	private const string fileName = "game.stats";
	private int gamesPlayed;
	private int maxScore;

	// Use this for initialization
	void Start () {
		LoadSaveFile ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadSaveFile () {
		if (File.Exists (fileName)) {
			StreamReader reader = new StreamReader (fileName, Encoding.Default);
			string line;
			using (reader) {
				int lineNum = 0;
				GeneralStats gameStats = GeneralStats.instance;
				while ((line = reader.ReadLine ()) != null) {
					if (lineNum == 0) {
						string[] values = line.Split (';');
						if (values.Length >= 1) {
							gameStats.gamesPlayed = int.Parse (values [0]);
						} else if (values.Length >= 2) {
							gameStats.maxScore = int.Parse (values [1]);
						}
					}
				}
			}
		} else {
			File.Create (fileName);
		}
	}
}
