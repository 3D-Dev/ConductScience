using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Experience
{
    public class ExperienceData : MonoBehaviour
    {
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within 1st quadrant.")]
        private float _AveragepathLength1 = 0;
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within 2 quadrant.")]
        private float _AveragepathLength2 = 0;
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within 3 quadrant.")]
        private float _AveragepathLength3 = 0;
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within 4 quadrant.")]
        private float _AveragepathLength4 = 0;
        [SerializeField, Tooltip("Close encounter with the target (Distance): Closest distance to the target")]
        private float _ClosestDistance = 0;
        [SerializeField, Tooltip("Close encounter with the target (Time): Time spent near the target.")]
        private float _ClosestTime = 0;
        [SerializeField, Tooltip("Average difference between the direction of movement toward the anticipated target and the real direction toward the target.")]
        private float _AverageDiff = 0;
        [SerializeField, Tooltip("Latency to locate target: Time taken to reach the target.")]
        private float _ReachTime = 0;
        [SerializeField, Tooltip("Latency to start the task: Time taken to initiate exploration.")]
        private float _StartTime = 0;
        [SerializeField, Tooltip("Path length: Total distance moved in proportion to the total pool diameter or area.")]
        private float _PathLength = 0;
        [SerializeField, Tooltip("Path traversed: The visualization of the path traversed by the participant during the task.")]
        private bool _PathViewer = false;
        [SerializeField, Tooltip("Percentage time in each quadrant: The percentage time spent in each of the 1st quadrant.")]
        private float _PercentageTime1 = 0;
        [SerializeField, Tooltip("Percentage time in each quadrant: The percentage time spent in each of the 2 quadrant.")]
        private float _PercentageTime2 = 0;
        [SerializeField, Tooltip("Percentage time in each quadrant: The percentage time spent in each of the 3 quadrant.")]
        private float _PercentageTime3 = 0;
        [SerializeField, Tooltip("Percentage time in each quadrant: The percentage time spent in each of the 4 quadrant.")]
        private float _PercentageTime4 = 0;
        [SerializeField, Tooltip("Percentage time of inactivity: Percentage time spent without any exploration.")]
        private float _PercentageInactivTime = 0;
        [SerializeField, Tooltip("Percentage time spent in target quadrant: The time spent in the target quadrant during a trial.")]
        private float _PercentageTrialTime = 0;
        [SerializeField, Tooltip("Pool/Area circling: Number of anti-clockwise.")]
        private float _AntiClockNumPath = 0;
        [SerializeField, Tooltip("Pool/Area circling: Number of clockwise paths.")]
        private float _ClockNumPath = 0;
        [SerializeField, Tooltip("Time spent in each quadrant: The total time spent in each of the four quadrants.")]
        private float _TotalTime = 0;
        [SerializeField, Tooltip("Time spent inactive: Time spent without any exploration.")]
        private float _InactivTime = 0;
        [SerializeField, Tooltip("if the same subject has done the experiment before the user can see the change over time as well compared to prior.")]
        private bool _ChangeDataViewer = false;
        [SerializeField, Tooltip("the only visualization is the map, all other data is raw form that can be exported to .csv.")]
        private bool _MapViewer = false;

        public float AveragepathLength1 => _AveragepathLength1;
        public float AveragepathLength2 => _AveragepathLength2;
        public float AveragepathLength3 => _AveragepathLength3;
        public float AveragepathLength4 => _AveragepathLength4;
        public float ClosestDistance => _ClosestDistance;
        public float ClosestTime => _ClosestTime;
        public float AverageDiff => _AverageDiff;
        public float ReachTime => _ReachTime;
        public float StartTime => _StartTime;
        public float PathLength => _PathLength;
        public bool PathViewer => _PathViewer;
        public float PercentageTime1 => _PercentageTime1;
        public float PercentageTime2 => _PercentageTime2;
        public float PercentageTime3 => _PercentageTime3;
        public float PercentageTime4 => _PercentageTime4;
        public float PercentageInactivTime => _PercentageInactivTime;
        public float PercentageTrialTime => _PercentageTrialTime;
        public float AntiClockNumPath => _AntiClockNumPath;
        public float ClockNumPath => _ClockNumPath;
        public float TotalTime => _TotalTime;
        public float InactivTime => _InactivTime;
        public bool ChangeDataViewer => _ChangeDataViewer;
        public bool MapViewer => _MapViewer;
        private Vector3 EachQuad;
        //private int CircleSize_x, CircleSize_y, CircleSize_z;
        public bool isActive;
        public float CircleSize;
        public float AverageLength1;
        public float AverageLength2;
        public float AverageLength3;
        public float AverageLength4;

        private static ExperienceData instance;

        public static ExperienceData Instance
        {
            get
            {
                if (instance == null)
                    instance = GameObject.FindObjectOfType<ExperienceData>();

                return instance;
            }
        }
        public void InitParam()
        {
            _AveragepathLength1 = 0;
            _AveragepathLength2 = 0;
            _AveragepathLength3 = 0;
            _AveragepathLength4 = 0;
            _ClosestDistance = 0;
            _ClosestTime = 0;
            _AverageDiff = 0;
            _ReachTime = 0;
            _StartTime = 0;
            _PathLength = 0;
            _PathViewer = false;
            _PercentageTime1 = 0;
            _PercentageTime2 = 0;
            _PercentageTime3 = 0;
            _PercentageTime4 = 0;
            _PercentageInactivTime = 0;
            _PercentageTrialTime = 0;
            _AntiClockNumPath = 0;
            _ClockNumPath = 0;
            _TotalTime = 0;
            _InactivTime = 0;
            _ChangeDataViewer = false;
            _MapViewer = false;
            EachQuad = new Vector3(0, 0, 0);
            //CircleSize_x = CircleSize_y = CircleSize_z = 300;
            isActive = false;
        }
        public void SetEachQuad(Vector3 Sum)
        {
            EachQuad = Sum;
        }
        public int GetEachQuad(Vector3 pos)
        {
            if (((0 > pos.x) && (pos.x > -CircleSize)) && ((0 < pos.z) && (pos.z < CircleSize)))
                return 1;
            else if (((0 < pos.x) && (pos.x < CircleSize)) && ((0 < pos.z) && (pos.z < CircleSize)))
                return 2;
            else if (((0 > pos.x) && (pos.x > -CircleSize)) && ((0 > pos.z) && (pos.z > -CircleSize)))
                return 3;
            else if (((0 < pos.x) && (pos.x < CircleSize)) && ((0 > pos.z) && (pos.z > -CircleSize)))
                return 4;
            return 0;
        }
        public void SetFinalData()
        {
            if (!isActive)
                return;
            float divnum = _PercentageTime1 + _PercentageTime2 + _PercentageTime3 + _PercentageTime4;
            //--------------------------------------
            _PercentageTime1 = (_PercentageTime1 / divnum) * 100;
            _PercentageTime2 = (_PercentageTime2 / divnum) * 100;
            _PercentageTime3 = (_PercentageTime3 / divnum) * 100;
            _PercentageTime4 = (_PercentageTime4 / divnum) * 100;
            //--------------------------------------
            switch (GetEachQuad(EachQuad))
            {
                case 0:
                    break;
                case 1:
                    SetPercentageTrialTime(_PercentageTime1);
                    break;
                case 2:
                    SetPercentageTrialTime(_PercentageTime2);
                    break;
                case 3:
                    SetPercentageTrialTime(_PercentageTime3);
                    break;
                case 4:
                    SetPercentageTrialTime(_PercentageTime4);
                    break;
            }
            _AveragepathLength1 = AverageLength1; 
            _AveragepathLength2 = AverageLength2;
            _AveragepathLength3 = AverageLength3;
            _AveragepathLength4 = AverageLength4;
            SetPathLength(AverageLength1 + AverageLength2 + AverageLength3 + AverageLength4);
            SetPercentageInactivTime(_InactivTime);
            SetTotalTime(_ReachTime);
            _MapViewer = isActive;

        }
        public void SetClosestDistance(float value)
        {
            _ClosestDistance = value;
        }
        public void SetClosestTime(float value)
        {
            _ClosestTime = value;
        }
        public void SetPathViewer(bool bFlag)
        {
            _PathViewer = bFlag;
        }
        public void SetAverageDiff(float value)
        {
            _AverageDiff = value;
        }
        public void SetReachTime(float value)
        {
            _ReachTime = value;
        }
        public void SetStartTime(float value)
        {
            _StartTime = value;
        }
        private void SetPathLength(float value)
        {
            _PathLength = value / (Mathf.Pow(CircleSize, 2) * Mathf.PI);
        }
        public void SetPercentageTime(float value, int i)//update call
        {
            switch(i)
            {
                case 1:
                    _PercentageTime1 = value;
                    break;
                case 2:
                    _PercentageTime2 = value;
                    break;
                case 3:
                    _PercentageTime3 = value;
                    break;
                case 4:
                    _PercentageTime4 = value;
                    break;
                default:
                    break;
            }
        }
        private void SetPercentageInactivTime(float value)
        {
            if (_ReachTime == 0)
                return;
            _PercentageInactivTime = value / _ReachTime * 100;
        }
        public void SetPercentageTrialTime(float value)
        {
            _PercentageTrialTime = value;
        }
        public void SetAntiClockNumPath(float value)
        {
            _AntiClockNumPath = value;
        }
        public void SetClockNumPath(float value)
        {
            _ClockNumPath = value;
        }
        private void SetTotalTime(float value)
        {
            _TotalTime = value;
        }
        public void SetInactivTime(float value)
        {
            _InactivTime = value;
        }
        public void OnExpertData()
        {
            CsvWrite CSVData = new CsvWrite();
            CSVData.Save();
        }

    }
}

