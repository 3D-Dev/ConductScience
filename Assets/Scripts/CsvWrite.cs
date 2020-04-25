using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using Experience;
using UnityEngine.UI;

using Firebase;
using Firebase.Database;
using Firebase.Extensions;

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
            string[] rowDataTemp = new string[22];
            rowDataTemp[0] = "ID";
            rowDataTemp[1] = "Name";
            rowDataTemp[2] = "pathLength_in_1stQuadrant";
            rowDataTemp[3] = "pathLength_in_secondQuadrant";
            rowDataTemp[4] = "pathLength_in_thirdQuadrant";
            rowDataTemp[5] = "pathLength_in_fourthQuadrant";
            rowDataTemp[6] = "ClosestDistance";
            rowDataTemp[7] = "ClosestTime";
            rowDataTemp[8] = "Heading error:AverageDirection";
            rowDataTemp[9] = "ReachTime";
            rowDataTemp[10] = "StartTime";
            rowDataTemp[11] = "PathLength";
            rowDataTemp[12] = "PercentageTime_in_1stQuadrant";
            rowDataTemp[13] = "PercentageTime_in_secondQuadrant";
            rowDataTemp[14] = "PercentageTime_in_thirdQuadrant";
            rowDataTemp[15] = "PercentageTime_in_fourthQuadrant";
            rowDataTemp[16] = "PercentageInactiveTime";
            rowDataTemp[17] = "PercentageTrialTime";
            rowDataTemp[18] = "AntiClockwise_directionNum";
            rowDataTemp[19] = "Clockwise_directionNum";
            rowDataTemp[20] = "TotalTime";
            rowDataTemp[21] = "InactiveTime";

            rowData.Add(rowDataTemp);

            for (int i = 1; i <= 22; i++)
            {
                rowDataTemp = new string[22];
                rowDataTemp[0] = "" + i;
                rowDataTemp[1] = "Anna";
                rowDataTemp[2] = "" +  ExperienceData.Instance.AveragepathLength1;//experienceData.AveragepathLength;
                rowDataTemp[3] = "" + ExperienceData.Instance.AveragepathLength2;
                rowDataTemp[4] = "" + ExperienceData.Instance.AveragepathLength3;
                rowDataTemp[5] = "" + ExperienceData.Instance.AveragepathLength4;
                rowDataTemp[6] = "" + ExperienceData.Instance.ClosestDistance;//experienceData.ClosestDistance;
                rowDataTemp[7] = "" + ExperienceData.Instance.ClosestTime;//experienceData.ClosestTime;
                rowDataTemp[8] = "" + ExperienceData.Instance.AverageDiff;//experienceData.AverageDiff;
                rowDataTemp[9] = "" + ExperienceData.Instance.ReachTime;//experienceData.ReachTime;
                rowDataTemp[10] = "" + ExperienceData.Instance.StartTime;//experienceData.StartTime;
                rowDataTemp[11] = "" + ExperienceData.Instance.PathLength;//experienceData.PathLength;
                rowDataTemp[12] = "" + ExperienceData.Instance.PercentageTime1 + "%";//experienceData.PercentageTime;
                rowDataTemp[13] = "" + ExperienceData.Instance.PercentageTime2 + "%";
                rowDataTemp[14] = "" + ExperienceData.Instance.PercentageTime3 + "%";
                rowDataTemp[15] = "" + ExperienceData.Instance.PercentageTime4 + "%";
                rowDataTemp[16] = "" + ExperienceData.Instance.PercentageInactivTime + "%";//experienceData.PercentageInactivTime;
                rowDataTemp[17] = "" + ExperienceData.Instance.PercentageTrialTime + "%";//experienceData.PercentageTrialTime;
                rowDataTemp[18] = "" + ExperienceData.Instance.AntiClockNumPath;//experienceData.AntiClockNumPath;
                rowDataTemp[19] = "" + ExperienceData.Instance.ClockNumPath;//experienceData.ClockNumPath;
                rowDataTemp[20] = "" + ExperienceData.Instance.TotalTime;//experienceData.TotalTime;
                rowDataTemp[21] = "" + ExperienceData.Instance.InactivTime;//experienceData.InactivTime;
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

            DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("Leaders");

            Debug.Log("Running Transaction...");
            // Use a transaction to ensure that we do not encounter issues with
            // simultaneous updates that otherwise might create more than MaxScores top scores.
            reference.RunTransaction(AddScoreTransaction)
              .ContinueWithOnMainThread(task => {
                  if (task.Exception != null)
                  {
                      Debug.Log(task.Exception.ToString());
                  }
                  else if (task.IsCompleted)
                  {
                      Debug.Log("Transaction complete.");
                  }
              });

            //string filePath = GetPath();

            //StreamWriter outStream = System.IO.File.CreateText(filePath);
            //outStream.WriteLine(sb);
            //outStream.Close();
        }

        // A realtime database transaction receives MutableData which can be modified
        // and returns a TransactionResult which is either TransactionResult.Success(data) with
        // modified data or TransactionResult.Abort() which stops the transaction with no changes.
        TransactionResult AddScoreTransaction(MutableData mutableData)
        {
            List<object> leaders = mutableData.Value as List<object>;

            if (leaders == null)
            {
                leaders = new List<object>();
            }
            
            // Now we add the new score as a new entry that contains the email address and score.
            Dictionary<string, object> newScoreMap = new Dictionary<string, object>();

            //newScoreMap["score"] = 252;
            //newScoreMap["email"] = "sdgasg";

            newScoreMap["pathLength_in_1stQuadrant"] = ExperienceData.Instance.AveragepathLength1;
            newScoreMap["pathLength_in_secondQuadrant"] = ExperienceData.Instance.AveragepathLength2;
            newScoreMap["pathLength_in_thirdQuadrant"] = ExperienceData.Instance.AveragepathLength3;
            newScoreMap["pathLength_in_fourthQuadrant"] = ExperienceData.Instance.AveragepathLength4;
            newScoreMap["ClosestDistance"] = ExperienceData.Instance.ClosestDistance;
            newScoreMap["ClosestTime"] = ExperienceData.Instance.ClosestTime;
            newScoreMap["AverageDirection"] = ExperienceData.Instance.AverageDiff;
            newScoreMap["ReachTime"] = ExperienceData.Instance.ReachTime;
            newScoreMap["StartTime"] = ExperienceData.Instance.StartTime;
            newScoreMap["PathLength"] = ExperienceData.Instance.PathLength;
            //newScoreMap["PercentageTime_in_1stQuadrant"] = ExperienceData.Instance.PercentageTime1;
            //newScoreMap["PercentageTime_in_secondQuadrant"] = ExperienceData.Instance.PercentageTime2;
            //newScoreMap["PercentageTime_in_thirdQuadrant"] = ExperienceData.Instance.PercentageTime3;
            //newScoreMap["PercentageTime_in_fourthQuadrant"] = ExperienceData.Instance.PercentageTime4;
            newScoreMap["PercentageInactiveTime"] = ExperienceData.Instance.PercentageInactivTime;
            //newScoreMap["PercentageTrialTime"] = ExperienceData.Instance.PercentageTrialTime;
            newScoreMap["AntiClockwise_directionNum"] = ExperienceData.Instance.AntiClockNumPath;
            newScoreMap["Clockwise_directionNum"] = ExperienceData.Instance.ClockNumPath;
            newScoreMap["TotalTime"] = ExperienceData.Instance.TotalTime;
            newScoreMap["InactiveTime"] = ExperienceData.Instance.InactivTime;

            leaders.Add(newScoreMap);

            // You must set the Value to indicate data at that location has changed.
            mutableData.Value = leaders;
            return TransactionResult.Success(mutableData);
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
