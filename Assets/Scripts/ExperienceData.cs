using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Experience
{
    public class ExperienceData : MonoBehaviour
    {
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within each quadrant.")]
        private float _AveragepathLength1 = 0;
        private float _AveragepathLength2 = 0;
        private float _AveragepathLength3 = 0;
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
        [SerializeField, Tooltip("Percentage time in each quadrant: The percentage time spent in each of the four quadrants.")]
        private float _PercentageTime = 0;
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
        public float PercentageTime => _PercentageTime;
        public float PercentageInactivTime => _PercentageInactivTime;
        public float PercentageTrialTime => _PercentageTrialTime;
        public float AntiClockNumPath => _AntiClockNumPath;
        public float ClockNumPath => _ClockNumPath;
        public float TotalTime => _TotalTime;
        public float InactivTime => _InactivTime;
        public bool ChangeDataViewer => _ChangeDataViewer;
        public bool MapViewer => _MapViewer;

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
            _PercentageTime = 0;
            _PercentageInactivTime = 0;
            _PercentageTrialTime = 0;
            _AntiClockNumPath = 0;
            _ClockNumPath = 0;
            _TotalTime = 0;
            _InactivTime = 0;
            _ChangeDataViewer = false;
            _MapViewer = false;
        }
        public void SetAveragepathLength(float value)
        {
            _AveragepathLength1 = value;
        }
        public void SetClosestDistance(float value)
        {
        }
        public void SetClosestTime(float value)
        {
        }
        public void SetAverageDiff(float value)
        {
        }
        public void SetReachTime(float value)
        {
        }
        public void SetStartTime(float value)
        {
        }
        public void SetPathLength(float value)
        {
        }
        public void SetPercentageTime(float value)
        {
        }
        public void SetPercentageInactivTime(float value)
        {
        }
        public void SetPercentageTrialTime(float value)
        {
        }
        public void SetAntiClockNumPath(float value)
        {
        }
        public void SetClockNumPath(float value)
        {
        }
        public void SetTotalTime(float value)
        {
        }
        public void SetInactivTime(float value)
        {
        }
        public void OnExpertData()
        {
            CsvWrite CSVData = new CsvWrite();
            CSVData.Save();
        }

    }
}

