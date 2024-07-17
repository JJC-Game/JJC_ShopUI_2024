using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ItemFixDataManager : MonoBehaviour
{
    public List<ItemFixData> fixDataList;

    private void Awake()
    {
        LoadFixData();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadFixData()
    {
        TextAsset csvFile;
        csvFile = Resources.Load("FixData/ItemFixData") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] elementArray = line.Split(',');
            Debug.Log(line);

            ItemFixData newItemFixData = new ItemFixData();
            newItemFixData._id = int.Parse(elementArray[0]);
            newItemFixData._name = elementArray[1];
            newItemFixData._description = elementArray[2];
            newItemFixData._iconPath= elementArray[3];
            newItemFixData._iconSprite = Resources.Load<Sprite>(newItemFixData._iconPath);
            newItemFixData._value = int.Parse(elementArray[4]);

            fixDataList.Add(newItemFixData);
//            csvDatas.Add(line.Split(',')); // リストに入れる
        }


    }

    public ItemFixData GetFixData(int index)
    {
        return fixDataList[index];
    }

    public int GetFixDataNum()
    {
        return fixDataList.Count;
    }

    /*
     *         if (File.Exists(filePath))
        {
            // ファイルがあるなら、それを読み取る.
            string spawnListAllString = File.ReadAllText(filePath);
            string[] spawnListLineString = spawnListAllString.Split('\n');

            for (int lineIndex = 0; lineIndex < spawnListLineString.Length; lineIndex++)
            {
                string[] spawnListElementString = spawnListLineString[lineIndex].Split(',');
                // ファイル形式が想定と違う部分（空行とか）は、無視して終わる.
                if (spawnListElementString.Length != 2)
                {
                    break;
                }
                NodeSpawnInfo newNodeSpawnInfo = new NodeSpawnInfo();
                newNodeSpawnInfo.lineId = int.Parse(spawnListElementString[0]);
                newNodeSpawnInfo.nodeTapTimingSecond = float.Parse(spawnListElementString[1]);
                nodeSpawnList.Add(newNodeSpawnInfo);
                spawned.Add(false);
            }

            isSpawnRandomNode = false;
        }
     */
}
