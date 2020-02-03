using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Experience
{
    public class ExperienceData : MonoBehaviour
    {
        [SerializeField, Tooltip("Average path length in each quadrant: The average length of the path traversed within each quadrant.")]
        private float _AveragepathLength = 0;
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

        public float AveragepathLength => _AveragepathLength;
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
    }
}

