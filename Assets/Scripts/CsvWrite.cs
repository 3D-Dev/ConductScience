using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using Experience;
using UnityEngine.UI;

namespace Experience
{
    public class CsvWrite : MonoBehaviour
    {
        ExperienceData experienceData = new ExperienceData();
        private List<string[]> rowData = new List<string[]>();
        // Start is called before the first frame update
        void Start()
        {
            
        }
        public void Save()
        {
            string[] rowDataTemp = new string[16];
            rowDataTemp[0] = "ID";
            rowDataTemp[1] = "Name";
            rowDataTemp[2] = "AveragepathLength";
            rowDataTemp[3] = "ClosestDistance";
            rowDataTemp[4] = "ClosestTime";
            rowDataTemp[5] = "AverageDiff";
            rowDataTemp[6] = "ReachTime ";
            rowDataTemp[7] = "StartTime ";
            rowDataTemp[8] = "PathLength";
            rowDataTemp[9] = "PercentageTime";
            rowDataTemp[10] = "PercentageInactivTime";
            rowDataTemp[11] = "PercentageTrialTime";
            rowDataTemp[12] = "AntiClockNumPath";
            rowDataTemp[13] = "ClockNumPath";
            rowDataTemp[14] = "TotalTime";
            rowDataTemp[15] = "InactivTime";

            rowData.Add(rowDataTemp);

            for (int i = 0; i < 16; i++)
            {
                rowDataTemp = new string[16];
                rowDataTemp[0] = "" + i + 1;
                rowDataTemp[1] = "Anna";
                rowDataTemp[2] = "" + experienceData.AveragepathLength;
                rowDataTemp[3] = "" + experienceData.ClosestDistance;
                rowDataTemp[4] = "" + experienceData.ClosestTime;
                rowDataTemp[5] = "" + experienceData.AverageDiff;
                rowDataTemp[6] = "" + experienceData.ReachTime;
                rowDataTemp[7] = "" + experienceData.StartTime;
                rowDataTemp[8] = "" + experienceData.PathLength;
                rowDataTemp[9] = "" + experienceData.PercentageTime;
                rowDataTemp[10] = "" + experienceData.PercentageInactivTime;
                rowDataTemp[11] = "" + experienceData.PercentageTrialTime;
                rowDataTemp[12] = "" + experienceData.AntiClockNumPath;
                rowDataTemp[13] = "" + experienceData.ClockNumPath;
                rowDataTemp[14] = "" + experienceData.TotalTime;
                rowDataTemp[15] = "" + experienceData.InactivTime;
                rowData.Add(rowDataTemp);
            }
            string[][] output = new string[rowData.Count][];
            for (int i = 0; i < output.Length; i++) {
                output[i] = rowData[i];
            }
            int length = output.GetLength(0);
            string delimiter = ",";

            StringBuilder sb = new StringBuilder();

            for (int index = 0; index < length; index++)
            {
                sb.AppendLine(string.Join(delimiter, output[index]));
            }

            string filePath = GetPath();

            StreamWriter outStream = System.IO.File.CreateText(filePath);
            outStream.WriteLine(sb);
            outStream.Close();
        }
        
        private string GetPath()
        {
        #if UNITY_EDITOR
                    return Application.dataPath + "/CSV/" + "Experience_data.csv";
        #elif UNITY_ANDROID
                return Application.persistentDataPath+"Experience_data.csv";
        #elif UNITY_IPHONE
                return Application.persistentDataPath+"/"+"Experience_data.csv";
        #else
                return Application.dataPath +"/"+"Experience_data.csv";
        #endif
        }
    }

}
